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

namespace Gremlin.FB2Librarian.Import.Mapping
{
    public class DataReaderSource : IMapDataSource
    {
        private IDataReader reader;
        
        public DataReaderSource(IDataReader dataReader)
        {
            if(dataReader == null)
            {
                throw new ArgumentNullException("dataReader");
            }

            this.reader = dataReader;
        }

        public Type GetFieldType(int index)
        {
            return reader.GetFieldType(index);
        }

        public int GetOrdinal(string fieldName)
        {
            return reader.GetOrdinal(fieldName);
        }

        public bool IsNull(object instance, int index)
        {
            return reader.IsDBNull(index);
        }
        
        public bool GetBoolean(object instance, int index)
        {
            return this.reader.GetBoolean(index);
        }

        public byte GetByte(object instance, int index)
        {
            return this.reader.GetByte(index);
        }

        public char GetChar(object instance, int index)
        {
            return this.reader.GetChar(index);
        }

        public DateTime GetDateTime(object instance, int index)
        {
            return this.reader.GetDateTime(index);
        }

        public decimal GetDecimal(object instance, int index)
        {
            return this.reader.GetDecimal(index);
        }

        public double GetDouble(object instance, int index)
        {
            return this.reader.GetDouble(index);
        }

        public float GetFloat(object instance, int index)
        {
            return this.reader.GetFloat(index);
        }

        public Guid GetGuid(object instance, int index)
        {
            return this.reader.GetGuid(index);
        }

        public short GetInt16(object instance, int index)
        {
            return this.reader.GetInt16(index);
        }

        public int GetInt32(object instance, int index)
        {
            return this.reader.GetInt32(index);
        }

        public long GetInt64(object instance, int index)
        {
            return this.reader.GetInt64(index);
        }

        public string GetString(object instance, int index)
        {
            return this.reader.GetString(index);
        }

        public bool? GetNullableBoolean(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (bool?)null : this.reader.GetBoolean(index));
        }

        public byte? GetNullableByte(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (byte?)null : this.reader.GetByte(index));
        }

        public char? GetNullableChar(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (char?)null : this.reader.GetChar(index));
        }

        public DateTime? GetNullableDateTime(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (DateTime?)null : this.reader.GetDateTime(index));
        }

        public decimal? GetNullableDecimal(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (decimal?)null : this.reader.GetDecimal(index));
        }

        public double? GetNullableDouble(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (double?)null : this.reader.GetDouble(index));
        }

        public float? GetNullableFloat(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (float?)null : this.reader.GetFloat(index));
        }

        public Guid? GetNullableGuid(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (Guid?)null : this.reader.GetGuid(index));
        }

        public short? GetNullableInt16(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (short?)null : this.reader.GetInt16(index));
        }

        public int? GetNullableInt32(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (int?)null : this.reader.GetInt32(index));
        }

        public long? GetNullableInt64(object instance, int index)
        {
            return (this.reader.IsDBNull(index) ? (long?)null : this.reader.GetInt64(index));
        }
    }
}
