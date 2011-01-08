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
using Gremlin.FB2Librarian.Import.ObjectMetadata;

namespace Gremlin.FB2Librarian.Import.Mapping
{
    internal class ObjectDataSource : IMapDataSource, IMapDataDestination
    {
        private EntityInfo entityInfo;
        private AttributeInfo[] attributes;
        
        public ObjectDataSource(EntityInfo entityInfo)
        {
            if(entityInfo == null)
            {
                throw new ArgumentNullException("entityInfo");
            }

            this.entityInfo = entityInfo;
            this.attributes = new AttributeInfo[this.entityInfo.Fields.Count];
            this.entityInfo.Fields.CopyTo(this.attributes, 0);
        }

        public Type GetFieldType(int index)
        {
            AttributeInfo attributeInfo = this.entityInfo.Fields[index];

            return attributeInfo.PropertyType;
        }

        public int GetOrdinal(string fieldName)
        {
            return this.entityInfo.GetOrdinal(fieldName);
        }

        public bool IsNull(object instance, int index)
        {
            return (GetObjectValue<object>(instance, index) == null);
        }
        
        protected virtual void SetObjectValue<T>(object instance, int index, T value)
        {
            if(instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            
            //AttributeInfo attributeInfo = this.entityInfo.Fields[index];
            AttributeInfo attributeInfo = this.attributes[index];
            PropertyInfo propertyInfo = attributeInfo.Property;
            
            if(!propertyInfo.CanWrite)
            {
                throw new InvalidOperationException("Can't assign value to read-only property.");
            }

            attributeInfo.SetPropertyHandler(instance, value);
            
            //propertyInfo.SetValue(instance, value, BindingFlags.SetProperty, null, null, CultureInfo.CurrentCulture);
        }

        protected virtual T GetObjectValue<T>(object instance, int index)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            AttributeInfo attributeInfo = this.entityInfo.Fields[index];
            PropertyInfo propertyInfo = attributeInfo.Property;

            if (!propertyInfo.CanRead)
            {
                throw new InvalidOperationException("Can't read value form write-only property.");
            }

            return (T) propertyInfo.GetValue(instance, BindingFlags.GetProperty, null, null, CultureInfo.CurrentCulture);
        }
        
        public void SetBoolean(object instance, int index, bool value)
        {
            SetObjectValue<Boolean>(instance, index, value);
        }

        public void SetByte(object instance, int index, byte value)
        {
            SetObjectValue<Byte>(instance, index, value);
        }

        public void SetChar(object instance, int index, char value)
        {
            SetObjectValue<Char>(instance, index, value);
        }

        public void SetDateTime(object instance, int index, DateTime value)
        {
            SetObjectValue<DateTime>(instance, index, value);
        }

        public void SetDecimal(object instance, int index, decimal value)
        {
            SetObjectValue<decimal>(instance, index, value);
        }

        public void SetDouble(object instance, int index, double value)
        {
            SetObjectValue<double>(instance, index, value);
        }

        public void SetFloat(object instance, int index, float value)
        {
            SetObjectValue<float>(instance, index, value);
        }

        public void SetGuid(object instance, int index, Guid value)
        {
            SetObjectValue<Guid>(instance, index, value);
        }

        public void SetInt16(object instance, int index, short value)
        {
            SetObjectValue<short>(instance, index, value);
        }

        public void SetInt32(object instance, int index, int value)
        {
            SetObjectValue<int>(instance, index, value);
        }

        public void SetInt64(object instance, int index, long value)
        {
            SetObjectValue<long>(instance, index, value);
        }

        public void SetString(object instance, int index, string value)
        {
            SetObjectValue<string>(instance, index, value);
        }

        public void SetNullableBoolean(object instance, int index, bool? value)
        {
            SetObjectValue<bool?>(instance, index, value);
        }

        public void SetNullableByte(object instance, int index, byte? value)
        {
            SetObjectValue<byte?>(instance, index, value);
        }

