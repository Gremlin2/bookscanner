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
using System.Text;
using Gremlin.FB2Librarian.Import.ObjectMetadata;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("VERINFO")]
    public class DatabaseInfo
    {
        private string version;
        private short workMode;
        private string mountPoint;
        private string namingPattern;
        private int currentUserId;
        private string currentUserName;

        [Column("VERSION")]
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        [Column("MODE")]
        public short WorkMode
        {
            get
            {
                return this.workMode;
            }
            set
            {
                this.workMode = value;
            }
        }

        [Column("MOUNT")]
        public string MountPoint
        {
            get
            {
                return this.mountPoint;
            }
            set
            {
                this.mountPoint = value;
            }
        }

        [Column("FILENAMINGPATTERN")]
        public string NamingPattern
        {
            get
            {
                return this.namingPattern;
            }
            set
            {
                this.namingPattern = value;
            }
        }

        public int CurrentUserId
        {
            get
            {
                return this.currentUserId;
            }
            set
            {
                this.currentUserId = value;
            }
        }

        public string CurrentUserName
        {
            get
            {
                return this.currentUserName;
            }
            set
            {
                this.currentUserName = value;
            }
        }
    }
}
