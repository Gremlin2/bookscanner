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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

using FILETIME=System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Gremlin.FB2Librarian.Import.SevenZip
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct PropVariant
    {
        [DllImport("ole32.dll")]
        private static extern int PropVariantClear(ref PropVariant pvar);

        [FieldOffset(0)]
        public ushort vt;

        [FieldOffset(8)]
        public IntPtr pointerValue;

        [FieldOffset(8)]
        public sbyte sbyteValue;

        [FieldOffset(8)]
        public byte byteValue;

        [FieldOffset(8)]
        public short shortValue;

        [FieldOffset(8)]
        public ushort ushortValue;

        [FieldOffset(8)]
        public int intValue;

        [FieldOffset(8)]
        public uint uintValue;

        [FieldOffset(8)]
        public long longValue;

        [FieldOffset(8)]
        public ulong ulongValue;

        [FieldOffset(8)]
        public float floatValue;

        [FieldOffset(8)]
        public double doubleValue;

        [FieldOffset(8)]
        public FILETIME filetime;

        public VarEnum VarType
        {
            get
            {
                return (VarEnum) vt;
            }

            set
            {
                vt = (ushort) value;
            }
        }

        public void Clear()
        {
            switch (VarType)
            {
                case VarEnum.VT_EMPTY:
                    break;

                case VarEnum.VT_NULL:
                case VarEnum.VT_I2:
                case VarEnum.VT_I4:
                case VarEnum.VT_R4:
                case VarEnum.VT_R8:
                case VarEnum.VT_CY:
                case VarEnum.VT_DATE:
                case VarEnum.VT_ERROR:
                case VarEnum.VT_BOOL:
                    //case VarEnum.VT_DECIMAL:
                case VarEnum.VT_I1:
                case VarEnum.VT_UI1:
                case VarEnum.VT_UI2:
                case VarEnum.VT_UI4:
                case VarEnum.VT_I8:
                case VarEnum.VT_UI8:
                case VarEnum.VT_INT:
                case VarEnum.VT_UINT:
                case VarEnum.VT_HRESULT:
                case VarEnum.VT_FILETIME:
                    vt = 0;
                    break;

                case VarEnum.VT_BSTR:
                    Marshal.FreeBSTR(pointerValue);
                    vt = 0;
                    break;

                default:
                    PropVariantClear(ref this);
                    break;
            }
        }

        public object GetObject()
        {
            switch (VarType)
            {
                case VarEnum.VT_EMPTY:
                    return null;

                case VarEnum.VT_FILETIME:
                    return DateTime.FromFileTime(longValue);

                default:
                    GCHandle PropHandle = GCHandle.Alloc(this, GCHandleType.Pinned);
                    try
                    {
                        return Marshal.GetObjectForNativeVariant(PropHandle.AddrOfPinnedObject());
                    }
                    finally
                    {
                        PropHandle.Free();
                    }
            }
        }

        public void SetObject(object value)
        {
            if (value == null)
            {
                vt = (ushort) VarEnum.VT_EMPTY;
            }
            else
            {
                switch (Type.GetTypeCode(value.GetType()))
                {
                    case TypeCode.DBNull:
                        vt = (ushort) VarEnum.VT_NULL;
                        break;

                    case TypeCode.Boolean:
                        shortValue = Convert.ToInt16(value);
                        vt = (ushort) VarEnum.VT_BOOL;
                        break;

                        //TypeCode.Char = 4,
                    case TypeCode.SByte:
                        sbyteValue = (sbyte) value;
                        vt = (ushort) VarEnum.VT_I1;
                        break;

                    case TypeCode.Byte:
                        byteValue = (byte) value;
                        vt = (ushort) VarEnum.VT_UI1;
                        break;

                    case TypeCode.Int16:
                        shortValue = (short) value;
                        vt = (ushort) VarEnum.VT_I2;
                        break;

                    case TypeCode.UInt16:
                        ushortValue = (ushort) value;
                        vt = (ushort) VarEnum.VT_UI2;
                        break;

                    case TypeCode.Int32:
                        intValue = (int) value;
                        vt = (ushort) VarEnum.VT_I4;
                        break;

                    case TypeCode.UInt32:
                        uintValue = (uint) value;
                        vt = (ushort) VarEnum.VT_UI4;
                        break;

                    case TypeCode.Int64:
                        longValue = (long) value;
                        vt = (ushort) VarEnum.VT_I8;
                        break;

                    case TypeCode.UInt64:
                        ulongValue = (ulong) value;
                        vt = (ushort) VarEnum.VT_UI8;
                        break;

                    case TypeCode.Single:
                        floatValue = (float) value;
                        vt = (ushort) VarEnum.VT_R4;
                        break;

                    case TypeCode.Double:
                        doubleValue = (double) value;
                        vt = (ushort) VarEnum.VT_R8;
                        break;

                        //TypeCode.Decimal:
                        //TypeCode.DateTime,
                    case TypeCode.String:
                        pointerValue = Marshal.StringToBSTR((string) value);
                        vt = (ushort) VarEnum.VT_BSTR;
                        break;
                }
            }
        }
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000000050000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProgress
    {
        void SetTotal(ulong total);
        void SetCompleted([In] ref ulong completeValue);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600100000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IArchiveOpenCallback
    {
        // ref ulong replaced with IntPtr because handlers ofter pass null value
        // read actual value with Marshal.ReadInt64
        void SetTotal(
            IntPtr files, // [In] ref ulong files, can use 'ulong* files' but it is unsafe
            IntPtr bytes); // [In] ref ulong bytes
        void SetCompleted(
            IntPtr files, // [In] ref ulong files
            IntPtr bytes); // [In] ref ulong bytes
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000500100000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICryptoGetTextPassword
    {
        [PreserveSig]
        int CryptoGetTextPassword(
            [MarshalAs(UnmanagedType.BStr)] out string password);

        //[return : MarshalAs(UnmanagedType.BStr)]
        //string CryptoGetTextPassword();
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000500110000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICryptoGetTextPassword2
    {
        void CryptoGetTextPassword2(
            [MarshalAs(UnmanagedType.Bool)] out bool passwordIsDefined,
            [MarshalAs(UnmanagedType.BStr)] out string password);
    }

    public enum AskMode : int
    {
        kExtract = 0,
        kTest,
        kSkip
    }

    public enum OperationResult : int
    {
        kOK = 0,
        kUnSupportedMethod,
        kDataError,
        kCRCError
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600200000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IArchiveExtractCallback //: IProgress
    {
        // IProgress
        void SetTotal(ulong total);
        void SetCompleted([In] ref ulong completeValue);

        // IArchiveExtractCallback
        [PreserveSig]
        int GetStream(
            uint index,
            [MarshalAs(UnmanagedType.Interface)] out ISequentialOutStream outStream,
            AskMode askExtractMode);

        // GetStream OUT: S_OK - OK, S_FALSE - skeep this file

        void PrepareOperation(AskMode askExtractMode);
        void SetOperationResult(OperationResult resultEOperationResult);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600300000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IArchiveOpenVolumeCallback
    {
        int GetProperty(
            ItemPropId propID, // PROPID
            ref PropVariant value); // PROPVARIANT

        [PreserveSig]
        int GetStream(
            [MarshalAs(UnmanagedType.LPWStr)] string name,
            [MarshalAs(UnmanagedType.Interface)] out IInStream inStream);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600400000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInArchiveGetStream
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        ISequentialInStream GetStream(uint index);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300010000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISequentialInStream
    {
        //[PreserveSig]
        //int Read(
        //  [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
        //  uint size,
        //  IntPtr processedSize); // ref uint processedSize

        uint Read(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
            uint size);

        /*
    Out: if size != 0, return_value = S_OK and (*processedSize == 0),
      then there are no more bytes in stream.
    if (size > 0) && there are bytes in stream, 
    this function must read at least 1 byte.
    This function is allowed to read less than number of remaining bytes in stream.
    You must call Read function in loop, if you need exact amount of data
    */
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300020000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISequentialOutStream
    {
        [PreserveSig]
        int Write(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
            uint size,
            IntPtr processedSize); // ref uint processedSize
        /*
    if (size > 0) this function must write at least 1 byte.
    This function is allowed to write less than "size".
    You must call Write function in loop, if you need to write exact amount of data
    */
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300030000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInStream //: ISequentialInStream
    {
        //[PreserveSig]
        //int Read(
        //  [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
        //  uint size,
        //  IntPtr processedSize); // ref uint processedSize

        // ISequentialInStream
        uint Read(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
            uint size);

        // IInStream
        //[PreserveSig]
        void Seek(
            long offset,
            uint seekOrigin,
            IntPtr newPosition); // ref long newPosition
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300040000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOutStream //: ISequentialOutStream
    {
        // ISequentialOutStream
        [PreserveSig]
        int Write(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] data,
            uint size,
            IntPtr processedSize); // ref uint processedSize

        // IOutStream
        //[PreserveSig]
        void Seek(
            long offset,
            uint seekOrigin,
            IntPtr newPosition); // ref long newPosition

        [PreserveSig]
        int SetSize(long newSize);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300060000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStreamGetSize
    {
        ulong GetSize();
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000300070000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOutStreamFlush
    {
        void Flush();
    }

    public enum ItemPropId : uint
    {
        kpidNoProperty = 0,

        kpidHandlerItemIndex = 2,
        kpidPath,
        kpidName,
        kpidExtension,
        kpidIsFolder,
        kpidSize,
        kpidPackedSize,
        kpidAttributes,
        kpidCreationTime,
        kpidLastAccessTime,
        kpidLastWriteTime,
        kpidSolid,
        kpidCommented,
        kpidEncrypted,
        kpidSplitBefore,
        kpidSplitAfter,
        kpidDictionarySize,
        kpidCRC,
        kpidType,
        kpidIsAnti,
        kpidMethod,
        kpidHostOS,
        kpidFileSystem,
        kpidUser,
        kpidGroup,
        kpidBlock,
        kpidComment,
        kpidPosition,
        kpidPrefix,
        // 4.58+
        kpidNumSubFolders,
        kpidNumSubFiles,
        kpidUnpackVer,
        kpidVolume,
        kpidIsVolume,
        kpidOffset,
        kpidLinks,
        kpidNumBlocks,
        kpidNumVolumes,
        kpidTimeType,
        // 4.60+
        kpidBit64,
        kpidBigEndian,
        kpidCpu,
        kpidPhySize,
        kpidHeadersSize,
        kpidChecksum,
        kpidCharacts,
        kpidVa,

        kpidTotalSize = 0x1100,
        kpidFreeSpace,
        kpidClusterSize,
        kpidVolumeName,

        kpidLocalName = 0x1200,
        kpidProvider,

        kpidUserDefined = 0x10000
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600600000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //[AutomationProxy(true)]
    public interface IInArchive
    {
        [PreserveSig]
        int Open(
            IInStream stream,
            /*[MarshalAs(UnmanagedType.U8)]*/ [In] ref ulong maxCheckStartPosition,
            [MarshalAs(UnmanagedType.Interface)] IArchiveOpenCallback openArchiveCallback);

        [PreserveSig]
        int Close();

        //void GetNumberOfItems([In] ref uint numItem);
        uint GetNumberOfItems();

        void GetProperty(
            uint index,
            ItemPropId propID, // PROPID
            ref PropVariant value); // PROPVARIANT

        [PreserveSig]
        int Extract(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indices, //[In] ref uint indices,
            uint numItems,
            int testMode,
            [MarshalAs(UnmanagedType.Interface)] IArchiveExtractCallback extractCallback);

        // indices must be sorted 
        // numItems = 0xFFFFFFFF means all files
        // testMode != 0 means "test files operation"

        void GetArchiveProperty(
            uint propID, // PROPID
            ref PropVariant value); // PROPVARIANT

        //void GetNumberOfProperties([In] ref uint numProperties);
        uint GetNumberOfProperties();

        void GetPropertyInfo(
            uint index,
            [MarshalAs(UnmanagedType.BStr)] out string name,
            out ItemPropId propID, // PROPID
            out ushort varType); //VARTYPE

        //void GetNumberOfArchiveProperties([In] ref uint numProperties);
        uint GetNumberOfArchiveProperties();

        void GetArchivePropertyInfo(
            uint index,
            [MarshalAs(UnmanagedType.BStr)] string name,
            ref uint propID, // PROPID
            ref ushort varType); //VARTYPE
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600800000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IArchiveUpdateCallback // : IProgress
    {
        // IProgress
        void SetTotal(ulong total);
        void SetCompleted([In] ref ulong completeValue);

        // IArchiveUpdateCallback
        void GetUpdateItemInfo(int index,
                               out int newData, // 1 - new data, 0 - old data
                               out int newProperties, // 1 - new properties, 0 - old properties
                               out uint indexInArchive); // -1 if there is no in archive, or if doesn't matter

        void GetProperty(
            int index,
            ItemPropId propID, // PROPID
            ref PropVariant value); // PROPVARIANT

        void GetStream(int index, out ISequentialInStream inStream);

        void SetOperationResult(int operationResult);
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600820000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IArchiveUpdateCallback2 // : IArchiveUpdateCallback
    {
        // IProgress
        void SetTotal(ulong total);
        void SetCompleted([In] ref ulong completeValue);

        // IArchiveUpdateCallback
        void GetUpdateItemInfo(int index,
                               out int newData, // 1 - new data, 0 - old data
                               out int newProperties, // 1 - new properties, 0 - old properties
                               out uint indexInArchive); // -1 if there is no in archive, or if doesn't matter

        void GetProperty(
            int index,
            ItemPropId propID, // PROPID
            IntPtr value); // PROPVARIANT

        void GetStream(int index, out ISequentialInStream inStream);

        void SetOperationResult(int operationResult);

        // IArchiveUpdateCallback2
        void GetVolumeSize(int index, out ulong size);
        void GetVolumeStream(int index, out ISequentialOutStream volumeStream);
    }

    public enum FileTimeType : int
    {
        kWindows,
        kUnix,
        kDOS
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600A00000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOutArchive
    {
        void UpdateItems(
            ISequentialOutStream outStream,
            int numItems,
            IArchiveUpdateCallback updateCallback);

        FileTimeType GetFileTimeType();
    }

    [ComImport]
    [Guid("23170F69-40C1-278A-0000-000600030000")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISetProperties
    {
        void SetProperties(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 2)] string[] names,
            IntPtr values,
            int numProperties);
    }

    public enum ArchivePropId : uint
    {
        kName = 0,
        kClassID,
        kExtension,
        kAddExtension,
        kUpdate,
        kKeepName,
        kStartSignature,
        kFinishSignature,
        kAssociate
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int CreateObjectDelegate(
        [In] ref Guid classID,
        [In] ref Guid interfaceID,
        //out IntPtr outObject);
        [MarshalAs(UnmanagedType.Interface)] out object outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GetHandlerPropertyDelegate(
        ArchivePropId propID,
        ref PropVariant value); // PROPVARIANT

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GetNumberOfFormatsDelegate(out uint numFormats);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int GetHandlerProperty2Delegate(
        uint formatIndex,
        ArchivePropId propID,
        ref PropVariant value); // PROPVARIANT

    public class SevenZipStreamWrapper : IDisposable
    {
        protected Stream _BaseStream;

        protected SevenZipStreamWrapper(Stream baseStream)
        {
            _BaseStream = baseStream;
        }

        public virtual void Dispose()
        {
            //_BaseStream.Close();
        }

        public virtual void Seek(long offset, uint seekOrigin, IntPtr newPosition)
        {
            long Position = (uint) _BaseStream.Seek(offset, (SeekOrigin) seekOrigin);
            if (newPosition != IntPtr.Zero)
            {
                Marshal.WriteInt64(newPosition, Position);
            }
        }

        public Stream BaseStream
        {
            get
            {
                return _BaseStream;
            }
        }
    }

    public class InStreamWrapper : SevenZipStreamWrapper, ISequentialInStream, IInStream //, IStreamGetSize
    {
        public InStreamWrapper(Stream baseStream) : base(baseStream)
        {
        }

        public uint Read(byte[] data, uint size)
        {
            return (uint) _BaseStream.Read(data, 0, (int) size);
        }

        public ulong GetSize()
        {
            return (ulong) BaseStream.Length;
        }
    }

    // Can close base stream after period of inactivity and reopen it when needed.
    // Useful for long opened archives (prevent locking archive file on disk).
    public class InStreamTimedWrapper : SevenZipStreamWrapper, ISequentialInStream, IInStream
    {
        private string _BaseStreamFileName;
        private long BaseStreamLastPosition;
        private Timer CloseTimer;

        private const int KeepAliveInterval = 5 * 1000; // 5 sec

        public InStreamTimedWrapper(Stream baseStream)
            : base(baseStream)
        {
            FileStream BaseFileStream = _BaseStream as FileStream;
            if ((BaseFileStream != null) && !_BaseStream.CanWrite && _BaseStream.CanSeek)
            {
                _BaseStreamFileName = BaseFileStream.Name;
                CloseTimer = new Timer(new TimerCallback(CloseStream), null, KeepAliveInterval, Timeout.Infinite);
            }
        }

        private void CloseStream(object state)
        {
            if (CloseTimer != null)
            {
                CloseTimer.Dispose();
                CloseTimer = null;
            }

            if (_BaseStream != null)
            {
                if (_BaseStream.CanSeek)
                {
                    BaseStreamLastPosition = _BaseStream.Position;
                }
                _BaseStream.Close();
                _BaseStream = null;
            }
        }

        public override void Dispose()
        {
            CloseStream(null);
            _BaseStreamFileName = null;
        }

        public void Flush()
        {
            CloseStream(null);
        }

        protected void ReopenStream()
        {
            // If base stream closed (by us or by external code) then try to reopen stream
            if ((_BaseStream == null) || !_BaseStream.CanRead)
            {
                if (_BaseStreamFileName != null)
                {
                    _BaseStream = new FileStream(_BaseStreamFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    _BaseStream.Position = BaseStreamLastPosition;
                    CloseTimer = new Timer(new TimerCallback(CloseStream), null, KeepAliveInterval, Timeout.Infinite);
                }
                else
                {
                    throw new ObjectDisposedException("StreamWrapper");
                }
            }
            else if (CloseTimer != null)
            {
                CloseTimer.Change(KeepAliveInterval, Timeout.Infinite);
            }
        }

        /*public int Read(byte[] data, uint size, IntPtr processedSize)
    {
      int Processed = BaseStream.Read(data, 0, (int)size);
      if (processedSize != IntPtr.Zero)
        Marshal.WriteInt32(processedSize, Processed);
      return 0;
    }*/

        public uint Read(byte[] data, uint size)
        {
            ReopenStream();
            return (uint) _BaseStream.Read(data, 0, (int) size);
        }

        public override void Seek(long offset, uint seekOrigin, IntPtr newPosition)
        {
            if ((_BaseStream == null) && (_BaseStreamFileName != null) && (offset == 0) && (seekOrigin == 0))
            {
                BaseStreamLastPosition = 0;
                if (newPosition != IntPtr.Zero)
                {
                    Marshal.WriteInt64(newPosition, BaseStreamLastPosition);
                }
            }
            else
            {
                ReopenStream();
                base.Seek(offset, seekOrigin, newPosition);
            }
        }

        public string BaseStreamFileName
        {
            get
            {
                return _BaseStreamFileName;
            }
        }
    }

    public class OutStreamWrapper : SevenZipStreamWrapper, ISequentialOutStream, IOutStream
    {
        public OutStreamWrapper(Stream baseStream) : base(baseStream)
        {
        }

        public int SetSize(long newSize)
        {
            _BaseStream.SetLength(newSize);
            return 0;
        }

        public int Write(byte[] data, uint size, IntPtr processedSize)
        {
            _BaseStream.Write(data, 0, (int) size);
            if (processedSize != IntPtr.Zero)
            {
                Marshal.WriteInt32(processedSize, (int) size);
            }
            return 0;
        }
    }
}