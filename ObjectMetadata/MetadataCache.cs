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
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Gremlin.FB2Librarian.Import.ObjectMetadata
{
    internal sealed class MetadataCache
    {
        private static volatile MetadataCache instance = null;
        private static object instanceLock = new object();

        private Dictionary<Type, EntityInfo> cache;
        private object cacheLock = new object();
        
        private MetadataCache()
        {
            this.cache = new Dictionary<Type, EntityInfo>(10);
        }
        
        public static MetadataCache Metadata
        {
            get
            {
                if (instance == null)
                {
                    lock(instanceLock)
                    {
                        if(instance == null)
                        {
                            instance = new MetadataCache();
                        }
                    }
                }
                return instance;
            }
        }
        
        private EntityInfo CreateEntityInfo(Type entityType)
        {
			EntityInfo entityInfo = null;
            
			foreach(Attribute attribute in entityType.GetCustomAttributes(typeof(TableAttribute), false))
			{
				TableAttribute tableAttribute = attribute as TableAttribute;
                entityInfo = new EntityInfo();
				entityInfo.Tablename = tableAttribute.TableName;
			}
            
            if (entityInfo != null)
            {
                foreach (PropertyInfo propertyInfo in entityType.GetProperties())
                {
                    AttributeInfo columnMetadata = null;

                    foreach (Attribute attribute in propertyInfo.GetCustomAttributes(false))
                    {
                        if (attribute.GetType() == typeof(ColumnAttribute))
                        {
                            ColumnAttribute columnAttribute = attribute as ColumnAttribute;
                            if (columnMetadata == null)
                            {
                                columnMetadata = new AttributeInfo();
                            }

                            columnMetadata.Property = propertyInfo;
                            columnMetadata.ColumnName = columnAttribute.ColumnName;
                            columnMetadata.ColumnType = columnAttribute.ColumnType;
                            columnMetadata.Nullable = columnMetadata.PrimaryKey ? false : columnAttribute.Nullable;
                            columnMetadata.AutoIncrement = columnAttribute.IsAutoIncrement;
                            columnMetadata.PropertyType = propertyInfo.PropertyType;
                        }
                        else if (attribute.GetType() == typeof(PrimaryKeyAttribute))
                        {
                            if (columnMetadata == null)
                            {
                                columnMetadata = new AttributeInfo();
                            }

                            columnMetadata.Nullable = false;
                            columnMetadata.PrimaryKey = true;
                        }
                    }

                    if (columnMetadata != null && !String.IsNullOrEmpty(columnMetadata.ColumnName))
                    {
                        columnMetadata.ColumnIndex = entityInfo.Fields.Count;
                        entityInfo.Fields.Add(columnMetadata);
                    }
                }
            }
            
            return entityInfo;
        }
        
        internal EntityInfo GetEntityInfo(Type typeInfo)
        {
            EntityInfo entityInfo;
            
            if(typeInfo == null)
            {
                throw new ArgumentNullException("typeInfo");
            }
            
            lock(this.cacheLock)
            {
                if(this.cache.ContainsKey(typeInfo))
                {
                    entityInfo = this.cache[typeInfo];
                }
                else
                {
                    entityInfo = CreateEntityInfo(typeInfo);
                    this.cache.Add(typeInfo, entityInfo);
                }
            }

            return entityInfo;
        }
    }
}
