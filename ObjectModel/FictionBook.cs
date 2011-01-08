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
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

using Gremlin.FB2Librarian.Import.Utils;

namespace Gremlin.FB2Librarian.Import.ObjectModel
{
    public class FictionBook : IFictionBook
    {
        private static Regex librusecIdPattern;

        private readonly XmlDocument document;

        private DocumentInfoNode documentInfo;
        private TitleInfoNode titleInfo;
        private TitleInfoNode srcTitleInfo;
        private PublishInfoNode publishInfo;
        
        private XmlNode documentInfoNode;
        private XmlNode titleInfoNode;
        private XmlNode srcTitleInfoNode;
        private XmlNode publishInfoNode;

        private XmlNode descriptionNode;

        //private Fb2FixStatus documentStatus;
        //private ModificationType modificationType;
        private DateTime containerDateTime;
        private Encoding documentEncoding;

        static FictionBook()
        {
            librusecIdPattern = new Regex(@"^\w{3}\s\w{3}\s\d{1,2}\s\d{2}:\d{2}:\d{2}\s\d{4}$");
        }

        public DocumentInfoNode DocumentInfo
        {
            get
            {
                return this.documentInfo;
            }
        }

        public TitleInfoNode TitleInfo
        {
            get
            {
                return this.titleInfo;
            }
        }

        public TitleInfoNode SrcTitleInfo
        {
            get
            {
                return this.srcTitleInfo;
            }
        }

        public PublishInfoNode PublishInfo
        {
            get
            {
                return this.publishInfo;
            }
        }

        public IDocumentInfoNode DocumentInfoNode
        {
            get
            {
                return this.documentInfo;
            }
        }

        public ITitleInfoNode TitleInfoNode
        {
            get
            {
                return this.titleInfo;
            }
        }

        public ITitleInfoNode SrcTitleInfoNode
        {
            get
            {
                return this.srcTitleInfo;
            }
        }

        public IPublishInfoNode PublishInfoNode
        {
            get
            {
                return this.publishInfo;
            }
        }

        public XmlNode DescriptionNode
        {
            get
            {
                return this.descriptionNode;
            }
        }

        public XmlDocument Document
        {
            get
            {
                return this.document;
            }
        }

        public Encoding DocumentEncoding
        {
            get
            {
                return this.documentEncoding;
            }
        }
        
        //public Fb2FixStatus DocumentStatus
        //{
        //    get 
        //    {
        //        return this.documentStatus;
        //    }

        //    set
        //    {
        //        if(this.documentStatus != value)
        //        {
        //            ChangeDocumentStatus(value);
        //            this.documentStatus = value;
        //        }
        //    }
        //}

        //public ModificationType ModificationType
        //{
        //    get
        //    {
        //        return this.modificationType;
        //    }

        //    set
        //    {
        //        this.modificationType |= value;
        //    }
        //}

        //public bool Modified
        //{
        //    get
        //    {
        //        return (this.modificationType != ModificationType.None);
        //    }
        //}

        public float Version
        {
            get
            {
                return this.documentInfo.Version ?? 0.0f;
            }

            set
            {
                if((this.documentInfo.Version ?? 0.0) != value)
                {
                    ChangeDocumentVersion(value);
                    this.documentInfo.Version = value;
                }
            }
        }

        public DateTime ContainerDateTime
        {
            get
            {
                return this.containerDateTime;
            }
            set
            {
                this.containerDateTime = value;
            }
        }

        public FictionBook(XmlDocument document, Encoding documentEncoding)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            this.document = document;
            this.documentEncoding = documentEncoding;

            if (document.DocumentElement == null)
            {
                throw new InvalidFictionBookFormatException();
            }

            XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
            nsManager.AddNamespace("fb", document.DocumentElement.NamespaceURI);

            //this.documentStatus = Fb2FixStatus.None;

            //XmlNode statusInfoNode = document.SelectSingleNode("//FictionBook/description/custom-info[@info-type='fb2fix-status']");
            //if (statusInfoNode != null && statusInfoNode.NodeType == XmlNodeType.Element)
            //{
            //    if (String.IsNullOrEmpty(statusInfoNode.InnerText))
            //    {
            //        try
            //        {
            //            this.documentStatus = (Fb2FixStatus)Enum.Parse(typeof(Fb2FixStatus), statusInfoNode.InnerText, true);
            //        }
            //        catch (ArgumentException)
            //        {
            //        }
            //    }
            //}

            this.documentInfoNode = document.SelectSingleNode("//fb:FictionBook/fb:description/fb:document-info", nsManager);
            if (this.documentInfoNode != null && this.documentInfoNode.NodeType == XmlNodeType.Element)
            {
                documentInfo = new DocumentInfoNode();
                documentInfo.NamespaceManager = nsManager;
                documentInfo.Load(this.documentInfoNode as XmlElement);
            }

