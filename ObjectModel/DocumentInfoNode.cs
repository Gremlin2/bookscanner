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
using System.Globalization;
using System.Text;
using System.Xml;

namespace Gremlin.FB2Librarian.Import.ObjectModel
{

    public class DocumentInfoNode : DocumentNode, IDocumentInfoNode
    {
        private List<IAuthorInfoNode> authors;
        private string programUsed;
        private DateTimeNode date;
        private List<string> sourceUrl;
        private string sourceOCR;
        private string id;
        private float? version;
        private XmlElement history;
        private String historyText;
        private List<IAuthorInfoNode> publishers;

        public DocumentInfoNode()
        {
            this.authors = new List<IAuthorInfoNode>();
            this.sourceUrl = new List<string>();
            this.publishers = new List<IAuthorInfoNode>();
        }

        public IList<IAuthorInfoNode> Authors
        {
            get
            {
                return this.authors;
            }
        }

        public string ProgramUsed
        {
            get
            {
                return this.programUsed;
            }
            set
            {
                this.programUsed = value;
            }
        }

        public DateTime? Date
        {
            get
            {
                if (this.date != null)
                {
                    if (this.date.Value != null)
                    {
                        return this.date.Value;
                    }

                    return DateTime.MinValue;
                }

                return null;
            }
            set
            {
                if (this.date == null)
                {
                    this.date = new DateTimeNode();
                }

                this.date.Value = value;
            }
        }

        public DateTimeNode DateNode
        {
            get
            {
                return this.date;
            }
        }

        public IList<string> SourceUrl
        {
            get
            {
                return this.sourceUrl;
            }
        }

        public string SourceOCR
        {
            get
            {
                return this.sourceOCR;
            }
            set
            {
                this.sourceOCR = value;
            }
        }

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

        public float? Version
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

        public string History
        {
            get
            {
                if(history == null)
                {
                    return null;
                }

                return history.InnerText;
            }

            set
            {
                if(history == null)
                {
                    historyText = value;
                }
                else
                {
                    history.InnerText = value;
                }
            }
        }

        public XmlElement HistoryNode
        {
            get
            {
                return this.history;
            }
        }

        public IList<IAuthorInfoNode> Publishers
        {
            get
            {
                return this.publishers;
            }
        }

        public override void Load(XmlElement parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException("parentNode");
            }

            this.authors = LoadObjectList<IAuthorInfoNode, AuthorInfoNode>(parentNode, "./fb:author");

            this.programUsed = LoadElement(parentNode, "./fb:program-used");
            this.date = LoadObject<DateTimeNode>(parentNode, "./fb:date");
            this.sourceUrl = LoadElementsList(parentNode, "./fb:src-url");
            this.sourceOCR = LoadElement(parentNode, "./fb:src-ocr");
            this.id = LoadElement(parentNode, "./fb:id");
            this.history = LoadElementXml(parentNode, "./fb:history");
            this.publishers = LoadObjectList<IAuthorInfoNode, AuthorInfoNode>(parentNode, "./fb:publisher");

            try
            {
                this.version = float.Parse(LoadElement(parentNode, "./fb:version"), CultureInfo.InvariantCulture);
            }
            catch
            {
                this.version = null;
            }
        }

        public static string FormatVersion(float value)
        {
            int index;
            string versionString = value.ToString("F5", CultureInfo.InvariantCulture);

            for (index = versionString.Length - 1; index >= 0; index--)
            {
                if(versionString[index] == '.' || versionString[index] != '0')
                {
                    break;
                }
            }

            if(versionString[index] == '.')
            {
                index++;
            }

            versionString = versionString.Substring(0, index + 1);

            return versionString;
        }

        public override XmlElement Store(XmlDocument document, XmlElement element)
        {
            XmlElement childElement;

            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            foreach (AuthorInfoNode authorInfoNode in authors)
            {
                childElement = document.CreateElement("author");
                if ((childElement = authorInfoNode.Store(document, childElement)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            if ((childElement = StoreElement(document, "program-used", this.programUsed)) != null)
            {
                element.AppendChild(childElement);
            }

            if (this.date != null)
            {
                childElement = document.CreateElement("date");
                if ((childElement = this.date.Store(document, childElement)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            foreach (string value in this.sourceUrl)
            {
                if ((childElement = StoreElement(document, "src-url", value)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            if ((childElement = StoreElement(document, "src-ocr", this.sourceOCR)) != null)
            {
                element.AppendChild(childElement);
            }

            if ((childElement = StoreElement(document, "id", this.id)) != null)
            {
                element.AppendChild(childElement);
            }
            
            if (this.version != null)
            {
                if ((childElement = StoreElement(document, "version", FormatVersion(this.version.Value))) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            if (this.history != null)
            {
                if ((childElement = StoreXmlElement(document, "history", this.history)) != null)
                {
                    element.AppendChild(childElement);
                }
            }
            else
            {
                if ((childElement = StoreElement(document, "history", this.historyText)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            foreach (AuthorInfoNode publisherInfoNode in this.publishers)
            {
                childElement = document.CreateElement("publisher");
                if ((childElement = publisherInfoNode.Store(document, childElement)) != null)
                {
                    element.AppendChild(childElement);
                }
            }

            if(element.ChildNodes.Count == 0)
            {
                return null;
            }

            return element;
        }

        public override bool IsEmpty()
        {
            return false;
        }
    }
}
