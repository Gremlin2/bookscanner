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
using System.Collections;

namespace Gremlin.FB2Librarian.Import
{
    internal class BufferPool
    {
        private readonly int size;
        private readonly Queue buffers;

        public BufferPool(int initialCapacity, int bufferSize)
        {
            this.size = bufferSize;
            this.buffers = new Queue(initialCapacity);

            for (int i = 0; i < initialCapacity; ++i)
            {
                this.buffers.Enqueue(new byte[bufferSize]);
            }
        }

        public byte[] Aquire()
        {
            if (this.buffers.Count > 0)
            {
                lock (this.buffers)
                {
                    if (this.buffers.Count > 0)
                    {
                        return (byte[]) this.buffers.Dequeue();
                    }
                }
            }

            return new byte[this.size];
        }

        public void Release(byte[] buffer)
        {
            lock (this.buffers)
            {
                this.buffers.Enqueue(buffer);
            }
        }
    }
}