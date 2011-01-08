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

namespace Gremlin.FB2Librarian.Import
{
    internal class ImportOptions
    {
        private bool dontCheckForDuplicate;
        private bool indentHeader;
        private bool indentBody;
        private string encodingName;
        private bool mapGenres;
        private bool useSgmlReader;

        public bool DontCheckForDuplicate
        {
            get
            {
                return this.dontCheckForDuplicate;
            }
            set
            {
                this.dontCheckForDuplicate = value;
            }
        }

        public bool IndentHeader
        {
            get
            {
                return this.indentHeader;
            }
            set
            {
                this.indentHeader = value;
            }
        }

        public bool IndentBody
        {
            get
            {
                return this.indentBody;
            }
            set
            {
                this.indentBody = value;
            }
        }

        public string EncodingName
        {
            get
            {
                return this.encodingName;
            }
            set
            {
                this.encodingName = value;
            }
        }

        public bool MapGenres
        {
            get
            {
                return this.mapGenres;
            }
            set
            {
                this.mapGenres = value;
            }
        }

        public bool UseSgmlReader
        {
            get
            {
                return this.useSgmlReader;
            }
            set
            {
                this.useSgmlReader = value;
            }
        }
    }
}
