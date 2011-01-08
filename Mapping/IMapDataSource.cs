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
using System.Data;


namespace Gremlin.FB2Librarian.Import.Mapping
{
    public interface IMapDataSource
    {
        Type GetFieldType(int index);
        int GetOrdinal(string fieldName);
        bool IsNull(object instance, int index);
        
        bool GetBoolean(object instance, int index);
        byte GetByte(object instance, int index);
        char GetChar(object instance, int index);
        DateTime GetDateTime(object instance, int index);
        decimal GetDecimal(object instance, int index);
        double GetDouble(object instance, int index);
        float GetFloat(object instance, int index);
        Guid GetGuid(object instance, int index);
        short GetInt16(object instance, int index);
        int GetInt32(object instance, int index);
        long GetInt64(object instance, int index);
        string GetString(object instance, int index);

        bool? GetNullableBoolean(object instance, int index);
        byte? GetNullableByte(object instance, int index);
        char? GetNullableChar(object instance, int index);
        DateTime? GetNullableDateTime(object instance, int index);
        decimal? GetNullableDecimal(object instance, int index);
        double? GetNullableDouble(object instance, int index);
        float? GetNullableFloat(object instance, int index);
        Guid? GetNullableGuid(object instance, int index);
        short? GetNullableInt16(object instance, int index);
        int? GetNullableInt32(object instance, int index);
        long? GetNullableInt64(object instance, int index);
    }
}
