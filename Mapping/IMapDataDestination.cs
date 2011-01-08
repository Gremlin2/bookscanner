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

namespace Gremlin.FB2Librarian.Import.Mapping
{
    public interface IMapDataDestination
    {
        Type GetFieldType(int index);
        int GetOrdinal(string fieldName);
        
        void SetBoolean(object instance, int index, bool value);
        void SetByte(object instance, int index, byte value);
        void SetChar(object instance, int index, char value);
        void SetDateTime(object instance, int index, DateTime value);
        void SetDecimal(object instance, int index, decimal value);
        void SetDouble(object instance, int index, double value);
        void SetFloat(object instance, int index, float value);
        void SetGuid(object instance, int index, Guid value);
        void SetInt16(object instance, int index, short value);
        void SetInt32(object instance, int index, int value);
        void SetInt64(object instance, int index, long value);
        void SetString(object instance, int index, string value);

        void SetNullableBoolean(object instance, int index, bool? value);
        void SetNullableByte(object instance, int index, byte? value);
        void SetNullableChar(object instance, int index, char? value);
        void SetNullableDateTime(object instance, int index, DateTime? value);
        void SetNullableDecimal(object instance, int index, decimal? value);
        void SetNullableDouble(object instance, int index, double? value);
        void SetNullableFloat(object instance, int index, float? value);
        void SetNullableGuid(object instance, int index, Guid? value);
        void SetNullableInt16(object instance, int index, short? value);
        void SetNullableInt32(object instance, int index, int? value);
        void SetNullableInt64(object instance, int index, long? value);
    
    }
}
