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
using System.Collections.Generic;
using System.Reflection;

using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import
{
    internal class FilterAdapter
    {
        private readonly FictionBook book;

        public FilterAdapter(FictionBook book)
        {
            this.book = book;
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public List<string> Genres
        {
            get
            {
                if (this.book.TitleInfo == null || this.book.TitleInfo.Genres == null)
                {
                    return null;
                }

                List<string> genres = new List<string>(this.book.TitleInfo.Genres.Count);
                foreach (IGenreInfoNode genre in book.TitleInfo.Genres)
                {
                    genres.Add(genre.Genre);
                }

                return this.book.TitleInfo.Genres.ConvertAll(x => x.Genre);
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string Lang
        {
            get
            {
                if (this.book.TitleInfo == null)
                {
                    return null;
                }

                return this.book.TitleInfo.Lang;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string SrcLang
        {
            get
            {
                if (this.book.TitleInfo == null)
                {
                    return null;
                }

                return this.book.TitleInfo.SourceLang;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public List<string> BookAuthors
        {
            get
            {
                if (this.book.TitleInfo == null || this.book.TitleInfo.Authors == null)
                {
                    return null;
                }

                return this.book.TitleInfo.Authors.ConvertAll(x => x.DisplayName);
            }
        }
    }
}