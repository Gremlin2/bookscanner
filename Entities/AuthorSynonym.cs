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
using System.Data;

using Gremlin.FB2Librarian.Import.ObjectMetadata;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("AUTOR_SYNONIMS")]
    public class AuthorSynonym
    {
        private int? id;
        private int authorId;
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private bool visible;

        [Column("ID", DbType.Int32, true, true)]
        public int? Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [Column("AUTORID", DbType.Int32, false, false)]
        public int AuthorId
        {
            get
            {
                return this.authorId;
            }
            set
            {
                this.authorId = value;
            }
        }

        [Column("FIRSTNAME")]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        [Column("MIDNAME")]
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
            }
        }

        [Column("LASTNAME")]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        [Column("NICKNAME")]
        public string NickName
        {
            get
            {
                return this.nickName;
            }
            set
            {
                this.nickName = value;
            }
        }

        [Column("INLIST", DbType.Boolean, false, false)]
        public bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
            }
        }
    }
}