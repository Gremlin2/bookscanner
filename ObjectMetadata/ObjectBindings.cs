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

namespace Gremlin.FB2Librarian.Import.ObjectMetadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class TableAttribute : Attribute
    {
        private string tableName; 

        public TableAttribute(string tableName)
        {
            this.tableName = tableName;
        }

        public string TableName
        {
            get
            {
                return this.tableName;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ColumnAttribute : Attribute
    {
        private string columnName; 
        private DbType columnType = DbType.Object; 
        private bool nullable; 
        private bool isAutoIncrement;

        public ColumnAttribute(string columnName)
        {
            this.columnName = columnName;
        }
        
        public ColumnAttribute(string columnName, DbType columnType, bool nullable, bool isAutoIncrement)
        {
            this.columnName = columnName;
            this.columnType = columnType;
            this.nullable = nullable;
            this.isAutoIncrement = isAutoIncrement;
        }

        /// <summary>
        /// Specifies whether the column is nullable
        /// </summary>
        public bool Nullable
        {
            get
            {
                return nullable;
            }
        }

        /// <summary>
        /// The name of the column that this attribute describes
        /// </summary>
        public string ColumnName
        {
            get
            {
                return columnName;
            }
        }

        /// <summary>
        /// The type of the column that this attribute describes
        /// </summary>
        public DbType ColumnType
        {
            get
            {
                return columnType;
            }
        }

        public bool IsAutoIncrement
        {
            get
            {
                return isAutoIncrement;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute()
        {
        }
    }
}