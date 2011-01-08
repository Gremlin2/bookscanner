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
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

using DevExpress.XtraEditors;

using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Utils;

using HTMLayout;

namespace Gremlin.FB2Librarian.Import
{
    public partial class BookPreviewForm : XtraForm
    {
        private readonly XslCompiledTransform xslt;
        private FictionBook fictionBook;

        public BookPreviewForm()
        {
            InitializeComponent();

            XsltSettings settings = new XsltSettings();

            this.xslt = new XslCompiledTransform(true);
            this.xslt.Load("htmlconv.xsl", settings, new XmlResourceResolver());
        }

        public void LoadFrom(FictionBook book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            fictionBook = book;

            Text = book.TitleInfo.BookTitle;

            using (StringWriter writer = new StringWriter())
            {
                XsltArgumentList arguments = new XsltArgumentList();

                this.xslt.Transform(book.Document, arguments, writer);

                htmlViewer.Text = writer.ToString();
            }
        }

        private void BookPreviewForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void htmlViewer_ResourceRequested(object sender, ResourceRequestedEventArgs args)
        {
            if(fictionBook != null)
            {
                XmlNode binaryNode = fictionBook.Document.SelectSingleNode("//fb:binary[@id='" + args.Url + "']", fictionBook.TitleInfo.NamespaceManager);
                if(binaryNode != null)
                {
                    byte[] resource = null;
                    try
                    {
                        resource = Convert.FromBase64String(binaryNode.InnerText);
                    }
                    catch (FormatException)
                    {
                        resource = StringUtils.FromBase64(StringUtils.FilterBin64(binaryNode.InnerText));
                    }

                    htmlViewer.ProvideResource(args.Url, resource);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog(this);
        }
    }
}
