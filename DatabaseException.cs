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
using System.Data.Common;
using System.Runtime.Serialization;
using System.Text;

namespace Gremlin.FB2Librarian.Import
{
    [Serializable]
    public class DatabaseException : DbException
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DatabaseException(string message, int errorCode) : base(message, errorCode)
        {
        }

        public DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
