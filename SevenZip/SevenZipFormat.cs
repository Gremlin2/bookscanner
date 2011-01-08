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
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

using Microsoft.Win32.SafeHandles;

namespace Gremlin.FB2Librarian.Import.SevenZip
{
    public enum KnownSevenZipFormat
    {
        SevenZip,
        Arj,
        BZip2,
        Cab,
        Chm,
        Compound,
        Cpio,
        Deb,
        GZip,
        Iso,
        Lzh,
        Lzma,
        Nsis,
        Rar,
        Rpm,
        Split,
        Tar,
        Wim,
        Z,
        Zip
    }

    public class SevenZipFormat : IDisposable
    {
        private const string Kernel32Dll = "kernel32.dll";

        private sealed class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeLibraryHandle() : base(true)
            {
            }

            [SuppressUnmanagedCodeSecurity]
            [DllImport(Kernel32Dll)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FreeLibrary(IntPtr hModule);

            /// <summary>Release library handle</summary>
            /// <returns>true if the handle was released</returns>
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                return FreeLibrary(handle);
            }
        }

        [DllImport(Kernel32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern SafeLibraryHandle LoadLibrary(
            [MarshalAs(UnmanagedType.LPTStr)] string lpFileName);

        [DllImport(Kernel32Dll, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetProcAddress(
            SafeLibraryHandle hModule,
            [MarshalAs(UnmanagedType.LPStr)] string procName);

        [DllImport(Kernel32Dll)]
        private static extern uint GetOEMCP();

        private static readonly Dictionary<KnownSevenZipFormat, Guid> FFormatClassMap;
        private SafeLibraryHandle libHandle;

        private readonly static int systemCodePage;
        private static int defaultCodePage;

        private static Encoding systemEncoding;
        private static Encoding defaultEncoding;

        static SevenZipFormat()
        {
            FFormatClassMap = new Dictionary<KnownSevenZipFormat, Guid>
            {
                {KnownSevenZipFormat.SevenZip, new Guid("23170f69-40c1-278a-1000-000110070000")}, 
                {KnownSevenZipFormat.Arj, new Guid("23170f69-40c1-278a-1000-000110040000")}, 
                {KnownSevenZipFormat.BZip2, new Guid("23170f69-40c1-278a-1000-000110020000")}, 
                {KnownSevenZipFormat.Cab, new Guid("23170f69-40c1-278a-1000-000110080000")}, 
                {KnownSevenZipFormat.Chm, new Guid("23170f69-40c1-278a-1000-000110e90000")}, 
                {KnownSevenZipFormat.Compound, new Guid("23170f69-40c1-278a-1000-000110e50000")}, 
                {KnownSevenZipFormat.Cpio, new Guid("23170f69-40c1-278a-1000-000110ed0000")}, 
                {KnownSevenZipFormat.Deb, new Guid("23170f69-40c1-278a-1000-000110ec0000")}, 
                {KnownSevenZipFormat.GZip, new Guid("23170f69-40c1-278a-1000-000110ef0000")}, 
                {KnownSevenZipFormat.Iso, new Guid("23170f69-40c1-278a-1000-000110e70000")}, 
                {KnownSevenZipFormat.Lzh, new Guid("23170f69-40c1-278a-1000-000110060000")}, 
                {KnownSevenZipFormat.Lzma, new Guid("23170f69-40c1-278a-1000-0001100a0000")}, 
                {KnownSevenZipFormat.Nsis, new Guid("23170f69-40c1-278a-1000-000110090000")}, 
                {KnownSevenZipFormat.Rar, new Guid("23170f69-40c1-278a-1000-000110030000")}, 
                {KnownSevenZipFormat.Rpm, new Guid("23170f69-40c1-278a-1000-000110eb0000")}, 
                {KnownSevenZipFormat.Split, new Guid("23170f69-40c1-278a-1000-000110ea0000")}, 
                {KnownSevenZipFormat.Tar, new Guid("23170f69-40c1-278a-1000-000110ee0000")}, 
                {KnownSevenZipFormat.Wim, new Guid("23170f69-40c1-278a-1000-000110e60000")}, 
                {KnownSevenZipFormat.Z, new Guid("23170f69-40c1-278a-1000-000110050000")}, 
                {KnownSevenZipFormat.Zip, new Guid("23170f69-40c1-278a-1000-000110010000")}
            };

            systemCodePage = (int) GetOEMCP();
            defaultCodePage = systemCodePage;

            systemEncoding = Encoding.GetEncoding(systemCodePage);
            defaultEncoding = systemEncoding;
        }

        public static int SystemCodePage
        {
            get
            {
                return systemCodePage;
            }
        }

        public static int DefaultCodePage
        {
            get
            {
                return defaultCodePage;
            }
            set
            {
                if(defaultCodePage != value)
                {
                    defaultEncoding = Encoding.GetEncoding(value);
                    defaultCodePage = value;
                }
            }
        }

        public static Encoding SystemEncoding
        {
            get
            {
                return systemEncoding;
            }
        }

        public static Encoding DefaultEncoding
        {
            get
            {
                return defaultEncoding;
            }
        }

        public SevenZipFormat(string sevenZipLibPath)
        {
            this.libHandle = LoadLibrary(sevenZipLibPath);
            if (this.libHandle.IsInvalid)
            {
                throw new Win32Exception();
            }

            IntPtr functionPtr = GetProcAddress(this.libHandle, "GetHandlerProperty");
            // Not valid dll
            if (functionPtr == IntPtr.Zero)
            {
                this.libHandle.Close();
                throw new ArgumentException();
            }
        }

        ~SevenZipFormat()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if ((this.libHandle != null) && !this.libHandle.IsClosed)
            {
                this.libHandle.Close();
            }
            this.libHandle = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IOutArchive CreateOutArchive(Guid classId)
        {
            return CreateInterface<IOutArchive>(classId);
        }

        public IInArchive CreateInArchive(Guid classId)
        {
            return CreateInterface<IInArchive>(classId);
        }

        private T CreateInterface<T>(Guid classId) where T : class
        {
            if (this.libHandle == null)
            {
                throw new ObjectDisposedException("SevenZipFormat");
            }

            CreateObjectDelegate createDelegate = (CreateObjectDelegate) Marshal.GetDelegateForFunctionPointer(GetProcAddress(this.libHandle, "CreateObject"), typeof(CreateObjectDelegate));

            if (createDelegate != null)
            {
                object result;
                Guid guid = typeof(T).GUID;
                createDelegate(ref classId, ref guid, out result);
                return result as T;
            }

            return null;
        }

        public static Guid GetClassIdFromKnownFormat(KnownSevenZipFormat format)
        {
            Guid result;
            if (FFormatClassMap.TryGetValue(format, out result))
            {
                return result;
            }

            return Guid.Empty;
        }
    }
}