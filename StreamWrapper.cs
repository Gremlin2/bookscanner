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
using System.IO;
using System.Text;

namespace Gremlin.FB2Librarian.Import
{
    internal class StreamWrapper : Stream
    {
        private readonly Stream baseStream;

        public StreamWrapper(Stream baseStream)
        {
            if (baseStream == null)
            {
                throw new ArgumentNullException("baseStream");
            }

            this.baseStream = baseStream;
        }

        public override void Flush()
        {
            baseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return baseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            baseStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return baseStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            baseStream.Write(buffer, offset, count);
        }

        public override void Close()
        {
        }

        protected override void Dispose(bool disposing)
        {
        }

        public override bool CanRead
        {
            get
            {
                return baseStream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return baseStream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return baseStream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return baseStream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return baseStream.Position;
            }
            set
            {
                baseStream.Position = value;
            }
        }
    }
}
