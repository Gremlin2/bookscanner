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

namespace Gremlin.FB2Librarian.Import.Mapping
{
	internal class ScalarTypeMapper
	{
		internal class BooleanToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return source.GetBoolean(sourceObject, sourceIndex);
				}
			}
		}

		internal class BooleanToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class BooleanToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetByte(sourceObject, sourceIndex);
				}
			}
		}

		internal class ByteToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class ByteToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return source.GetChar(sourceObject, sourceIndex);
				}
			}
		}

		internal class CharToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class CharToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return source.GetDateTime(sourceObject, sourceIndex);
				}
			}
		}

		internal class DateTimeToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DateTimeToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetDecimal(sourceObject, sourceIndex);
				}
			}
		}

		internal class DecimalToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DecimalToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetDouble(sourceObject, sourceIndex);
				}
			}
		}

		internal class DoubleToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class DoubleToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetFloat(sourceObject, sourceIndex);
				}
			}
		}

		internal class SingleToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class SingleToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetInt16(sourceObject, sourceIndex);
				}
			}
		}

		internal class Int16ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int16ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetInt32(sourceObject, sourceIndex);
				}
			}
		}

		internal class Int32ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int32ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return source.GetInt64(sourceObject, sourceIndex);
				}
			}
		}

		internal class Int64ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class Int64ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetString(sourceObject, sourceIndex);
				}
			}
		}

		internal class StringToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class StringToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableBoolean(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableBooleanToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableBooleanToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableByte(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableByteToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableByteToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableChar(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableCharToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableCharToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableDateTime(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableDateTimeToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDateTimeToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableDecimal(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableDecimalToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDecimalToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableDouble(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableDoubleToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableDoubleToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableFloat(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableSingleToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableSingleToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableInt16(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableInt16ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt16ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt32ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableInt32(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableInt32ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToBooleanMapper : IScalarDataMapper<Boolean>
		{
			public Boolean Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return false;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToByteMapper : IScalarDataMapper<Byte>
		{
			public Byte Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToCharMapper : IScalarDataMapper<Char>
		{
			public Char Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return '\0';
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToDateTimeMapper : IScalarDataMapper<DateTime>
		{
			public DateTime Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return DateTime.MinValue;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToDecimalMapper : IScalarDataMapper<Decimal>
		{
			public Decimal Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToDoubleMapper : IScalarDataMapper<Double>
		{
			public Double Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToSingleMapper : IScalarDataMapper<Single>
		{
			public Single Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToInt16Mapper : IScalarDataMapper<Int16>
		{
			public Int16 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToInt32Mapper : IScalarDataMapper<Int32>
		{
			public Int32 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToInt64Mapper : IScalarDataMapper<Int64>
		{
			public Int64 Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return 0;
				}
				else
				{
					return Convert.ToInt64(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToStringMapper : IScalarDataMapper<String>
		{
			public String Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToString(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableBooleanMapper : IScalarDataMapper<Nullable<Boolean>>
		{
			public Nullable<Boolean> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToBoolean(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableByteMapper : IScalarDataMapper<Nullable<Byte>>
		{
			public Nullable<Byte> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToByte(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableCharMapper : IScalarDataMapper<Nullable<Char>>
		{
			public Nullable<Char> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToChar(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableDateTimeMapper : IScalarDataMapper<Nullable<DateTime>>
		{
			public Nullable<DateTime> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDateTime(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableDecimalMapper : IScalarDataMapper<Nullable<Decimal>>
		{
			public Nullable<Decimal> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDecimal(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableDoubleMapper : IScalarDataMapper<Nullable<Double>>
		{
			public Nullable<Double> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToDouble(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableSingleMapper : IScalarDataMapper<Nullable<Single>>
		{
			public Nullable<Single> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToSingle(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableInt16Mapper : IScalarDataMapper<Nullable<Int16>>
		{
			public Nullable<Int16> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt16(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableInt32Mapper : IScalarDataMapper<Nullable<Int32>>
		{
			public Nullable<Int32> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return Convert.ToInt32(source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal class NullableInt64ToNullableInt64Mapper : IScalarDataMapper<Nullable<Int64>>
		{
			public Nullable<Int64> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableInt64(sourceObject, sourceIndex);
				}
			}
		}

		internal class GuidToGuidMapper : IScalarDataMapper<Guid>
		{
			public Guid Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return Guid.Empty;
				}
				else
				{
					return source.GetGuid(sourceObject, sourceIndex);
				}
			}
		}

		internal class NullableGuidToNullableGuidMapper : IScalarDataMapper<Nullable<Guid>>
		{
			public Nullable<Guid> Map(IMapDataSource source, object sourceObject, int sourceIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					return null;
				}
				else
				{
					return source.GetNullableGuid(sourceObject, sourceIndex);
				}
			}
		}

		private static Dictionary<TypeMap, object> typeMap;

		static ScalarTypeMapper()
		{
			typeMap = new Dictionary<TypeMap, object>(445);

			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Boolean)), new BooleanToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Byte)), new BooleanToByteMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Char)), new BooleanToCharMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(DateTime)), new BooleanToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Decimal)), new BooleanToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Double)), new BooleanToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Single)), new BooleanToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Int16)), new BooleanToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Int32)), new BooleanToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Int64)), new BooleanToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(String)), new BooleanToStringMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Boolean>)), new BooleanToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Byte>)), new BooleanToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Char>)), new BooleanToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<DateTime>)), new BooleanToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Decimal>)), new BooleanToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Double>)), new BooleanToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Single>)), new BooleanToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Int16>)), new BooleanToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Int32>)), new BooleanToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Boolean), typeof(Nullable<Int64>)), new BooleanToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Boolean)), new ByteToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Byte)), new ByteToByteMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Char)), new ByteToCharMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(DateTime)), new ByteToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Decimal)), new ByteToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Double)), new ByteToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Single)), new ByteToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Int16)), new ByteToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Int32)), new ByteToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Int64)), new ByteToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(String)), new ByteToStringMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Boolean>)), new ByteToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Byte>)), new ByteToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Char>)), new ByteToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<DateTime>)), new ByteToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Decimal>)), new ByteToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Double>)), new ByteToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Single>)), new ByteToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Int16>)), new ByteToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Int32>)), new ByteToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Byte), typeof(Nullable<Int64>)), new ByteToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Boolean)), new CharToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Byte)), new CharToByteMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Char)), new CharToCharMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(DateTime)), new CharToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Decimal)), new CharToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Double)), new CharToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Single)), new CharToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Int16)), new CharToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Int32)), new CharToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Int64)), new CharToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(String)), new CharToStringMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Boolean>)), new CharToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Byte>)), new CharToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Char>)), new CharToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<DateTime>)), new CharToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Decimal>)), new CharToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Double>)), new CharToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Single>)), new CharToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Int16>)), new CharToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Int32>)), new CharToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Char), typeof(Nullable<Int64>)), new CharToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Boolean)), new DateTimeToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Byte)), new DateTimeToByteMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Char)), new DateTimeToCharMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(DateTime)), new DateTimeToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Decimal)), new DateTimeToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Double)), new DateTimeToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Single)), new DateTimeToSingleMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Int16)), new DateTimeToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Int32)), new DateTimeToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Int64)), new DateTimeToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(String)), new DateTimeToStringMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Boolean>)), new DateTimeToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Byte>)), new DateTimeToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Char>)), new DateTimeToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<DateTime>)), new DateTimeToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Decimal>)), new DateTimeToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Double>)), new DateTimeToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Single>)), new DateTimeToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Int16>)), new DateTimeToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Int32>)), new DateTimeToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(DateTime), typeof(Nullable<Int64>)), new DateTimeToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Boolean)), new DecimalToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Byte)), new DecimalToByteMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Char)), new DecimalToCharMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(DateTime)), new DecimalToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Decimal)), new DecimalToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Double)), new DecimalToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Single)), new DecimalToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Int16)), new DecimalToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Int32)), new DecimalToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Int64)), new DecimalToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(String)), new DecimalToStringMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Boolean>)), new DecimalToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Byte>)), new DecimalToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Char>)), new DecimalToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<DateTime>)), new DecimalToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Decimal>)), new DecimalToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Double>)), new DecimalToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Single>)), new DecimalToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Int16>)), new DecimalToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Int32>)), new DecimalToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Decimal), typeof(Nullable<Int64>)), new DecimalToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Boolean)), new DoubleToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Byte)), new DoubleToByteMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Char)), new DoubleToCharMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(DateTime)), new DoubleToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Decimal)), new DoubleToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Double)), new DoubleToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Single)), new DoubleToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Int16)), new DoubleToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Int32)), new DoubleToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Int64)), new DoubleToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(String)), new DoubleToStringMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Boolean>)), new DoubleToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Byte>)), new DoubleToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Char>)), new DoubleToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<DateTime>)), new DoubleToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Decimal>)), new DoubleToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Double>)), new DoubleToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Single>)), new DoubleToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Int16>)), new DoubleToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Int32>)), new DoubleToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Double), typeof(Nullable<Int64>)), new DoubleToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Boolean)), new SingleToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Byte)), new SingleToByteMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Char)), new SingleToCharMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(DateTime)), new SingleToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Decimal)), new SingleToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Double)), new SingleToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Single)), new SingleToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Int16)), new SingleToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Int32)), new SingleToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Int64)), new SingleToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(String)), new SingleToStringMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Boolean>)), new SingleToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Byte>)), new SingleToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Char>)), new SingleToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<DateTime>)), new SingleToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Decimal>)), new SingleToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Double>)), new SingleToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Single>)), new SingleToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Int16>)), new SingleToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Int32>)), new SingleToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Single), typeof(Nullable<Int64>)), new SingleToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Boolean)), new Int16ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Byte)), new Int16ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Char)), new Int16ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(DateTime)), new Int16ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Decimal)), new Int16ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Double)), new Int16ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Single)), new Int16ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Int16)), new Int16ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Int32)), new Int16ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Int64)), new Int16ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(String)), new Int16ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Boolean>)), new Int16ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Byte>)), new Int16ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Char>)), new Int16ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<DateTime>)), new Int16ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Decimal>)), new Int16ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Double>)), new Int16ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Single>)), new Int16ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Int16>)), new Int16ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Int32>)), new Int16ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int16), typeof(Nullable<Int64>)), new Int16ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Boolean)), new Int32ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Byte)), new Int32ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Char)), new Int32ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(DateTime)), new Int32ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Decimal)), new Int32ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Double)), new Int32ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Single)), new Int32ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Int16)), new Int32ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Int32)), new Int32ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Int64)), new Int32ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(String)), new Int32ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Boolean>)), new Int32ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Byte>)), new Int32ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Char>)), new Int32ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<DateTime>)), new Int32ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Decimal>)), new Int32ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Double>)), new Int32ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Single>)), new Int32ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Int16>)), new Int32ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Int32>)), new Int32ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int32), typeof(Nullable<Int64>)), new Int32ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Boolean)), new Int64ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Byte)), new Int64ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Char)), new Int64ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(DateTime)), new Int64ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Decimal)), new Int64ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Double)), new Int64ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Single)), new Int64ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Int16)), new Int64ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Int32)), new Int64ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Int64)), new Int64ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(String)), new Int64ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Boolean>)), new Int64ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Byte>)), new Int64ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Char>)), new Int64ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<DateTime>)), new Int64ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Decimal>)), new Int64ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Double>)), new Int64ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Single>)), new Int64ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Int16>)), new Int64ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Int32>)), new Int64ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Int64), typeof(Nullable<Int64>)), new Int64ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Boolean)), new StringToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Byte)), new StringToByteMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Char)), new StringToCharMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(DateTime)), new StringToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Decimal)), new StringToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Double)), new StringToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Single)), new StringToSingleMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Int16)), new StringToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Int32)), new StringToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Int64)), new StringToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(String)), new StringToStringMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Boolean>)), new StringToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Byte>)), new StringToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Char>)), new StringToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<DateTime>)), new StringToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Decimal>)), new StringToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Double>)), new StringToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Single>)), new StringToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Int16>)), new StringToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Int32>)), new StringToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(String), typeof(Nullable<Int64>)), new StringToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Boolean)), new NullableBooleanToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Byte)), new NullableBooleanToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Char)), new NullableBooleanToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(DateTime)), new NullableBooleanToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Decimal)), new NullableBooleanToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Double)), new NullableBooleanToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Single)), new NullableBooleanToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Int16)), new NullableBooleanToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Int32)), new NullableBooleanToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Int64)), new NullableBooleanToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(String)), new NullableBooleanToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Boolean>)), new NullableBooleanToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Byte>)), new NullableBooleanToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Char>)), new NullableBooleanToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<DateTime>)), new NullableBooleanToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Decimal>)), new NullableBooleanToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Double>)), new NullableBooleanToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Single>)), new NullableBooleanToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Int16>)), new NullableBooleanToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Int32>)), new NullableBooleanToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Boolean>), typeof(Nullable<Int64>)), new NullableBooleanToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Boolean)), new NullableByteToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Byte)), new NullableByteToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Char)), new NullableByteToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(DateTime)), new NullableByteToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Decimal)), new NullableByteToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Double)), new NullableByteToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Single)), new NullableByteToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Int16)), new NullableByteToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Int32)), new NullableByteToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Int64)), new NullableByteToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(String)), new NullableByteToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Boolean>)), new NullableByteToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Byte>)), new NullableByteToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Char>)), new NullableByteToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<DateTime>)), new NullableByteToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Decimal>)), new NullableByteToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Double>)), new NullableByteToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Single>)), new NullableByteToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Int16>)), new NullableByteToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Int32>)), new NullableByteToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Byte>), typeof(Nullable<Int64>)), new NullableByteToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Boolean)), new NullableCharToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Byte)), new NullableCharToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Char)), new NullableCharToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(DateTime)), new NullableCharToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Decimal)), new NullableCharToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Double)), new NullableCharToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Single)), new NullableCharToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Int16)), new NullableCharToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Int32)), new NullableCharToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Int64)), new NullableCharToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(String)), new NullableCharToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Boolean>)), new NullableCharToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Byte>)), new NullableCharToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Char>)), new NullableCharToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<DateTime>)), new NullableCharToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Decimal>)), new NullableCharToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Double>)), new NullableCharToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Single>)), new NullableCharToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Int16>)), new NullableCharToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Int32>)), new NullableCharToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Char>), typeof(Nullable<Int64>)), new NullableCharToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Boolean)), new NullableDateTimeToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Byte)), new NullableDateTimeToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Char)), new NullableDateTimeToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(DateTime)), new NullableDateTimeToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Decimal)), new NullableDateTimeToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Double)), new NullableDateTimeToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Single)), new NullableDateTimeToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Int16)), new NullableDateTimeToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Int32)), new NullableDateTimeToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Int64)), new NullableDateTimeToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(String)), new NullableDateTimeToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Boolean>)), new NullableDateTimeToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Byte>)), new NullableDateTimeToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Char>)), new NullableDateTimeToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<DateTime>)), new NullableDateTimeToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Decimal>)), new NullableDateTimeToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Double>)), new NullableDateTimeToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Single>)), new NullableDateTimeToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Int16>)), new NullableDateTimeToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Int32>)), new NullableDateTimeToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<DateTime>), typeof(Nullable<Int64>)), new NullableDateTimeToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Boolean)), new NullableDecimalToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Byte)), new NullableDecimalToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Char)), new NullableDecimalToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(DateTime)), new NullableDecimalToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Decimal)), new NullableDecimalToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Double)), new NullableDecimalToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Single)), new NullableDecimalToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Int16)), new NullableDecimalToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Int32)), new NullableDecimalToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Int64)), new NullableDecimalToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(String)), new NullableDecimalToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Boolean>)), new NullableDecimalToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Byte>)), new NullableDecimalToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Char>)), new NullableDecimalToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<DateTime>)), new NullableDecimalToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Decimal>)), new NullableDecimalToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Double>)), new NullableDecimalToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Single>)), new NullableDecimalToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Int16>)), new NullableDecimalToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Int32>)), new NullableDecimalToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Decimal>), typeof(Nullable<Int64>)), new NullableDecimalToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Boolean)), new NullableDoubleToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Byte)), new NullableDoubleToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Char)), new NullableDoubleToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(DateTime)), new NullableDoubleToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Decimal)), new NullableDoubleToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Double)), new NullableDoubleToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Single)), new NullableDoubleToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Int16)), new NullableDoubleToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Int32)), new NullableDoubleToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Int64)), new NullableDoubleToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(String)), new NullableDoubleToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Boolean>)), new NullableDoubleToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Byte>)), new NullableDoubleToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Char>)), new NullableDoubleToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<DateTime>)), new NullableDoubleToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Decimal>)), new NullableDoubleToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Double>)), new NullableDoubleToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Single>)), new NullableDoubleToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Int16>)), new NullableDoubleToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Int32>)), new NullableDoubleToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Double>), typeof(Nullable<Int64>)), new NullableDoubleToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Boolean)), new NullableSingleToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Byte)), new NullableSingleToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Char)), new NullableSingleToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(DateTime)), new NullableSingleToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Decimal)), new NullableSingleToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Double)), new NullableSingleToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Single)), new NullableSingleToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Int16)), new NullableSingleToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Int32)), new NullableSingleToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Int64)), new NullableSingleToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(String)), new NullableSingleToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Boolean>)), new NullableSingleToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Byte>)), new NullableSingleToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Char>)), new NullableSingleToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<DateTime>)), new NullableSingleToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Decimal>)), new NullableSingleToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Double>)), new NullableSingleToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Single>)), new NullableSingleToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Int16>)), new NullableSingleToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Int32>)), new NullableSingleToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Single>), typeof(Nullable<Int64>)), new NullableSingleToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Boolean)), new NullableInt16ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Byte)), new NullableInt16ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Char)), new NullableInt16ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(DateTime)), new NullableInt16ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Decimal)), new NullableInt16ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Double)), new NullableInt16ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Single)), new NullableInt16ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Int16)), new NullableInt16ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Int32)), new NullableInt16ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Int64)), new NullableInt16ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(String)), new NullableInt16ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Boolean>)), new NullableInt16ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Byte>)), new NullableInt16ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Char>)), new NullableInt16ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<DateTime>)), new NullableInt16ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Decimal>)), new NullableInt16ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Double>)), new NullableInt16ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Single>)), new NullableInt16ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Int16>)), new NullableInt16ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Int32>)), new NullableInt16ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int16>), typeof(Nullable<Int64>)), new NullableInt16ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Boolean)), new NullableInt32ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Byte)), new NullableInt32ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Char)), new NullableInt32ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(DateTime)), new NullableInt32ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Decimal)), new NullableInt32ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Double)), new NullableInt32ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Single)), new NullableInt32ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Int16)), new NullableInt32ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Int32)), new NullableInt32ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Int64)), new NullableInt32ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(String)), new NullableInt32ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Boolean>)), new NullableInt32ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Byte>)), new NullableInt32ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Char>)), new NullableInt32ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<DateTime>)), new NullableInt32ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Decimal>)), new NullableInt32ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Double>)), new NullableInt32ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Single>)), new NullableInt32ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Int16>)), new NullableInt32ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Int32>)), new NullableInt32ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int32>), typeof(Nullable<Int64>)), new NullableInt32ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Boolean)), new NullableInt64ToBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Byte)), new NullableInt64ToByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Char)), new NullableInt64ToCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(DateTime)), new NullableInt64ToDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Decimal)), new NullableInt64ToDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Double)), new NullableInt64ToDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Single)), new NullableInt64ToSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Int16)), new NullableInt64ToInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Int32)), new NullableInt64ToInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Int64)), new NullableInt64ToInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(String)), new NullableInt64ToStringMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Boolean>)), new NullableInt64ToNullableBooleanMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Byte>)), new NullableInt64ToNullableByteMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Char>)), new NullableInt64ToNullableCharMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<DateTime>)), new NullableInt64ToNullableDateTimeMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Decimal>)), new NullableInt64ToNullableDecimalMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Double>)), new NullableInt64ToNullableDoubleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Single>)), new NullableInt64ToNullableSingleMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Int16>)), new NullableInt64ToNullableInt16Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Int32>)), new NullableInt64ToNullableInt32Mapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Int64>), typeof(Nullable<Int64>)), new NullableInt64ToNullableInt64Mapper());
			typeMap.Add(new TypeMap(typeof(Guid), typeof(Guid)), new GuidToGuidMapper());
			typeMap.Add(new TypeMap(typeof(Nullable<Guid>), typeof(Nullable<Guid>)), new NullableGuidToNullableGuidMapper());
		}

		internal static IScalarDataMapper<T> GetMapper<T>(Type fromType, Type toType)
		{
			TypeMap map = new TypeMap(fromType, toType);

			if(typeMap.ContainsKey(map))
			{
				return typeMap[map] as IScalarDataMapper<T>;
			}
			else
			{
				return null;
			}
		}
	}
}
