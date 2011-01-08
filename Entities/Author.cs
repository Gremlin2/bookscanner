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
using System.Data;
using System.Text;

using Gremlin.FB2Librarian.Import.ObjectMetadata;
using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("AUTOR")]
    public class Author : IEquatable<Author>, IMetrizable<Author>
    {
        private int? id;
        private string libraryId;
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private string email;
        private string homepage;

        private bool dirtyFlag;
        private string displayName;

        public Author()
        {
            this.dirtyFlag = true;
        }

        [Column("AUTORID", DbType.Int32, true, true)]
        public int? Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.dirtyFlag = true;
            }
        }

        [Column("LIBRARY_ID")]
        public string LibraryId
        {
            get
            {
                return this.libraryId;
            }
            set
            {
                this.libraryId = value;
                this.dirtyFlag = true;
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
                this.dirtyFlag = true;
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
                this.dirtyFlag = true;
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
                this.dirtyFlag = true;
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
                this.dirtyFlag = true;
            }
        }

        [Column("EMAIL")]
        public string EMail
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        [Column("HOMEPAGE")]
        public string Homepage
        {
            get
            {
                return this.homepage;
            }
            set
            {
                this.homepage = value;
            }
        }

        public string DisplayName
        {
            get
            {
                if (this.dirtyFlag)
                {
                    if (!String.IsNullOrEmpty(this.firstName) && !String.IsNullOrEmpty(this.lastName))
                    {
                        this.displayName = String.Format("{0}, {1} {2}", this.lastName, this.firstName, this.middleName).Trim();
                    }
                    else if (String.IsNullOrEmpty(this.firstName) && !String.IsNullOrEmpty(this.lastName))
                    {
                        this.displayName = this.lastName.Trim();
                    }
                    else if (!String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName))
                    {
                        this.displayName = String.Format("{0} {1}", this.firstName, this.middleName).Trim();
                    }
                    else if (String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName) && !String.IsNullOrEmpty(this.middleName))
                    {
                        this.displayName = this.middleName.Trim();
                    }
                    else if (String.IsNullOrEmpty(this.firstName) && String.IsNullOrEmpty(this.lastName) && !String.IsNullOrEmpty(this.nickName))
                    {
                        this.displayName = this.nickName.Trim();
                    }
                    else
                    {
                        this.displayName = "-";
                    }

                    this.dirtyFlag = false;
                }

                return this.displayName;
            }
        }

        public int DistanceTo(Author other)
        {
            return StringUtils.DamerauLevenshteinDistance(DisplayName, other.DisplayName);
        }

        public override string ToString()
        {
            return this.DisplayName;
        }

        public bool Equals(Author author)
        {
            if (author == null)
            {
                return false;
            }

            if (!Equals(id, author.id))
            {
                return false;
            }

            if (!Equals(libraryId, author.libraryId))
            {
                return false;
            }

            if (!Equals(firstName, author.firstName))
            {
                return false;
            }

            if (!Equals(middleName, author.middleName))
            {
                return false;
            }

            if (!Equals(lastName, author.lastName))
            {
                return false;
            }

            if (!Equals(nickName, author.nickName))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals(obj as Author);
        }

        public override int GetHashCode()
        {
            int result = id.GetHashCode();

            result = 29 * result + (libraryId != null ? libraryId.GetHashCode() : 0);
            result = 29 * result + (firstName != null ? firstName.GetHashCode() : 0);
            result = 29 * result + (middleName != null ? middleName.GetHashCode() : 0);
            result = 29 * result + (lastName != null ? lastName.GetHashCode() : 0);
            result = 29 * result + (nickName != null ? nickName.GetHashCode() : 0);
            
            return result;
        }
    }
}
