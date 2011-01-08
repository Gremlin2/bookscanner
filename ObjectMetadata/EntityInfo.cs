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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Gremlin.FB2Librarian.Import.ObjectMetadata
{
    public sealed class AttributeInfoCollection : KeyedCollection<string, AttributeInfo>
    {
        public AttributeInfoCollection() : base(StringComparer.InvariantCultureIgnoreCase)
        {
        }
        
        protected override string GetKeyForItem(AttributeInfo item)
        {
            return item.ColumnName;
        }
    }

    [Serializable()]
    internal sealed class EntityInfo
    {
        private string tableName;
        private AttributeInfoCollection fields;
        private List<AttributeInfo> keyFields;
        private List<AttributeInfo> autoIncFields;

        /// <summary>
        ///   Initializes a new instance of <see cref='EntityInfo'/>.
        /// </summary>
        public EntityInfo()
        {
            this.fields = new AttributeInfoCollection();
            this.keyFields = new List<AttributeInfo>();
            this.autoIncFields = new List<AttributeInfo>();
        }

        public string Tablename
        {
            set
            {
                this.tableName = value;
            }

            get
            {
                return this.tableName;
            }
        }

        public AttributeInfoCollection Fields
        {
            get
            {
                return this.fields;
            }
        }

        public List<AttributeInfo> KeyFields
        {
            get
            {
                return this.keyFields;
            }
        }

        public List<AttributeInfo> AutoIncFields
        {
            get
            {
                return this.autoIncFields;
            }
        }

        public int GetOrdinal(string fieldName)
        {
            if (this.fields.Contains(fieldName))
            {
                return this.fields[fieldName].ColumnIndex;
            }
            else if (this.fields.Contains(String.Concat(this.tableName, ".", fieldName)))
            {
                return this.fields[String.Concat(this.tableName, ".", fieldName)].ColumnIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}
