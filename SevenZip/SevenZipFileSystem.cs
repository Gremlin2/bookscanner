// Copyright 2008-2010 Andrej Repin aka Gremlin2
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using VirtualFileSystem;
using VirtualFileSystem.Provider;
using VirtualFileSystem.Provider.Local;

namespace Gremlin.FB2Librarian.Import.SevenZip
{
    public class SevenZipFileSystem : AbstractFileSystem
    {
        private readonly IInArchive archive;
        private readonly FileInfo file;

        private class ArchiveOpenCallback : IArchiveOpenCallback, IArchiveOpenVolumeCallback, IDisposable
        {
            private readonly SevenZipFileSystem fileSystem;
            private readonly IFileObject parent;
            private readonly FileInfo archiveFile;
            private readonly List<Stream> streams;

            public ArchiveOpenCallback(SevenZipFileSystem fileSystem, IFileObject parent, FileInfo archiveFile)
            {
                this.fileSystem = fileSystem;
                this.parent = parent;
                this.archiveFile = archiveFile;

                this.streams = new List<Stream>();
            }

            public void SetTotal(IntPtr files, IntPtr bytes)
            {
            }

            public void SetCompleted(IntPtr files, IntPtr bytes)
            {
            }

            public int GetProperty(ItemPropId propID, ref PropVariant value)
            {
                switch (propID)
                {
                    case ItemPropId.kpidName:
                        value.VarType = VarEnum.VT_BSTR;
                        value.pointerValue = Marshal.StringToBSTR(archiveFile.FullName);
                        break;

                    case ItemPropId.kpidIsFolder:
                        value.VarType = VarEnum.VT_BOOL;
                        value.longValue = (byte)(archiveFile.Attributes & FileAttributes.Directory);
                        break;

                    case ItemPropId.kpidCreationTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = archiveFile.CreationTime.ToFileTime();
                        break;

                    case ItemPropId.kpidLastAccessTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = archiveFile.LastAccessTime.ToFileTime();
                        break;

                    case ItemPropId.kpidLastWriteTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = archiveFile.LastWriteTime.ToFileTime();
                        break;

                    case ItemPropId.kpidSize:
                        value.VarType = VarEnum.VT_UI8;
                        value.longValue = archiveFile.Length;
                        break;
                }

                return 0;
            }

            public int GetStream(string name, out IInStream inStream)
            {
                IFileObject volumeFileObject = parent.resolveFile(Path.GetFileName(name));
                if (volumeFileObject != null && volumeFileObject.exists())
                {
                    fileSystem.fireVolumeOpened(volumeFileObject);

                    FileInfo file = parent.FileSystem.replicateFile(volumeFileObject, Selectors.SELECT_SELF);
                    Stream fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                    streams.Add(fs);

                    inStream = new InStreamWrapper(fs);
                    return 0;
                }

                inStream = null;
                return 1;
            }

            public void Dispose()
            {
                foreach(Stream stream in streams)
                {
                    stream.Dispose();
                }
            }
        }

        private class ArchiveExtractCallback : IProgress, IArchiveExtractCallback
        {
            private readonly Stream stream;

            public ArchiveExtractCallback(Stream outputStream)
            {
                this.stream = outputStream;
            }

            public void SetTotal(ulong total)
            {
            }

            public void SetCompleted(ref ulong completeValue)
            {
            }

            public int GetStream(uint index, out ISequentialOutStream outStream, AskMode askExtractMode)
            {
                outStream = askExtractMode == AskMode.kExtract ? new OutStreamWrapper(this.stream) : null;
                return 0;
            }

            public void PrepareOperation(AskMode askExtractMode)
            {
            }

            public void SetOperationResult(OperationResult resultEOperationResult)
            {
            }
        }

        public SevenZipFileSystem(IInArchive archive, IFileName rootName, IFileObject parentLayer, FileSystemOptions fileSystemOptions) : base(rootName, parentLayer, fileSystemOptions)
        {
            this.archive = archive;

            if (parentLayer.FileSystem is LocalFileSystem || parentLayer.Content.Size > 1048576)
            {
                file = parentLayer.FileSystem.replicateFile(parentLayer, Selectors.SELECT_SELF);
            }
        }

        internal IInArchive Archive
        {
            get
            {
                return archive;
            }
        }

