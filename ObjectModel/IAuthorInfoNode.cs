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
using System.Xml;

namespace Gremlin.FB2Librarian.Import.ObjectModel
{
    public interface IFictionBook
    {
        IDocumentInfoNode DocumentInfoNode { get; }
        ITitleInfoNode TitleInfoNode { get; }
        ITitleInfoNode SrcTitleInfoNode { get; }
        IPublishInfoNode PublishInfoNode { get; }
    }

    public interface IDocumentNode
    {
        void Load(XmlElement parentNode);
        XmlElement Store(XmlDocument document, XmlElement element);
        bool IsEmpty();
    }

    public interface IAuthorInfoNode : IDocumentNode
    {
        string Id { get; set; }

        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NickName { get; set; }
        
        IList<string> Homepage { get; }
        IList<string> Email { get; }

        string DisplayName { get; }
    }

    public interface IDocumentInfoNode : IDocumentNode
    {
        IList<IAuthorInfoNode> Authors { get; }
        string ProgramUsed { get; set; }
        DateTime? Date { get; set; }
        IList<string> SourceUrl { get; }
        string SourceOCR { get; set; }
        string Id { get; set; }
        float? Version { get; set; }
        string History { get; set; }
        IList<IAuthorInfoNode> Publishers { get; }
    }

    public interface IGenreInfoNode : IDocumentNode
    {
        string Genre { get; set; }
        int? Match { get; set; }
    }

    public interface ISequenceInfoNode : IDocumentNode
    {
        string Name { get; set; }
        int? Number { get; set; }
    }

    public interface IAnnotationInfoNode : IDocumentNode
    {
        string Id { get; set; }
        string Annotation { get; set; }
    }

    public interface ITitleInfoNode : IDocumentNode
    {
        IList<IGenreInfoNode> Genres { get; }
        IList<IAuthorInfoNode> Authors { get; }
        string BookTitle { get; set; }
        IAnnotationInfoNode Annotation { get; set; }
        string Keywords { get; set; }
        DateTime? Date { get; set; }
        string Lang { get; set; }
        string SourceLang { get; set; }
        IList<IAuthorInfoNode> Translators { get; }
        IList<ISequenceInfoNode> Sequences { get; }
    }

    public interface IPublishInfoNode
    {
        string BookName { get; set; }
        string Publisher { get; set; }
        string City { get; set; }
        int? Year { get; set; }
        string ISBN { get; set; }
        IList<ISequenceInfoNode> Sequences { get; }
    }
}