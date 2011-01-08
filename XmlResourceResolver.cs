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
using System.IO;
using System.Text;
using System.Xml;
using System.Net;
using System.Reflection;

namespace Gremlin.FB2Librarian.Import
{
    internal class XmlResourceResolver : XmlUrlResolver
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            if (absoluteUri == null)
            {
                throw new ArgumentNullException("absoluteUri");
            }

            if (absoluteUri.IsFile)
            {
                string filename = Path.GetFileName(absoluteUri.AbsolutePath);

                if (!String.IsNullOrEmpty(filename))
                {
                    return Assembly.GetExecutingAssembly().GetManifestResourceStream("Gremlin.FB2Librarian.Import.Resources." + filename);
                }
            }

            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
    }
}