        private Stream GetArchiveStream()
        {
            if(file != null)
            {
                return file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            MemoryStream stream = new MemoryStream((int) ParentLayer.Content.Size);

            using (Stream input = ParentLayer.Content.InputStream)
            {
                byte[] buffer = new byte[16384];
                bool copying = true;

                while (copying)
                {
                    int bytesRead = input.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                    else
                    {
                        stream.Flush();
                        copying = false;
                    }
                }
            }

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }

        public override void init()
        {
            base.init();
            
            try
            {
                IList strongRef = new ArrayList(100);

                using(Stream stream = GetArchiveStream())
                {
                    using(InStreamWrapper wrapper = new InStreamWrapper(stream))
                    {
                        using (ArchiveOpenCallback callback = new ArchiveOpenCallback(this, ParentLayer.Parent, file))
                        {
                            ulong checkPos = 128 * 1024;
                            if (archive.Open(wrapper, ref checkPos, callback) != 0)
                            {
                                throw new FileSystemException(String.Format("Could not open Zip file \"{0}\".", ParentLayer));
                            }

                            uint count = archive.GetNumberOfItems();
                            for (uint index = 0; index < count; index++)
                            {
                                PropVariant entryName = new PropVariant();
                                archive.GetProperty(index, ItemPropId.kpidPath, ref entryName);

                                PropVariant hostSystem = new PropVariant();
                                archive.GetProperty(index, ItemPropId.kpidHostOS, ref hostSystem);

                                string path = (string) entryName.GetObject();
                                if (String.Compare((string) hostSystem.GetObject(), "FAT", 0) == 0)
                                {
                                    if (SevenZipFormat.SystemCodePage != SevenZipFormat.DefaultCodePage)
                                    {
                                        path = SevenZipFormat.DefaultEncoding.GetString(SevenZipFormat.SystemEncoding.GetBytes(path));
                                    }
                                }

                                IFileName name = FileSystemManager.resolveName(RootName, VirtualFileSystem.Provider.UriParser.encode(path));

                                PropVariant isFolderProperty = new PropVariant();
                                archive.GetProperty(index, ItemPropId.kpidIsFolder, ref isFolderProperty);

                                SevenZipFileObject fileObj;
                                if ((bool) isFolderProperty.GetObject() && getFileFromCache(name) != null)
                                {
                                    fileObj = (SevenZipFileObject) getFileFromCache(name);
                                    fileObj.Index = index;
                                    continue;
                                }

                                fileObj = createFileObject(name, index);
                                putFileToCache(fileObj);
                                strongRef.Add(fileObj);
                                fileObj.holdObject(strongRef);

                                SevenZipFileObject parent = null;
                                for (IFileName parentName = name.Parent; parentName != null; fileObj = parent, parentName = parentName.Parent)
                                {
                                    // Locate the parent
                                    parent = (SevenZipFileObject) getFileFromCache(parentName);
                                    if (parent == null)
                                    {
                                        parent = createFileObject(parentName, UInt32.MaxValue);

                                        putFileToCache(parent);
                                        strongRef.Add(parent);
                                        parent.holdObject(strongRef);
                                    }

                                    // Attach child to parent
                                    parent.attachChild(fileObj.Name);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                closeCommunicationLink();
            }
        }

        private SevenZipFileObject createFileObject(IFileName name, uint index)
        {
            return new SevenZipFileObject(name, index, this, true);
        }

        public override void close()
        {
            base.close();
            Marshal.ReleaseComObject(archive);
        }

        protected override void doCloseCommunicationLink()
        {
            archive.Close();
        }

        /// <summary> 
        /// will be called after all file-objects closed their streams.
        /// </summary>
        protected override void notifyAllStreamsClosed()
        {
            closeCommunicationLink();
        }

        public Stream GetInputStream(uint index)
        {
            using (Stream stream = GetArchiveStream())
            {
                using (InStreamWrapper wrapper = new InStreamWrapper(stream))
                {
                    using (ArchiveOpenCallback callback = new ArchiveOpenCallback(this, ParentLayer.Parent, file))
                    {
                        ulong checkPos = 128 * 1024;
                        if (archive.Open(wrapper, ref checkPos, callback) != 0)
                        {
                            throw new FileSystemException(String.Format("Could not open archive file \"{0}\".", ParentLayer));
                        }

                        try
                        {
                            PropVariant sizeProperty = new PropVariant();
                            archive.GetProperty(index, ItemPropId.kpidSize, ref sizeProperty);

                            // TODO: Limit memory usage.

                            MemoryStream ms = new MemoryStream(sizeProperty.intValue);
                            archive.Extract(new[] {index}, 1, 0, new ArchiveExtractCallback(ms));
                            ms.Seek(0, SeekOrigin.Begin);

                            return ms;
                        }
                        finally
                        {
                            closeCommunicationLink();
                        }
                    }
                }
            }
        }

        protected override IFileObject createFile(IFileName name)
        {
            // This is only called for files which do not exist in the Zip file
            return new SevenZipFileObject(name, UInt32.MaxValue, this, false);
        }

        protected override void addCapabilities(IList caps)
        {
            foreach (object capability in SevenZipFileProvider.capabilities)
            {
                caps.Add(capability);
            }
        }
    }
}