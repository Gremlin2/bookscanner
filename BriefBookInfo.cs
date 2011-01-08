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
using System.Reflection;

using Gremlin.FB2Librarian.Import.Entities;
using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = false, Exclude = true, StripAfterObfuscation = true)]
    internal class BriefBookInfo
    {
        private readonly BookInfo bookInfo;
        private readonly FictionBook fictionBook;
        private readonly Fb2DocumentEntry documentEntry;

        public BriefBookInfo(BookInfo bookInfo)
        {
            if (bookInfo == null)
            {
                throw new ArgumentNullException("bookInfo");
            }

            this.bookInfo = bookInfo;
        }

        public BriefBookInfo(FictionBook fictionBook, Fb2DocumentEntry documentEntry)
        {
            if (fictionBook == null)
            {
                throw new ArgumentNullException("fictionBook");
            }

            if (documentEntry == null)
            {
                throw new ArgumentNullException("documentEntry");
            }

            this.fictionBook = fictionBook;
            this.documentEntry = documentEntry;
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string Authors
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.AuthorList;
                }

                if(fictionBook != null && fictionBook.TitleInfo != null)
                {
                    return StringUtils.Join(", ", fictionBook.TitleInfo.Authors.ConvertAll(x => x.DisplayName));
                }

                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string BookTitle
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.BookTitle;
                }

                if (fictionBook != null && fictionBook.TitleInfo != null)
                {
                    return fictionBook.TitleInfo.BookTitle;
                }

                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string Genres
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.Genrelist;
                }

                if(fictionBook != null && fictionBook.TitleInfo != null)
                {
                    return StringUtils.Join(", ", fictionBook.TitleInfo.Genres.ConvertAll(delegate(IGenreInfoNode x)
                    {
                        Genre bookGenre = GenreTable.Table[x.Genre];
                        if (bookGenre != null)
                        {
                            return bookGenre.GetDescription("ru");
                        }

                        return String.Empty;
                    }));
                }

                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string BookSequence
        {
            get
            {
                if (bookInfo != null)
                {
                    return bookInfo.Sequence;
                }

                if (fictionBook != null && fictionBook.TitleInfo != null)
                {
                    foreach(SequenceInfoNode infoNode in fictionBook.TitleInfo.Sequences)
                    {
                        return infoNode.Name;
                    }

                    return null;
                }


                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string BookSequenceNumber
        {
            get
            {
                if (bookInfo != null)
                {
                    return bookInfo.SequenceNumber;
                }

                if (fictionBook != null && fictionBook.TitleInfo != null)
                {
                    foreach (SequenceInfoNode infoNode in fictionBook.TitleInfo.Sequences)
                    {
                        return String.Format("{0}", infoNode.Number);
                    }

                    return null;
                }


                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string DocumentId
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.Id;
                }

                if(fictionBook != null && fictionBook.DocumentInfo != null)
                {
                    return fictionBook.DocumentInfo.Id;
                }

                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string DocumentVersion
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.Version;
                }

                if(fictionBook != null && fictionBook.DocumentInfo != null)
                {
                    float? version = fictionBook.DocumentInfo.Version;
                    return version != null ? DocumentInfoNode.FormatVersion(version.Value) : null;
                }

                return null;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string FileName
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.FileName;
                }

                return documentEntry.Filename;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public long? FileSize
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.FileSize;
                }

                return documentEntry.FileSize;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public DateTime? FileDate
        {
            get
            {
                if(bookInfo != null)
                {
                    return bookInfo.FileDate;
                }

                return documentEntry.FileDate;
            }
        }
    }
}