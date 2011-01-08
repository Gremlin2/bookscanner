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
using System.Collections.Generic;
using System.Text;

namespace Gremlin.FB2Librarian.Import.Utils
{
    public class Iterator : IEnumerable
    {
        private readonly IEnumerator iterator;

        public Iterator(IEnumerator iterator)
        {
            this.iterator = iterator;
        }

        public Iterator(IEnumerable enumerable)
        {
            this.iterator = enumerable.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.iterator;
        }
    }

    public class Iterator<T> : IEnumerable<T>
    {
        private IEnumerator<T> iterator;

        public Iterator(IEnumerator<T> iterator)
        {
            this.iterator = iterator;
        }

        public Iterator(IEnumerable<T> enumerable)
        {
            this.iterator = enumerable.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.iterator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.iterator;
        }
    }
}