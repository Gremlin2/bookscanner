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

namespace Gremlin.FB2Librarian.Import.Mapping
{
    internal class TypeMap
    {
        private Type fromType;
        private Type toType;
        
        internal TypeMap(Type fromType, Type toType)
        {
            this.fromType = fromType;
            this.toType = toType;
        }

        public override int GetHashCode()
        {
            return fromType.GetHashCode() + 29 * toType.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            
            TypeMap typeMap = obj as TypeMap;
            if (typeMap == null)
            {
                return false;
            }

            if (!Equals(fromType, typeMap.fromType))
            {
                return false;
            }
            
            if (!Equals(toType, typeMap.toType))
            {
                return false;
            }
            
            return true;
        }
    }
}
