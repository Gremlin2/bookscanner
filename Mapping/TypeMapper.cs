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
	internal class TypeMapper
	{
		internal sealed class BooleanToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, source.GetBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class BooleanToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class BooleanToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, source.GetByte(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class ByteToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class ByteToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, source.GetChar(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class CharToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class CharToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, source.GetDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class DateTimeToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DateTimeToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, source.GetDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class DecimalToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DecimalToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, source.GetDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class DoubleToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class DoubleToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, source.GetFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class SingleToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class SingleToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, source.GetInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class Int16ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int16ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, source.GetInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class Int32ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int32ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, source.GetInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class Int64ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class Int64ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, source.GetString(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class StringToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class StringToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetString(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, source.GetNullableBoolean(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableBooleanToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableBooleanToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableBoolean(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, source.GetNullableByte(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableByteToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableByteToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableByte(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, source.GetNullableChar(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableCharToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableCharToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableChar(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, source.GetNullableDateTime(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDateTimeToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDateTime(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, source.GetNullableDecimal(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableDecimalToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDecimalToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDecimal(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, source.GetNullableDouble(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableDoubleToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableDoubleToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableDouble(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, source.GetNullableFloat(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableSingleToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableSingleToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableFloat(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, source.GetNullableInt16(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableInt16ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt16ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableInt16(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt32ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, source.GetNullableInt32(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableInt32ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableInt32(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetBoolean(destinationObject, destinationIndex, false);
				}
				else
				{
					destination.SetBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetByte(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetChar(destinationObject, destinationIndex, '\0');
				}
				else
				{
					destination.SetChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDateTime(destinationObject, destinationIndex, DateTime.MinValue);
				}
				else
				{
					destination.SetDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDecimal(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetDouble(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetFloat(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt16(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt32(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetInt64(destinationObject, destinationIndex, 0);
				}
				else
				{
					destination.SetInt64(destinationObject, destinationIndex, Convert.ToInt64(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToStringMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetString(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetString(destinationObject, destinationIndex, Convert.ToString(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableBooleanMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableBoolean(destinationObject, destinationIndex, Convert.ToBoolean(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableByteMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableByte(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableByte(destinationObject, destinationIndex, Convert.ToByte(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableCharMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableChar(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableChar(destinationObject, destinationIndex, Convert.ToChar(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableDateTimeMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDateTime(destinationObject, destinationIndex, Convert.ToDateTime(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableDecimalMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDecimal(destinationObject, destinationIndex, Convert.ToDecimal(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableDoubleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableDouble(destinationObject, destinationIndex, Convert.ToDouble(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableSingleMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableFloat(destinationObject, destinationIndex, Convert.ToSingle(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableInt16Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt16(destinationObject, destinationIndex, Convert.ToInt16(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableInt32Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt32(destinationObject, destinationIndex, Convert.ToInt32(source.GetNullableInt64(sourceObject, sourceIndex)));
				}
			}
		}

		internal sealed class NullableInt64ToNullableInt64Mapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableInt64(destinationObject, destinationIndex, source.GetNullableInt64(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class GuidToGuidMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetGuid(destinationObject, destinationIndex, Guid.Empty);
				}
				else
				{
					destination.SetGuid(destinationObject, destinationIndex, source.GetGuid(sourceObject, sourceIndex));
				}
			}
		}

		internal sealed class NullableGuidToNullableGuidMapper : DataMapper
		{
			public override void Map(IMapDataSource source, object sourceObject, int sourceIndex, IMapDataDestination destination, object destinationObject, int destinationIndex)
			{
				if(source.IsNull(sourceObject, sourceIndex))
				{
					destination.SetNullableGuid(destinationObject, destinationIndex, null);
				}
				else
				{
					destination.SetNullableGuid(destinationObject, destinationIndex, source.GetNullableGuid(sourceObject, sourceIndex));
				}
			}
		}

		private static Dictionary<TypeMap, DataMapper> typeMap;

		static TypeMapper()
		{
			typeMap = new Dictionary<TypeMap, DataMapper>(445);

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

		internal static DataMapper GetMapper(Type fromType, Type toType)
		{
			TypeMap map = new TypeMap(fromType, toType);

			if(typeMap.ContainsKey(map))
			{
				return typeMap[map];
			}
			else
			{
				return null;
			}
		}
	}
}
