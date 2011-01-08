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
using System.Xml;

namespace Gremlin.FB2Librarian.Import.ObjectModel
{
    public class AnnotationInfoNode : DocumentNode, IAnnotationInfoNode
    {
        private XmlElement annotation;
        private string annotationText;
        private string id;

        public AnnotationInfoNode()
        {
        }

        public XmlElement AnnotationNode
        {
            get
            {
                return this.annotation;
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

        public string Annotation
        {
            get
            {
                if(annotation != null)
                {
                    return annotation.InnerText;
                }

                return annotationText;
            }

            set
            {
                if(annotation != null)
                {
                    annotation.InnerText = value;
                }

                annotationText = value;
            }
        }

        public override void Load(XmlElement parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException("parentNode");
            }

            this.annotation = null;
            this.id = null;

            this.annotation = LoadElementXml(parentNode, ".");

            XmlAttribute attr = parentNode.Attributes["id"];
            if (attr != null && !String.IsNullOrEmpty(attr.Value))
            {
                this.id = attr.Value;
            }
        }

        public override XmlElement Store(XmlDocument document, XmlElement element)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if(this.IsEmpty())
            {
                return null;
            }

            if(this.annotation != null)
            {
                element = this.annotation;
            }
            else
            {
                annotation = document.CreateElement("annotation");
                annotation.InnerText = annotationText;

                element = annotation;
            }

            if(this.id != null)
            {
                XmlAttribute attribute = document.CreateAttribute("id");
                attribute.Value = this.id;
                element.Attributes.Append(attribute);
            }

            return element;
        }

        public override bool IsEmpty()
        {
            return (this.annotation == null && String.IsNullOrEmpty(annotationText));
        }
    }
}
