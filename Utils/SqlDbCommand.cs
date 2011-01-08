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

using Gremlin.FB2Librarian.Import.Mapping;
using Gremlin.FB2Librarian.Import.ObjectMetadata;

namespace Gremlin.FB2Librarian.Import.Utils
{
    public class SqlDbCommand : IDbCommand
    {
        private readonly IDbCommand command;

        internal SqlDbCommand(IDbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            this.command = command;
        }

        public void Cancel()
        {
            this.command.Cancel();
        }

        public string CommandText
        {
            get
            {
                return this.command.CommandText;
            }
            set
            {
                this.command.CommandText = value;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return this.command.CommandTimeout;
            }
            set
            {
                this.command.CommandTimeout = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return this.command.CommandType;
            }
            set
            {
                this.command.CommandType = value;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return this.command.Connection;
            }
            set
            {
                this.command.Connection = value;
            }
        }

        public IDbDataParameter CreateParameter()
        {
            return this.command.CreateParameter();
        }

        public int ExecuteNonQuery()
        {
            return this.command.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return this.command.ExecuteReader(behavior);
        }

        public IDataReader ExecuteReader()
        {
            return this.command.ExecuteReader();
        }

        public object ExecuteScalar()
        {
            return this.command.ExecuteScalar();
        }

        public IDataParameterCollection Parameters
        {
            get
            {
                return this.command.Parameters;
            }
        }

        public void Prepare()
        {
            this.command.Prepare();
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.command.Transaction;
            }
            set
            {
                this.command.Transaction = value;
            }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get
            {
                return this.command.UpdatedRowSource;
            }
            set
            {
                this.command.UpdatedRowSource = value;
            }
        }

        public void Dispose()
        {
            this.command.Dispose();            
        }
        
        public T ExecuteScalar<T>()
        {
            T instance = default(T);
            
            IDataReader reader = this.command.ExecuteReader(CommandBehavior.SingleRow);

            if(reader.FieldCount <= 0)
            {
                throw new InvalidOperationException("");
            }
           
            try
            {
                DataReaderSource source = new DataReaderSource(reader);

                if (reader.Read())
                {
                    Type readerDataType = reader.GetFieldType(0);
                    IScalarDataMapper<T> mapper = ScalarTypeMapper.GetMapper<T>(readerDataType, typeof(T));
                    if (mapper != null)
                    {
                        instance = mapper.Map(source, reader, 0);
                    }
                }
            }
            finally
            {
                reader.Close();
            }            
            
            return instance;
        }
        
        public List<T> ExecuteScalarList<T>()
        {
            List<T> list;

            IDataReader reader = this.command.ExecuteReader(CommandBehavior.SingleResult);

            if (reader.FieldCount <= 0)
            {
                throw new InvalidOperationException("");
            }

            try
            {
                list = new List<T>();
                
                DataReaderSource source = new DataReaderSource(reader);
                Type readerDataType = reader.GetFieldType(0);
                IScalarDataMapper<T> mapper = ScalarTypeMapper.GetMapper<T>(readerDataType, typeof(T));

                while (reader.Read())
                {
                    T instance = default(T);

                    if (mapper != null)
                    {
                        instance = mapper.Map(source, reader, 0);
                    }

                    list.Add(instance);
                }
            }
            finally
            {
                reader.Close();
            }            

            return list;
        }
        
        public T ExecuteObject<T>() where T : class, new()
        {
            EntityInfo entityInfo = MetadataCache.Metadata.GetEntityInfo(typeof(T));

            if (entityInfo == null)
            {
                throw new InvalidOperationException("");
            }
            
            T instance = null;

            IDataReader reader = this.command.ExecuteReader(CommandBehavior.SingleRow);

            try
            {
                DataReaderSource source = new DataReaderSource(reader);
                ObjectDataSource destination = new ObjectDataSource(entityInfo);
                
                while (reader.Read())
                {
                    instance = new T();

                    for (int index = 0; index < reader.FieldCount; index++)
                    {
                        Type readerDataType = reader.GetFieldType(index);
                        
                        int destinationIndex = destination.GetOrdinal(reader.GetName(index));

                        if (destinationIndex >= 0)
                        {
                            IDataMapper mapper = TypeMapper.GetMapper(readerDataType, entityInfo.Fields[destinationIndex].PropertyType);
                            if (mapper != null)
                            {
                                mapper.Map(source, reader, index, destination, instance, destinationIndex);
                            }
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }            

            return instance;
        }
        
        public List<T> ExecuteList<T>() where T : class, new()
        {
            EntityInfo entityInfo = MetadataCache.Metadata.GetEntityInfo(typeof(T));

            if(entityInfo == null)
            {
                throw new InvalidOperationException("");
            }
            
            List<T> list;

            IDataReader reader = this.command.ExecuteReader(CommandBehavior.SingleResult);
            try
            {
                DataReaderSource source = new DataReaderSource(reader);
                ObjectDataSource destination = new ObjectDataSource(entityInfo);
                list = new List<T>();

                int[] destinationMap = new int[reader.FieldCount];
                DataMapper[] mappers = new DataMapper[entityInfo.Fields.Count];

                int index;
                for (index = 0; index < reader.FieldCount; index++)
                {
                    int destinationIndex = destination.GetOrdinal(reader.GetName(index));
                    destinationMap[index] = destinationIndex;
                    
                    if (destinationIndex >= 0)
                    {
                        mappers[destinationIndex] = TypeMapper.GetMapper(reader.GetFieldType(index), entityInfo.Fields[destinationIndex].PropertyType);
                    }
                }
                
                InstantiateObjectHandler createObjectHandler = DynamicMethodCompiler.CreateInstantiateObjectHandler(typeof(T));

                int fieldCount = reader.FieldCount;
                
                while (reader.Read())
                {
                    T instance = createObjectHandler() as T;

                    for (index = 0; index < fieldCount; index++)
                    {
                        int destinationIndex = destinationMap[index];

                        if (destinationIndex >= 0)
                        {
                            DataMapper mapper = mappers[destinationIndex];

                            if (mapper != null)
                            {
                                mapper.Map(source, reader, index, destination, instance, destinationIndex);
                            }
                        }
                    }

                    list.Add(instance);
                }
            }
            finally
            {
                reader.Close();
            }

            return list;
        }
    }
}