            this.titleInfoNode = document.SelectSingleNode("//fb:FictionBook/fb:description/fb:title-info", nsManager);
            if (this.titleInfoNode != null && this.titleInfoNode.NodeType == XmlNodeType.Element)
            {
                titleInfo = new TitleInfoNode();
                titleInfo.NamespaceManager = nsManager;
                titleInfo.Load(this.titleInfoNode as XmlElement);
            }

            if (titleInfo == null)
            {
                throw new InvalidFictionBookFormatException();
            }

            this.srcTitleInfoNode = document.SelectSingleNode("//fb:FictionBook/fb:description/fb:src-title-info", nsManager);
            if (this.srcTitleInfoNode != null && this.srcTitleInfoNode.NodeType == XmlNodeType.Element)
            {
                srcTitleInfo = new TitleInfoNode();
                srcTitleInfo.NamespaceManager = nsManager;
                srcTitleInfo.Load(this.srcTitleInfoNode as XmlElement);
            }

            this.publishInfoNode = document.SelectSingleNode("//fb:FictionBook/fb:description/fb:publish-info", nsManager);
            if (this.publishInfoNode != null && this.publishInfoNode.NodeType == XmlNodeType.Element)
            {
                publishInfo = new PublishInfoNode();
                publishInfo.NamespaceManager = nsManager;
                publishInfo.Load(this.publishInfoNode as XmlElement);
            }

            this.descriptionNode = document.SelectSingleNode("//fb:FictionBook/fb:description", nsManager);

            if (this.descriptionNode == null)
            {
                throw new InvalidFictionBookFormatException();
            }

            //this.modificationType = ModificationType.None;
            this.containerDateTime = DateTime.Now;
        }

