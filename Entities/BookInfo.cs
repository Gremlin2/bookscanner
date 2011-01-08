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
using System.Data;

namespace Gremlin.FB2Librarian.Import.Entities
{
    [Table("BOOK")]
    public class BookInfo
    {
        private int bookid;
        private string genrelist;
        private string annotation;
        private string authorlist;
        private string keywords;
        private string booktitle;
        private DateTime? dateValue;
        private string dateText;
        private string lang;
        private string srcLang;
        private string sequence;
        private string sequenceNumber;
        private int? sequenceId;
        private string programmUsed;
        private DateTime? documentDateValue;
        private string documentDateText;
        private string srcUrl;
        private string srcOcr;
        private string id;
        private string version;
        private string history;
        private string bookName;
        private string publisher;
        private string city;
        private string year;
        private string isbn;
        private string customInfo;
        private DateTime? dateInserted;
        private DateTime? dateUpdated;
        private string surrogateId;
        private string extension;
        private long filesize;
        private string filename;
        private string filepath;
        private DateTime? filedate;
        private int? userid;
        private string username;

        [Column("BOOKID")]
        public int BookId
        {
            get
            {
                return this.bookid;
            }
            set
            {
                this.bookid = value;
            }
        }

        [Column("GENRELIST")]
        public string Genrelist
        {
            get
            {
                return this.genrelist;
            }
            set
            {
                this.genrelist = value;
            }
        }

        [Column("ANNOTATION")]
        public string Annotation
        {
            get
            {
                return this.annotation;
            }
            set
            {
                this.annotation = value;
            }
        }

        [Column("AUTORLIST")]
        public string AuthorList
        {
            get
            {
                return this.authorlist;
            }
            set
            {
                this.authorlist = value;
            }
        }

        [Column("KEYWORDS")]
        public string Keywords
        {
            get
            {
                return this.keywords;
            }
            set
            {
                this.keywords = value;
            }
        }

        [Column("BOOKNAME")]
        public string BookTitle
        {
            get
            {
                return this.booktitle;
            }
            set
            {
                this.booktitle = value;
            }
        }

        [Column("DATEVALUE")]
        public DateTime? DateValue
        {
            get
            {
                return this.dateValue;
            }
            set
            {
                this.dateValue = value;
            }
        }

        [Column("DATEVISIBLE")]
        public string DateText
        {
            get
            {
                return this.dateText;
            }
            set
            {
                this.dateText = value;
            }
        }

        [Column("LANG")]
        public string Lang
        {
            get
            {
                return this.lang;
            }
            set
            {
                this.lang = value;
            }
        }

        [Column("SRCLANG")]
        public string SrcLang
        {
            get
            {
                return this.srcLang;
            }
            set
            {
                this.srcLang = value;
            }
        }

        [Column("SEQUENCE")]
        public string Sequence
        {
            get
            {
                return this.sequence;
            }
            set
            {
                this.sequence = value;
            }
        }

        [Column("SEQNUMBER")]
        public string SequenceNumber
        {
            get
            {
                return this.sequenceNumber;
            }
            set
            {
                this.sequenceNumber = value;
            }
        }

        [Column("SEQUENCEID")]
        public int? SequenceId
        {
            get
            {
                return this.sequenceId;
            }
            set
            {
                this.sequenceId = value;
            }
        }

        [Column("DI_PROGUSED")]
        public string ProgrammUsed
        {
            get
            {
                return this.programmUsed;
            }
            set
            {
                this.programmUsed = value;
            }
        }

        [Column("DI_DATEVALUE")]
        public DateTime? DocumentDateValue
        {
            get
            {
                return this.documentDateValue;
            }
            set
            {
                this.documentDateValue = value;
            }
        }

        [Column("DI_DATEVISIBLE")]
        public string DocumentDateText
        {
            get
            {
                return this.documentDateText;
            }
            set
            {
                this.documentDateText = value;
            }
        }

        [Column("DI_SRCURL")]
        public string SrcUrl
        {
            get
            {
                return this.srcUrl;
            }
            set
            {
                this.srcUrl = value;
            }
        }

        [Column("DI_SRCOCR")]
        public string SrcOcr
        {
            get
            {
                return this.srcOcr;
            }
            set
            {
                this.srcOcr = value;
            }
        }

        [Column("OLDID")]
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [Column("DI_VERSION")]
        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        [Column("DI_HISTORY")]
        public string History
        {
            get
            {
                return this.history;
            }
            set
            {
                this.history = value;
            }
        }

        [Column("PI_BOOKNAME")]
        public string BookName
        {
            get
            {
                return this.bookName;
            }
            set
            {
                this.bookName = value;
            }
        }

        [Column("PI_PUBLISHER")]
        public string Publisher
        {
            get
            {
                return this.publisher;
            }
            set
            {
                this.publisher = value;
            }
        }

        [Column("PI_CITY")]
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        [Column("PI_YEAR")]
        public string Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        [Column("PI_ISBN")]
        public string Isbn
        {
            get
            {
                return this.isbn;
            }
            set
            {
                this.isbn = value;
            }
        }

        [Column("CUSTOMINFO")]
        public string CustomInfo
        {
            get
            {
                return this.customInfo;
            }
            set
            {
                this.customInfo = value;
            }
        }

        [Column("DATEIN")]
        public DateTime? DateInserted
        {
            get
            {
                return this.dateInserted;
            }
            set
            {
                this.dateInserted = value;
            }
        }

        [Column("DATEUPDATED")]
        public DateTime? DateUpdated
        {
            get
            {
                return this.dateUpdated;
            }
            set
            {
                this.dateUpdated = value;
            }
        }

        [Column("MYID")]
        public string SurrogateId
        {
            get
            {
                return this.surrogateId;
            }
            set
            {
                this.surrogateId = value;
            }
        }

        [Column("EXT")]
        public string Extension
        {
            get
            {
                return this.extension;
            }
            set
            {
                this.extension = value;
            }
        }

        [Column("FILESIZE")]
        public long FileSize
        {
            get
            {
                return this.filesize;
            }
            set
            {
                this.filesize = value;
            }
        }

        [Column("FILENAME")]
        public string FileName
        {
            get
            {
                return this.filename;
            }
            set
            {
                this.filename = value;
            }
        }

        [Column("FILEPATH")]
        public string FilePath
        {
            get
            {
                return this.filepath;
            }
            set
            {
                this.filepath = value;
            }
        }

        [Column("FILEDATE")]
        public DateTime? FileDate
        {
            get
            {
                return this.filedate;
            }
            set
            {
                this.filedate = value;
            }
        }

        [Column("USERID")]
        public int? Userid
        {
            get
            {
                return this.userid;
            }
            set
            {
                this.userid = value;
            }
        }

        [Column("USERNAME")]
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }
    }
}
