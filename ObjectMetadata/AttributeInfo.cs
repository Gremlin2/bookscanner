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
using System.Data;
using System.Reflection;

namespace Gremlin.FB2Librarian.Import.ObjectMetadata
{
    /// <summary>
    /// Description of AttributeInfo.
    /// </summary>
    public sealed class AttributeInfo
    {
        private int columnIndex;
        private string columnName;
        private DbType columnType;
        private bool primaryKey;
        private bool autoIncrement;
        private bool nullable;
        private PropertyInfo property;
        private Type propertyType;
        
        private SetHandler setPropertyHandler;    
        private object syncRoot = new object();
        
        public AttributeInfo()
        {
            this.columnIndex = 0;
            this.columnName = "";
            this.columnType = DbType.Object;
            this.primaryKey = false;
            this.autoIncrement = false;
            this.nullable = true;
            this.property = null;
            this.setPropertyHandler = null;            
        }

        public int ColumnIndex
        {
            set
            {
                this.columnIndex = value;
            }

            get
            {
                return this.columnIndex;
            }
        }

        public string ColumnName
        {
            set
            {
                this.columnName = value;
            }

            get
            {
                return this.columnName;
            }
        }

        public DbType ColumnType
        {
            set
            {
                this.columnType = value;
            }

            get
            {
                return this.columnType;
            }
        }

        public bool PrimaryKey
        {
            set
            {
                this.primaryKey = value;
            }

            get
            {
                return this.primaryKey;
            }
        }

        public bool AutoIncrement
        {
            set
            {
                this.autoIncrement = value;
            }

            get
            {
                return this.autoIncrement;
            }
        }

        public bool Nullable
        {
            set
            {
                this.nullable = value;
            }

            get
            {
                return this.nullable;
            }
        }

        public PropertyInfo Property
        {
            set
            {
                this.property = value;
            }

            get
            {
                return this.property;
            }
        }
        
        public Type PropertyType
        {
            get
            {
                return this.propertyType;
            }
            
            set
            {
                this.propertyType = value;
            }
        }
        
        public SetHandler SetPropertyHandler
        {
            get
            {
                if(this.setPropertyHandler == null)
                {
                    lock(this.syncRoot)
                    {
                        if(this.setPropertyHandler == null)
                        {
                            this.setPropertyHandler = DynamicMethodCompiler.CreateSetHandler(this.propertyType, this.property);
                        }
                    }
                }

                return this.setPropertyHandler;
            }
        }
    }
}