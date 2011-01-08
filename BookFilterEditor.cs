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

using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;

using Gremlin.FB2Librarian.Import.Entities;
using Gremlin.FB2Librarian.Import.Utils;

using Tanone.Common.DBUtils;
using FirebirdSql.Data.FirebirdClient;

namespace Gremlin.FB2Librarian.Import
{
    public partial class BookFilterEditor : XtraForm
    {
        private bool firstActivate;
        private TCommonFireBirdDB database;

        private RepositoryItemGridLookUpEdit genreEditor;

        public BookFilterEditor(TCommonFireBirdDB db)
        {
            if (db == null)
            {
                throw new ArgumentNullException("db");
            }

            InitializeComponent();

            firstActivate = true;
            database = db;

            FilterColumnCollection columnCollection = new FilterColumnCollection();

            genreEditor = new RepositoryItemGridLookUpEdit();
            genreEditor.ValueMember = "Name";
            genreEditor.DisplayMember = "Name";
            genreEditor.ViewType = GridLookUpViewType.Default;

            GridColumn genreNameColumn = new GridColumn();
            genreNameColumn.Caption = "Name";
            genreNameColumn.FieldName = "Name";
            genreNameColumn.VisibleIndex = 0;

            GridColumn genreDescColumn = new GridColumn();
            genreDescColumn.Caption = "Description";
            genreDescColumn.FieldName = "RuDescription";
            genreDescColumn.VisibleIndex = 1;

            genreEditor.View.Columns.Add(genreNameColumn);
            genreEditor.View.Columns.Add(genreDescColumn);

            columnCollection.Add(new UnboundFilterColumn("Genre", "Genres", typeof(string), this.genreEditor, FilterColumnClauseClass.String));
            columnCollection.Add(new UnboundFilterColumn("Language", "Lang", typeof(string), new RepositoryItemComboBox(), FilterColumnClauseClass.String));
            columnCollection.Add(new UnboundFilterColumn("Source Language", "SrcLang", typeof(string), new RepositoryItemComboBox(), FilterColumnClauseClass.String));
            columnCollection.Add(new UnboundFilterColumn("Book Author", "BookAuthors", typeof(string), new RepositoryItemComboBox(), FilterColumnClauseClass.String));

            this.filterControl.SetFilterColumnsCollection(columnCollection);
        }

        protected override void OnActivated(EventArgs e)
        {
            if (this.firstActivate)
            {
                this.firstActivate = false;
                OnFirstActivated();
            }

            base.OnActivated(e);
        }

        protected virtual void OnFirstActivated()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                database.BeginConnect();

                try
                {
                    string commandText = "SELECT * FROM GENRE";

                    using (SqlDbCommand command = new SqlDbCommand(database.Connection.CreateCommand()))
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = commandText;

                        List<GenreInfo> result = command.ExecuteList<GenreInfo>();

                        foreach (GenreInfo genreInfo in result)
                        {
                            genreInfo.Name = (genreInfo.Name != null) ? genreInfo.Name.Trim() : null;
                        }

                        genreEditor.DataSource = result;
                    }
                }
                finally
                {
                    database.EndConnect();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public string FilterString
        {
            get
            {
                return this.filterControl.FilterString;
            }
            set
            {
                this.filterControl.FilterString = value;
            }
        }

        public CriteriaOperator FilterCriteria
        {
            get
            {
                return this.filterControl.FilterCriteria;
            }
            set
            {
                this.filterControl.FilterCriteria = value;
            }
        }
    }
}
