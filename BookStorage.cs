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
using System.IO;

using Gremlin.FB2Librarian.Import.Entities;
using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import
{
    public class BookStorage
    {
        private readonly FileNameProvider provider;
        private readonly string mountPoint;

        public BookStorage(DatabaseInfo databaseInfo)
        {
            if (databaseInfo == null)
            {
                throw new ArgumentNullException("databaseInfo");
            }

            provider = new FileNameProvider(databaseInfo.NamingPattern);
            mountPoint = databaseInfo.MountPoint;
        }

        public FileNameProvider Provider
        {
            get
            {
                return this.provider;
            }
        }

        public string MountPoint
        {
            get
            {
                return this.mountPoint;
            }
        }

        private string GetFilename(FictionBook fictionBook)
        {
            string filename = this.provider.GetFileName(fictionBook);
            filename = StringUtils.Dirify(filename, false);

            string separator = Path.DirectorySeparatorChar.ToString();
            while (filename.StartsWith(separator))
            {
                filename = filename.Substring(1);
            }

            filename = StringUtils.Squeeze(filename, Path.DirectorySeparatorChar);

            return filename;
        }

    }
}