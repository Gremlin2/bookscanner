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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;


namespace Gremlin.FB2Librarian.Import
{
    public enum ImportStatus
    {
        None = 0,
        ReadyToProcess = 1,
        Added = 2,
        Updated = 3,
        Duplicate = 4,
        DuplicateOlder = 5,
        DuplicateIDsDiffer = 6,
        DuplicateNewer = 7,
        ParsingError = 8,
        ArchiveError = 9,
        DatabaseError = 10,
        NeedDescription = 11,
        FilteredOut = 12
    }

    [XmlRoot("Entry")]
    public class XmlImportFileEntry
    {
        private bool selected;
        private ImportStatus status;
        private string displayText;
        private string uri;

        public XmlImportFileEntry()
        {
        }

        internal XmlImportFileEntry(ImportFileEntry fileEntry)
        {
            if (fileEntry == null)
            {
                throw new ArgumentNullException("fileEntry");
            }

            selected = fileEntry.Selected;
            status = fileEntry.Status;
            displayText = fileEntry.DisplayText;
            uri = fileEntry.Uri;
        }
        
        [XmlAttribute]
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
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

        [XmlAttribute]
        public string DisplayText
        {
            get
            {
                return this.displayText;
            }
            set
            {
                this.displayText = value;
            }
        }

        [XmlText]
        public string Uri
        {
            get
            {
                return this.uri;
            }
            set
            {
                this.uri = value;
            }
        }
    }

    [Obfuscation(Feature = "renaming", ApplyToMembers = false, Exclude = true, StripAfterObfuscation = true)]
    internal class ImportFileEntry : INotifyPropertyChanged
    {
        private bool selected;
        private ImportStatus status;
        private string filename;
        private string displayText;
        private readonly string uri;

        public event PropertyChangedEventHandler PropertyChanged;

        internal ImportFileEntry(XmlImportFileEntry entry)
        {
            selected = entry.Selected;
            status = entry.Status;
            displayText = entry.DisplayText;
            uri = entry.Uri;
        }

        public ImportFileEntry(string filename) : this(false, filename, null)
        {
            this.filename = filename;
        }

        public ImportFileEntry(string filename, string uri) : this(false, filename, uri)
        {
            this.filename = filename;
        }

        public ImportFileEntry(bool selected, string filename, string uri)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
            }

            this.selected = selected;
            this.uri = uri;

            this.displayText = GetFileName(filename);
        }

        private static String GetFileName(String path)
        {
            if (path != null)
            {
                int length = path.Length;
                for (int i = length; --i >= 0; )
                {
                    char ch = path[i];
                    if (ch == Path.DirectorySeparatorChar || ch == Path.AltDirectorySeparatorChar || ch == Path.VolumeSeparatorChar)
                    {
                        return path.Substring(i + 1, length - i - 1);
                    }
                }
            }

            return path;
        } 

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    NotifyPropertyChanged("Selected");
                }
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
        public string Uri
        {
            get
            {
                return this.uri;
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
                if (string.Compare(this.filename, value) != 0)
                {
                    this.filename = value;
                    this.displayText = Path.GetFileName(this.filename);
                }
            }
        }

        [Obfuscation(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        public string DisplayText
        {
            get
            {
                return this.displayText;
            }
        }
    }
}