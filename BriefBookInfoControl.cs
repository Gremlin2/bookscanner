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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraLayout;

namespace Gremlin.FB2Librarian.Import
{
    public partial class BriefBookInfoControl : UserControl
    {
        private BriefBookInfo dataSource;

        public BriefBookInfoControl()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        internal BriefBookInfo DataSource
        {
            get
            {
                return this.dataSource;
            }

            set
            {
                if (this.dataSource != value)
                {
                    this.dataSource = value;
                    OnDataSourceChanged();
                }
            }
        }

        protected virtual void OnDataSourceChanged()
        {
            txtAuthor.AddBinding(this.dataSource, "Authors");
            txtTitle.AddBinding(this.dataSource, "BookTitle");
            txtBookSequence.AddBinding(this.dataSource, "BookSequence");
            txtBookSequenceNumber.AddBinding(this.dataSource, "BookSequenceNumber");
            txtGenres.AddBinding(this.dataSource, "Genres");
            txtDocumentId.AddBinding(this.dataSource, "DocumentId");
            txtVersion.AddBinding(this.dataSource, "DocumentVersion");
            txtFileName.AddBinding(this.dataSource, "FileName");
            txtFileSize.AddBinding(this.dataSource, "FileSize");
            txtFileDate.AddBinding(this.dataSource, "FileDate");

        }

        private void txtFileName_EditValueChanged(object sender, EventArgs e)
        {
        //    Size preferredSize = txtFileName.MaskBox.GetPreferredSize(new Size(txtFileName.MaskBox.Width, int.MaxValue));
        //    layoutControlItem8.MinSize = new Size(0, preferredSize.Height);
        }

        private void BriefBookInfoConvertedLayout_Resize(object sender, EventArgs e)
        {
            //Size preferredSize = txtFileName.MaskBox.GetPreferredSize(new Size(txtFileName.MaskBox.Width, int.MaxValue));
            //txtFileName.Height = preferredSize.Height;
        }
    }
}