        public byte[] CoverpageImage
        {
            get
            {
                byte[] coverpage = null;

                if (this.titleInfo.Coverpage != null)
                {
                    XmlNodeList imageNodes = this.titleInfo.Coverpage.SelectNodes("./fb:image", this.titleInfo.NamespaceManager);
                    foreach (XmlNode imageNode in imageNodes)
                    {
                        if (imageNode != null && imageNode.NodeType == XmlNodeType.Element)
                        {
                            foreach (XmlAttribute hrefAttr in imageNode.Attributes)
                            {
                                if (String.Compare(hrefAttr.LocalName, "href") == 0)
                                {
                                    if (!String.IsNullOrEmpty(hrefAttr.Value) && hrefAttr.Value.StartsWith("#"))
                                    {
                                        string coverpageId = hrefAttr.Value.Substring(1);

                                        XmlNode binaryNode = this.document.SelectSingleNode("//fb:FictionBook/fb:binary[@id='" + coverpageId + "']", this.titleInfo.NamespaceManager);
                                        if (binaryNode != null && binaryNode.NodeType == XmlNodeType.Element)
                                        {
                                            try
                                            {
                                                coverpage = Convert.FromBase64String(binaryNode.InnerText);
                                            }
                                            catch (FormatException)
                                            {
                                                coverpage = StringUtils.FromBase64(StringUtils.FilterBin64(binaryNode.InnerText));
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            if (coverpage != null)
                            {
                                break;
                            }
                        }
                    }
                }

                return coverpage;
            }
        }

        //private void ChangeDocumentStatus(Fb2FixStatus status)
        //{
        //    XmlNode statusInfoNode = document.SelectSingleNode("//FictionBook/description/custom-info[@info-type='fb2fix-status']");
        //    if (statusInfoNode != null && statusInfoNode.NodeType == XmlNodeType.Element)
        //    {
        //        statusInfoNode.InnerText = Enum.GetName(typeof(Fb2FixStatus), status);
        //    }
        //    else
        //    {
        //        XmlElement xmlStatusNode = document.CreateElement("custom-info");
        //        xmlStatusNode.InnerText = Enum.GetName(typeof(Fb2FixStatus), Fb2FixStatus.Passed);

        //        XmlAttribute statusAttr = document.CreateAttribute("info-type");
        //        statusAttr.Value = "fb2fix-status";

        //        xmlStatusNode.Attributes.Append(statusAttr);

        //        this.descriptionNode.AppendChild(xmlStatusNode);
        //    }
        //}

        private void ChangeDocumentVersion(float version)
        {
            XmlNode versionInfoNode = document.SelectSingleNode("//FictionBook/description/document-info/version");
            if (versionInfoNode != null && versionInfoNode.NodeType == XmlNodeType.Element)
            {
                versionInfoNode.InnerText = ObjectModel.DocumentInfoNode.FormatVersion(version);
            }
            else
            {
                throw new InvalidFictionBookFormatException();
            }
        }

        //private static string ComputeDocumentId(string value)
        //{
        //    byte[] hash;
        //    StringBuilder documentId = new StringBuilder(40);

        //    MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
        //    hash = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(value));

        //    documentId.Append("fb2-");

        //    for (int index = 0; index < hash.Length; index++)
        //    {
        //        switch (index)
        //        {
        //            case 4:
        //            case 6:
        //            case 8:
        //            case 10:
        //                documentId.Append("-");
        //                documentId.Append(hash[index].ToString("X2"));
        //                break;

        //            default:
        //                documentId.Append(hash[index].ToString("X2"));
        //                break;
        //        }
        //    }

        //    return documentId.ToString();
        //}

        //public void CheckDocumentHeader(Fb2FixArguments options)
        //{
        //    foreach (TitleInfoNode infoNode in new TitleInfoNode[] { titleInfo, srcTitleInfo })
        //    {
        //        if (infoNode == null)
        //        {
        //            continue;
        //        }

        //        if (infoNode.Genres.Count == 0)
        //        {
        //            infoNode.Genres.Add(new GenreInfoNode("nonfiction"));
        //            this.modificationType |= ModificationType.Description;
        //        }

        //        foreach (AuthorInfoNode author in infoNode.Authors)
        //        {
        //            if (author.FirstName == null && author.LastName != null)
        //            {
        //                author.FirstName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if (author.FirstName != null && author.LastName == null)
        //            {
        //                author.LastName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if ((String.IsNullOrEmpty(author.FirstName) && String.IsNullOrEmpty(author.LastName)) && String.IsNullOrEmpty(author.NickName))
        //            {
        //                author.NickName = "FB2Fix";
        //                this.modificationType |= ModificationType.Description;
        //            }
        //        }

        //        if (String.IsNullOrEmpty(infoNode.BookTitle))
        //        {
        //            if (publishInfo != null && !String.IsNullOrEmpty(publishInfo.BookName))
        //            {
        //                infoNode.BookTitle = publishInfo.BookName;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else
        //            {
        //                throw new InvalidFictionBookFormatException();
        //            }
        //        }

        //        if (String.IsNullOrEmpty(infoNode.Lang))
        //        {
        //            infoNode.Lang = "ru";
        //            this.modificationType |= ModificationType.Description;
        //        }

        //        foreach (AuthorInfoNode author in infoNode.Translators)
        //        {
        //            if (author.FirstName == null && author.LastName != null)
        //            {
        //                author.FirstName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if (author.FirstName != null && author.LastName == null)
        //            {
        //                author.LastName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if ((String.IsNullOrEmpty(author.FirstName) && String.IsNullOrEmpty(author.LastName)) && String.IsNullOrEmpty(author.NickName))
        //            {
        //                author.NickName = "FB2Fix";
        //                this.modificationType |= ModificationType.Description;
        //            }
        //        }
        //    }

        //    if (options.mapGenres)
        //    {
        //        foreach (TitleInfoNode infoNode in new TitleInfoNode[] { titleInfo, srcTitleInfo })
        //        {
        //            if (infoNode == null)
        //            {
        //                continue;
        //            }

        //            foreach (GenreInfoNode genre in infoNode.Genres)
        //            {
        //                if(!genre.IsEmpty())
        //                {
        //                    if(GenreTable.Table.MapTable.ContainsKey(genre.Genre))
        //                    {
        //                        genre.Genre = GenreTable.Table.MapTable[genre.Genre];
        //                        this.modificationType |= ModificationType.Description;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (documentInfo == null)
        //    {
        //        documentInfo = new DocumentInfoNode();

        //        AuthorInfoNode documentAuthor = new AuthorInfoNode();
        //        documentAuthor.NickName = "FB2Fix";

        //        documentInfo.Authors.Add(documentAuthor);
        //        documentInfo.Id = ComputeDocumentId(document.DocumentElement.InnerText);
        //        documentInfo.Date = DateTime.Now;
        //        documentInfo.ProgramUsed = "FB2Fix";
        //        documentInfo.Version = 0.0f;

        //        this.modificationType |= ModificationType.DocumentInfo;
        //    }
        //    else
        //    {
        //        foreach (AuthorInfoNode author in documentInfo.Authors)
        //        {
        //            if (author.FirstName == null && author.LastName != null)
        //            {
        //                author.FirstName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if (author.FirstName != null && author.LastName == null)
        //            {
        //                author.LastName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if ((String.IsNullOrEmpty(author.FirstName) && String.IsNullOrEmpty(author.LastName)) && String.IsNullOrEmpty(author.NickName))
        //            {
        //                author.NickName = "FB2Fix";
        //                this.modificationType |= ModificationType.Description;
        //            }
        //        }

        //        if (documentInfo.Date == null)
        //        {
        //            documentInfo.Date = DateTime.Now;
        //            this.modificationType |= ModificationType.Description;
        //        }

        //        if (documentInfo.Version == null)
        //        {
        //            documentInfo.Version = 0.0f;
        //            this.modificationType |= ModificationType.DocumentInfo;
        //        }

        //        if (String.Compare(documentInfo.ProgramUsed, "LibRusEc kit", true, CultureInfo.InvariantCulture) == 0)
        //        {
        //            //@"^\w{3}\s\w{3}\s\d{1,2}\s\d{2}:\d{2}:\d{2}\s\d{4}$"
        //            if (librusecIdPattern.Match(documentInfo.Id).Success)
        //            {
        //                if (document.SelectSingleNode("//FictionBook/description/custom-info[@info-type='librusec-id']") == null)
        //                {
        //                    XmlElement xmlLibRusEcId = document.CreateElement("custom-info");
        //                    xmlLibRusEcId.InnerText = documentInfo.Id;

        //                    XmlAttribute attr = document.CreateAttribute("info-type");
        //                    attr.Value = "librusec-id";

        //                    xmlLibRusEcId.Attributes.Append(attr);
        //                    this.descriptionNode.AppendChild(xmlLibRusEcId);

        //                    documentInfo.Id = ComputeDocumentId(document.DocumentElement.InnerText);
        //                    this.modificationType |= ModificationType.Description;
        //                }
        //            }
        //        }

        //        if (String.IsNullOrEmpty(documentInfo.Id))
        //        {
        //            documentInfo.Id = ComputeDocumentId(document.DocumentElement.InnerText);
        //            this.modificationType |= ModificationType.Description;
        //        }

        //        foreach (AuthorInfoNode publsher in documentInfo.Publishers)
        //        {
        //            if (publsher.FirstName == null && publsher.LastName != null)
        //            {
        //                publsher.FirstName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if (publsher.FirstName != null && publsher.LastName == null)
        //            {
        //                publsher.LastName = String.Empty;
        //                this.modificationType |= ModificationType.Description;
        //            }
        //            else if ((String.IsNullOrEmpty(publsher.FirstName) && String.IsNullOrEmpty(publsher.LastName)) && String.IsNullOrEmpty(publsher.NickName))
        //            {
        //                publsher.NickName = "FB2Fix";
        //                this.modificationType |= ModificationType.Description;
        //            }
        //        }
        //    }

        //    XmlElement xmlNewTitleInfo = document.CreateElement("title-info");
        //    xmlNewTitleInfo = titleInfo.Store(document, xmlNewTitleInfo);
        //    this.descriptionNode.ReplaceChild(xmlNewTitleInfo, titleInfoNode);
        //    titleInfoNode = xmlNewTitleInfo;

        //    if (srcTitleInfo != null)
        //    {
        //        XmlElement xmlNewSrcTitleInfo = document.CreateElement("src-title-info");
        //        xmlNewSrcTitleInfo = srcTitleInfo.Store(document, xmlNewSrcTitleInfo);
        //        this.descriptionNode.ReplaceChild(xmlNewSrcTitleInfo, srcTitleInfoNode);
        //        srcTitleInfoNode = xmlNewSrcTitleInfo;
        //    }

        //    XmlElement xmlNewDocumentInfo = document.CreateElement("document-info");
        //    xmlNewDocumentInfo = documentInfo.Store(document, xmlNewDocumentInfo);
        //    if (documentInfoNode == null)
        //    {
        //        if (srcTitleInfoNode == null)
        //        {
        //            this.descriptionNode.InsertAfter(xmlNewDocumentInfo, titleInfoNode);
        //        }
        //        else
        //        {
        //            this.descriptionNode.InsertAfter(xmlNewDocumentInfo, srcTitleInfoNode);
        //        }
        //    }
        //    else
        //    {
        //        this.descriptionNode.ReplaceChild(xmlNewDocumentInfo, documentInfoNode);
        //    }

        //    if (publishInfo != null)
        //    {
        //        XmlElement xmlNewPublishInfo = document.CreateElement("publish-info");
        //        xmlNewPublishInfo = publishInfo.Store(document, xmlNewPublishInfo);

        //        this.descriptionNode.ReplaceChild(xmlNewPublishInfo, publishInfoNode);
        //    }
        //}
    }
}
