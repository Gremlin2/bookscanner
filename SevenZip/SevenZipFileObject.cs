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
using System.Collections.Generic;
using System.IO;

using Gremlin.FB2Librarian.Import.Utils;

using VirtualFileSystem;
using VirtualFileSystem.Provider;

namespace Gremlin.FB2Librarian.Import.SevenZip
{
    public class SevenZipFileObject : AbstractFileObject
    {
        private readonly Set<string> children = new Set<string>();
        private SevenZipFileSystem fs;
        private FileType type;
        private uint index;

        private long fileSize;
        private DateTime fileDate;

        public SevenZipFileObject(IFileName name, uint index, SevenZipFileSystem fs, bool fileExists) : base(name, fs)
        {
            this.fs = fs;
            this.Index = index;

            if (!fileExists)
            {
                type = FileType.IMAGINARY;
            }
        }

        internal uint Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
                if(index == UInt32.MaxValue)
                {
                    type = FileType.FOLDER;
                    return;
                }

                IInArchive archive = fs.Archive;

                PropVariant isFolderProperty = new PropVariant();
                archive.GetProperty(index, ItemPropId.kpidIsFolder, ref isFolderProperty);

                if((bool) isFolderProperty.GetObject())
                {
                    type = FileType.FOLDER;
                }
                else
                {
                    type = FileType.FILE;
                }

                PropVariant sizeProperty = new PropVariant();
                archive.GetProperty(index, ItemPropId.kpidSize, ref sizeProperty);

                fileSize = sizeProperty.longValue;

                PropVariant lastWriteTimeProperty = new PropVariant();
                archive.GetProperty(index, ItemPropId.kpidLastWriteTime, ref lastWriteTimeProperty);

                DateTime now = DateTime.Now;
                TimeSpan localOffset = now - now.ToUniversalTime();
                fileDate = DateTime.FromFileTimeUtc(lastWriteTimeProperty.longValue) + localOffset;
            }
        }

        public void attachChild(IFileName childName)
        {
            children.Add(childName.BaseName);
        }

        public override bool Writeable
        {
            get
            {
                return false;
            }
        }

        protected override FileType doGetType()
        {
            return type;
        }

        protected override IEnumerator<string> doListChildren()
        {
            foreach (string child in children)
            {
                yield return child;
            }
        }

        protected override long doGetContentSize()
        {
            return fileSize;
        }

        protected override long doGetLastModifiedTime()
        {
            return fileDate.Ticks;
        }

        protected override Stream doGetInputStream()
        {
            return fs.GetInputStream(index);
        }
    }
}