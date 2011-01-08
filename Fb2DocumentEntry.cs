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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Gremlin.FB2Librarian.Import
{
    [XmlRoot("Book")]
    public class XmlFb2DocumentEntry
    {
        private readonly static Regex invalidChars;
        
        private int? bookid;
        private ImportStatus status;
        private string filename;
        private string originalFilename;
        private DateTime? filedate;
        private long filesize;
        private string errorText;

        static XmlFb2DocumentEntry()
        {
            invalidChars = new Regex("[\u0001-\u0008\u000b\u000c\u000e-\u001f]");
        }

        public XmlFb2DocumentEntry()
        {
        }

        internal XmlFb2DocumentEntry(Fb2DocumentEntry documentEntry)
        {
            if (documentEntry == null)
            {
                throw new ArgumentNullException("documentEntry");
            }

            bookid = documentEntry.BookId;
            status = documentEntry.Status;
            filename = documentEntry.Filename;
            originalFilename = documentEntry.OriginalFileName;
            filedate = documentEntry.FileDate;
            filesize = documentEntry.FileSize;

            errorText = !String.IsNullOrEmpty(documentEntry.ErrorText) ? invalidChars.Replace(documentEntry.ErrorText, " ") : null;
        }

        [XmlElement]
        public int? BookId
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

        [XmlAttribute]
        public ImportStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        [XmlElement]
        public string Filename
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

        [XmlElement]
        public string OriginalFileName
        {
            get
            {
                return this.originalFilename;
            }
            set
            {
                this.originalFilename = value;
            }
        }

        [XmlElement]
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

        [XmlElement]
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

        [XmlElement]
        public string ErrorText
        {
            get
            {
                return this.errorText;
            }
            set
            {
                this.errorText = value;
            }
        }
    }

    [Obfuscation(Feature = "renaming", ApplyToMembers = false, Exclude = true, StripAfterObfuscation = true)]
    internal class Fb2DocumentEntry
    {
        private int? bookid;
        private ImportStatus status;
        private string filename;
        private string originalFilename;
        private DateTime? filedate;
        private long filesize;
        private string errorText;

        internal Fb2DocumentEntry()
        {
        }

        internal Fb2DocumentEntry(XmlFb2DocumentEntry documentEntry)
        {
            if (documentEntry == null)
            {
                throw new ArgumentNullException("documentEntry");
            }

            bookid = documentEntry.BookId;
            status = documentEntry.Status;
            filename = documentEntry.Filename;
            originalFilename = documentEntry.OriginalFileName;
            filedate = documentEntry.FileDate;
            filesize = documentEntry.FileSize;
            errorText = documentEntry.ErrorText;
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public int? BookId
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

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public ImportStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string Filename
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

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string OriginalFileName
        {
            get
            {
                return this.originalFilename;
            }

            set
            {
                this.originalFilename = value;
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
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

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
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

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string ErrorText
        {
            get
            {
                return this.errorText;
            }
            set
            {
                this.errorText = value;
            }
        }
    }
}
