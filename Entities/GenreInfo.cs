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

using Gremlin.FB2Librarian.Import.ObjectMetadata;
using Gremlin.FB2Librarian.Import.ObjectModel;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("GENREALT")]
    public class GenreMapInfo
    {
        private string genreName;
        private string genreAltName;

        [Column("GENREID")]
        public string GenreName
        {
            get
            {
                return this.genreName;
            }
            set
            {
                this.genreName = value;
            }
        }

        [Column("ALTID")]
        public string GenreAltName
        {
            get
            {
                return this.genreAltName;
            }
            set
            {
                this.genreAltName = value;
            }
        }
    }

    [Table("GENRE")]
    public class GenreInfo
    {
        private string name;
        private string ruDescription;
        private string enDescription;
        private readonly List<GenreMapInfo> genreMap; 
        
        public GenreInfo()
        {
            this.genreMap = new List<GenreMapInfo>();
        }

        [Column("GENREID")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [Column("RUSNAME")]
        public string RuDescription
        {
            get 
            { 
                return ruDescription; 
            }
            set 
            { 
                ruDescription = value; 
            }
        }

        [Column("ENGNAME")]
        public string EnDescription
        {
            get 
            { 
                return enDescription; 
            }
            set 
            { 
                enDescription = value; 
            }
        }

        public List<GenreMapInfo> GenreMap
        {
            get
            {
                return this.genreMap;
            }
        }
    }
}