        public void SetNullableChar(object instance, int index, char? value)
        {
            SetObjectValue<char?>(instance, index, value);
        }

        public void SetNullableDateTime(object instance, int index, DateTime? value)
        {
            SetObjectValue<DateTime?>(instance, index, value);
        }

        public void SetNullableDecimal(object instance, int index, decimal? value)
        {
            SetObjectValue<decimal?>(instance, index, value);
        }

        public void SetNullableDouble(object instance, int index, double? value)
        {
            SetObjectValue<double?>(instance, index, value);
        }

        public void SetNullableFloat(object instance, int index, float? value)
        {
            SetObjectValue<float?>(instance, index, value);
        }

        public void SetNullableGuid(object instance, int index, Guid? value)
        {
            SetObjectValue<Guid?>(instance, index, value);
        }

        public void SetNullableInt16(object instance, int index, short? value)
        {
            SetObjectValue<short?>(instance, index, value);
        }

        public void SetNullableInt32(object instance, int index, int? value)
        {
            SetObjectValue<int?>(instance, index, value);
        }

        public void SetNullableInt64(object instance, int index, long? value)
        {
            SetObjectValue<long?>(instance, index, value);
        }

        public bool GetBoolean(object instance, int index)
        {
            return GetObjectValue<Boolean>(instance, index);
        }

        public byte GetByte(object instance, int index)
        {
            return GetObjectValue<Byte>(instance, index);
        }

        public char GetChar(object instance, int index)
        {
            return GetObjectValue<Char>(instance, index);
        }

        public DateTime GetDateTime(object instance, int index)
        {
            return GetObjectValue<DateTime>(instance, index);
        }

        public decimal GetDecimal(object instance, int index)
        {
            return GetObjectValue<Decimal>(instance, index);
        }

        public double GetDouble(object instance, int index)
        {
            return GetObjectValue<Double>(instance, index);
        }

        public float GetFloat(object instance, int index)
        {
            return GetObjectValue<float>(instance, index);
        }

        public Guid GetGuid(object instance, int index)
        {
            return GetObjectValue<Guid>(instance, index);
        }

        public short GetInt16(object instance, int index)
        {
            return GetObjectValue<short>(instance, index);
        }

        public int GetInt32(object instance, int index)
        {
            return GetObjectValue<int>(instance, index);
        }

        public long GetInt64(object instance, int index)
        {
            return GetObjectValue<long>(instance, index);
        }

        public string GetString(object instance, int index)
        {
            return GetObjectValue<string>(instance, index);
        }

        public bool? GetNullableBoolean(object instance, int index)
        {
            return GetObjectValue<bool?>(instance, index);
        }

        public byte? GetNullableByte(object instance, int index)
        {
            return GetObjectValue<byte?>(instance, index);
        }

        public char? GetNullableChar(object instance, int index)
        {
            return GetObjectValue<char?>(instance, index);
        }

        public DateTime? GetNullableDateTime(object instance, int index)
        {
            return GetObjectValue<DateTime?>(instance, index);
        }

        public decimal? GetNullableDecimal(object instance, int index)
        {
            return GetObjectValue<decimal?>(instance, index);
        }

        public double? GetNullableDouble(object instance, int index)
        {
            return GetObjectValue<double?>(instance, index);
        }

        public float? GetNullableFloat(object instance, int index)
        {
            return GetObjectValue<float?>(instance, index);
        }

        public Guid? GetNullableGuid(object instance, int index)
        {
            return GetObjectValue<Guid?>(instance, index);
        }

        public short? GetNullableInt16(object instance, int index)
        {
            return GetObjectValue<short?>(instance, index);
        }

        public int? GetNullableInt32(object instance, int index)
        {
            return GetObjectValue<int?>(instance, index);
        }

        public long? GetNullableInt64(object instance, int index)
        {
            return GetObjectValue<long?>(instance, index);
        }
    }
}
