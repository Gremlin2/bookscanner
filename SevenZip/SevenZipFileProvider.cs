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

using VirtualFileSystem;
using VirtualFileSystem.Provider;

namespace Gremlin.FB2Librarian.Import.SevenZip
{
    public class SevenZipFileProvider : AbstractLayeredFileProvider, FileProvider
    {
        protected internal static readonly ICollection capabilities;
        private readonly SevenZipFormat sevenZip;
        private static readonly Dictionary<String, KnownSevenZipFormat> formatMap;
        private readonly List<IFileSystemListener> defaultListeners;

        static SevenZipFileProvider()
        {
            capabilities = new ArrayList(new Capability[] {Capability.GET_LAST_MODIFIED, Capability.GET_TYPE, Capability.LIST_CHILDREN, Capability.READ_CONTENT, Capability.URI, Capability.COMPRESS, Capability.VIRTUAL});
            formatMap = new Dictionary<string, KnownSevenZipFormat>
            {
                {"arj", KnownSevenZipFormat.Arj},
                {"bz2", KnownSevenZipFormat.BZip2},
                {"cab", KnownSevenZipFormat.Cab},
                {"chm", KnownSevenZipFormat.Chm},
                {"cpio", KnownSevenZipFormat.Cpio},
                {"deb", KnownSevenZipFormat.Deb},
                {"gz", KnownSevenZipFormat.GZip},
                {"iso", KnownSevenZipFormat.Iso},
                {"rar", KnownSevenZipFormat.Rar},
                {"rpm", KnownSevenZipFormat.Rpm}, 
                {"sevenzip", KnownSevenZipFormat.SevenZip},
                {"tar", KnownSevenZipFormat.Tar},
                {"zip", KnownSevenZipFormat.Zip},
                {"Z", KnownSevenZipFormat.Z},
            };
        }

        public SevenZipFileProvider()
        {
            sevenZip = new SevenZipFormat(@"other\7z.dll");
            defaultListeners = new List<IFileSystemListener>();
        }

        public override ICollection Capabilities
        {
            get
            {
                return capabilities;
            }
        }

        public virtual void addListener(IFileSystemListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            defaultListeners.Add(listener);
        }

        public virtual void removeListener(IFileSystemListener listener)
        {
            if (listener == null)
            {
                throw new ArgumentNullException("listener");
            }

            defaultListeners.Remove(listener);
        }

        protected override IFileSystem doCreateFileSystem(String scheme, IFileObject file, FileSystemOptions fileSystemOptions)
        {
            if(!formatMap.ContainsKey(scheme))
            {
                throw new FileSystemException(String.Format("Unknown file system scheme: {0}", scheme));
            }

            IInArchive archive = sevenZip.CreateInArchive(SevenZipFormat.GetClassIdFromKnownFormat(formatMap[scheme]));
            if(archive == null)
            {
                throw new FileSystemException("This 7-zip library does not support this archive type.");
            }

            IFileName rootName = new LayeredFileName(scheme, file.Name, FileName_Fields.ROOT_PATH, FileType.FOLDER);

            SevenZipFileSystem fs = new SevenZipFileSystem(archive, rootName, file, fileSystemOptions);
            foreach (IFileSystemListener listener in defaultListeners)
            {
                fs.addListener(listener);
            }

            return fs;
        }
    }
}