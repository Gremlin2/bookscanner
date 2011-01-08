namespace Gremlin.FB2Librarian.Import
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.grdSelectedFiles = new DevExpress.XtraGrid.GridControl();
            this.grvSelectedFiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgSmallImages = new System.Windows.Forms.ImageList(this.components);
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.scLeft = new DevComponents.DotNetBar.ExpandableSplitter();
            this.tabLeft = new DevExpress.XtraTab.XtraTabControl();
            this.pageFiles = new DevExpress.XtraTab.XtraTabPage();
            this.ctlOptions = new System.Windows.Forms.Panel();
            this.cmdFilter = new DevExpress.XtraEditors.SimpleButton();
            this.imgActionImages = new System.Windows.Forms.ImageList(this.components);
            this.cmdStartSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cmdStartImport = new DevExpress.XtraEditors.SimpleButton();
            this.chkSelectFoundFiles = new DevExpress.XtraEditors.CheckEdit();
            this.chkIncludeSubDirs = new DevExpress.XtraEditors.CheckEdit();
            this.txtImportPath = new DevExpress.XtraEditors.ButtonEdit();
            this.tabRight = new DevExpress.XtraTab.XtraTabControl();
            this.tabProcessLog = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.briefBookInfo2 = new Gremlin.FB2Librarian.Import.BriefBookInfoControl();
            this.grdLegend = new DevExpress.XtraGrid.GridControl();
            this.grvLegend = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.briefBookInfo1 = new Gremlin.FB2Librarian.Import.BriefBookInfoControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgLegend = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.scRight = new DevComponents.DotNetBar.ExpandableSplitter();
            this.grdResult = new DevExpress.XtraGrid.GridControl();
            this.grvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFb2DocumentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colOriginalFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.ctlCommandManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.ctlProgressBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.cmdStop = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cmdSelectAll = new DevExpress.XtraBars.BarButtonItem();
            this.cmdUnselectAll = new DevExpress.XtraBars.BarButtonItem();
            this.cmdClearList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.cmdRemoveProcessed = new DevExpress.XtraBars.BarButtonItem();
            this.cmdReprocessItem = new DevExpress.XtraBars.BarButtonItem();
            this.cmdReplaceBook = new DevExpress.XtraBars.BarButtonItem();
            this.cmdCreateNewBook = new DevExpress.XtraBars.BarButtonItem();
            this.cmdClearResultList = new DevExpress.XtraBars.BarButtonItem();
            this.cmdRemoveEntry = new DevExpress.XtraBars.BarButtonItem();
            this.cmdSaveProcessLog = new DevExpress.XtraBars.BarButtonItem();
            this.cmdViewSourceBook = new DevExpress.XtraBars.BarButtonItem();
            this.cmdViewLibraryBook = new DevExpress.XtraBars.BarButtonItem();
            this.mnuSelectedFiles = new DevExpress.XtraBars.PopupMenu(this.components);
            this.mnuResult = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSelectedFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLeft)).BeginInit();
            this.tabLeft.SuspendLayout();
            this.pageFiles.SuspendLayout();
            this.ctlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectFoundFiles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeSubDirs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRight)).BeginInit();
            this.tabRight.SuspendLayout();
            this.tabProcessLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuSelectedFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSelectedFiles
            // 
            this.grdSelectedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSelectedFiles.Location = new System.Drawing.Point(0, 81);
            this.grdSelectedFiles.MainView = this.grvSelectedFiles;
            this.grdSelectedFiles.Name = "grdSelectedFiles";
            this.grdSelectedFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemImageComboBox1});
            this.grdSelectedFiles.Size = new System.Drawing.Size(335, 383);
            this.grdSelectedFiles.TabIndex = 0;
            this.grdSelectedFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSelectedFiles});
            // 
            // grvSelectedFiles
            // 
            this.grvSelectedFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvSelectedFiles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvSelectedFiles.GridControl = this.grdSelectedFiles;
            this.grvSelectedFiles.Name = "grvSelectedFiles";
            this.grvSelectedFiles.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvSelectedFiles.OptionsView.ShowGroupPanel = false;
            this.grvSelectedFiles.OptionsView.ShowIndicator = false;
            this.grvSelectedFiles.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.grvSelectedFiles.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.grvSelectedFiles_ShowGridMenu);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Selected";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "Selected";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ShowCaption = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 24;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Status";
            this.gridColumn2.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ShowCaption = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 24;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ready to process", Gremlin.FB2Librarian.Import.ImportStatus.ReadyToProcess, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Successfully added", Gremlin.FB2Librarian.Import.ImportStatus.Added, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Updated", Gremlin.FB2Librarian.Import.ImportStatus.Updated, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (identical)", Gremlin.FB2Librarian.Import.ImportStatus.Duplicate, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (older)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateOlder, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (IDs differ)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateIDsDiffer, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (newer)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateNewer, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Parsing Error", Gremlin.FB2Librarian.Import.ImportStatus.ParsingError, 9),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bad archive", Gremlin.FB2Librarian.Import.ImportStatus.ArchiveError, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Error updating database", Gremlin.FB2Librarian.Import.ImportStatus.DatabaseError, 10),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Book description required", Gremlin.FB2Librarian.Import.ImportStatus.NeedDescription, 11),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Filtered out", Gremlin.FB2Librarian.Import.ImportStatus.FilteredOut, 12)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imgSmallImages;
            // 
            // imgSmallImages
            // 
            this.imgSmallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmallImages.ImageStream")));
            this.imgSmallImages.TransparentColor = System.Drawing.Color.Olive;
            this.imgSmallImages.Images.SetKeyName(0, "State1.bmp");
            this.imgSmallImages.Images.SetKeyName(1, "State2.bmp");
            this.imgSmallImages.Images.SetKeyName(2, "State3.bmp");
            this.imgSmallImages.Images.SetKeyName(3, "State4.bmp");
            this.imgSmallImages.Images.SetKeyName(4, "State5.bmp");
            this.imgSmallImages.Images.SetKeyName(5, "State6.bmp");
            this.imgSmallImages.Images.SetKeyName(6, "State11.bmp");
            this.imgSmallImages.Images.SetKeyName(7, "State7.bmp");
            this.imgSmallImages.Images.SetKeyName(8, "State8.bmp");
            this.imgSmallImages.Images.SetKeyName(9, "State9.bmp");
            this.imgSmallImages.Images.SetKeyName(10, "State10.bmp");
            this.imgSmallImages.Images.SetKeyName(11, "State12.bmp");
            this.imgSmallImages.Images.SetKeyName(12, "");
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Имя файла";
            this.gridColumn3.FieldName = "DisplayText";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 206;
            // 
            // scLeft
            // 
            this.scLeft.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scLeft.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scLeft.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.scLeft.ExpandableControl = this.tabLeft;
            this.scLeft.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scLeft.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scLeft.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scLeft.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scLeft.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scLeft.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scLeft.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.scLeft.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.scLeft.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.scLeft.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.scLeft.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.scLeft.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.scLeft.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scLeft.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scLeft.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scLeft.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scLeft.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scLeft.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scLeft.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.scLeft.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.scLeft.Location = new System.Drawing.Point(344, 0);
            this.scLeft.MinSize = 215;
            this.scLeft.Name = "scLeft";
            this.scLeft.Size = new System.Drawing.Size(3, 495);
            this.scLeft.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.scLeft.TabIndex = 7;
            this.scLeft.TabStop = false;
            // 
            // tabLeft
            // 
            this.tabLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabLeft.Location = new System.Drawing.Point(0, 0);
            this.tabLeft.Name = "tabLeft";
            this.tabLeft.SelectedTabPage = this.pageFiles;
            this.tabLeft.Size = new System.Drawing.Size(344, 495);
            this.tabLeft.TabIndex = 8;
            this.tabLeft.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageFiles});
            // 
            // pageFiles
            // 
            this.pageFiles.Controls.Add(this.grdSelectedFiles);
            this.pageFiles.Controls.Add(this.ctlOptions);
            this.pageFiles.Name = "pageFiles";
            this.pageFiles.Size = new System.Drawing.Size(335, 464);
            this.pageFiles.Text = "Найденные файлы";
            // 
            // ctlOptions
            // 
            this.ctlOptions.Controls.Add(this.cmdFilter);
            this.ctlOptions.Controls.Add(this.cmdStartSearch);
            this.ctlOptions.Controls.Add(this.cmdStartImport);
            this.ctlOptions.Controls.Add(this.chkSelectFoundFiles);
            this.ctlOptions.Controls.Add(this.chkIncludeSubDirs);
            this.ctlOptions.Controls.Add(this.txtImportPath);
            this.ctlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlOptions.Location = new System.Drawing.Point(0, 0);
            this.ctlOptions.Name = "ctlOptions";
            this.ctlOptions.Size = new System.Drawing.Size(335, 81);
            this.ctlOptions.TabIndex = 1;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFilter.ImageIndex = 2;
            this.cmdFilter.ImageList = this.imgActionImages;
            this.cmdFilter.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdFilter.Location = new System.Drawing.Point(214, 31);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(36, 35);
            this.cmdFilter.TabIndex = 5;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // imgActionImages
            // 
            this.imgActionImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgActionImages.ImageStream")));
            this.imgActionImages.TransparentColor = System.Drawing.Color.Olive;
            this.imgActionImages.Images.SetKeyName(0, "Scan.bmp");
            this.imgActionImages.Images.SetKeyName(1, "Process.bmp");
            this.imgActionImages.Images.SetKeyName(2, "");
            this.imgActionImages.Images.SetKeyName(3, "");
            this.imgActionImages.Images.SetKeyName(4, "");
            this.imgActionImages.Images.SetKeyName(5, "");
            this.imgActionImages.Images.SetKeyName(6, "");
            this.imgActionImages.Images.SetKeyName(7, "");
            // 
            // cmdStartSearch
            // 
            this.cmdStartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartSearch.ImageIndex = 0;
            this.cmdStartSearch.ImageList = this.imgActionImages;
            this.cmdStartSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdStartSearch.Location = new System.Drawing.Point(256, 31);
            this.cmdStartSearch.Name = "cmdStartSearch";
            this.cmdStartSearch.Size = new System.Drawing.Size(36, 35);
            this.cmdStartSearch.TabIndex = 4;
            this.cmdStartSearch.Click += new System.EventHandler(this.cmdStartSearch_Click);
            // 
            // cmdStartImport
            // 
            this.cmdStartImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartImport.ImageIndex = 1;
            this.cmdStartImport.ImageList = this.imgActionImages;
            this.cmdStartImport.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdStartImport.Location = new System.Drawing.Point(298, 31);
            this.cmdStartImport.Name = "cmdStartImport";
            this.cmdStartImport.Size = new System.Drawing.Size(34, 35);
            this.cmdStartImport.TabIndex = 3;
            this.cmdStartImport.Click += new System.EventHandler(this.cmdStartImport_Click);
            // 
            // chkSelectFoundFiles
            // 
            this.chkSelectFoundFiles.Location = new System.Drawing.Point(4, 54);
            this.chkSelectFoundFiles.Name = "chkSelectFoundFiles";
            this.chkSelectFoundFiles.Properties.Caption = "Пометить найденные файлы";
            this.chkSelectFoundFiles.Size = new System.Drawing.Size(172, 19);
            this.chkSelectFoundFiles.TabIndex = 2;
            // 
            // chkIncludeSubDirs
            // 
            this.chkIncludeSubDirs.Location = new System.Drawing.Point(4, 29);
            this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
            this.chkIncludeSubDirs.Properties.Caption = "Искать также во вложенных папках";
            this.chkIncludeSubDirs.Size = new System.Drawing.Size(211, 19);
            this.chkIncludeSubDirs.TabIndex = 1;
            // 
            // txtImportPath
            // 
            this.txtImportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportPath.Location = new System.Drawing.Point(6, 3);
            this.txtImportPath.Name = "txtImportPath";
            this.txtImportPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtImportPath.Size = new System.Drawing.Size(326, 20);
            this.txtImportPath.TabIndex = 0;
            this.txtImportPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtImportPath_ButtonClick);
            // 
            // tabRight
            // 
            this.tabRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRight.Location = new System.Drawing.Point(347, 0);
            this.tabRight.Name = "tabRight";
            this.tabRight.SelectedTabPage = this.tabProcessLog;
            this.tabRight.Size = new System.Drawing.Size(605, 495);
            this.tabRight.TabIndex = 9;
            this.tabRight.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabProcessLog});
            // 
            // tabProcessLog
            // 
            this.tabProcessLog.Controls.Add(this.layoutControl1);
            this.tabProcessLog.Controls.Add(this.scRight);
            this.tabProcessLog.Controls.Add(this.grdResult);
            this.tabProcessLog.Controls.Add(this.standaloneBarDockControl1);
            this.tabProcessLog.Name = "tabProcessLog";
            this.tabProcessLog.Size = new System.Drawing.Size(596, 464);
            this.tabProcessLog.Text = "Журнал обработки";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.briefBookInfo2);
            this.layoutControl1.Controls.Add(this.grdLegend);
            this.layoutControl1.Controls.Add(this.briefBookInfo1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 271);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(596, 193);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // briefBookInfo2
            // 
            this.briefBookInfo2.Location = new System.Drawing.Point(429, 28);
            this.briefBookInfo2.Name = "briefBookInfo2";
            this.briefBookInfo2.Size = new System.Drawing.Size(100, 156);
            this.briefBookInfo2.TabIndex = 12;
            // 
            // grdLegend
            // 
            this.grdLegend.Location = new System.Drawing.Point(10, 28);
            this.grdLegend.MainView = this.grvLegend;
            this.grdLegend.Name = "grdLegend";
            this.grdLegend.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemImageComboBox3});
            this.grdLegend.Size = new System.Drawing.Size(191, 156);
            this.grdLegend.TabIndex = 10;
            this.grdLegend.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLegend});
            // 
            // grvLegend
            // 
            this.grvLegend.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn4});
            this.grvLegend.GridControl = this.grdLegend;
            this.grvLegend.Name = "grvLegend";
            this.grvLegend.OptionsView.ShowColumnHeaders = false;
            this.grvLegend.OptionsView.ShowGroupPanel = false;
            this.grvLegend.OptionsView.ShowIndicator = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Status";
            this.gridColumn5.ColumnEdit = this.repositoryItemImageComboBox3;
            this.gridColumn5.FieldName = "Status";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ShowCaption = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 24;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ready to process", Gremlin.FB2Librarian.Import.ImportStatus.ReadyToProcess, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Successfully added", Gremlin.FB2Librarian.Import.ImportStatus.Added, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Updated", Gremlin.FB2Librarian.Import.ImportStatus.Updated, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (identical)", Gremlin.FB2Librarian.Import.ImportStatus.Duplicate, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (older)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateOlder, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (IDs differ)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateIDsDiffer, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (newer)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateNewer, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Parsing Error", Gremlin.FB2Librarian.Import.ImportStatus.ParsingError, 9),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bad archive", Gremlin.FB2Librarian.Import.ImportStatus.ArchiveError, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Error updating database", Gremlin.FB2Librarian.Import.ImportStatus.DatabaseError, 10),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Book description required", Gremlin.FB2Librarian.Import.ImportStatus.NeedDescription, 11),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Filtered out", Gremlin.FB2Librarian.Import.ImportStatus.FilteredOut, 12)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            this.repositoryItemImageComboBox3.SmallImages = this.imgSmallImages;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Description";
            this.gridColumn6.FieldName = "Description";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 206;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "Counter";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // briefBookInfo1
            // 
            this.briefBookInfo1.Location = new System.Drawing.Point(224, 28);
            this.briefBookInfo1.Name = "briefBookInfo1";
            this.briefBookInfo1.Size = new System.Drawing.Size(182, 156);
            this.briefBookInfo1.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lcgLegend,
            this.splitterItem1,
            this.layoutControlGroup2,
            this.splitterItem2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(596, 193);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.emptySpaceItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(536, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(58, 191);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgLegend
            // 
            this.lcgLegend.AllowCustomizeChildren = false;
            this.lcgLegend.AllowHide = false;
            this.lcgLegend.AppearanceGroup.Options.UseTextOptions = true;
            this.lcgLegend.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcgLegend.CustomizationFormText = "Legend";
            this.lcgLegend.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.lcgLegend.ExpandButtonVisible = true;
            this.lcgLegend.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgLegend.Location = new System.Drawing.Point(0, 0);
            this.lcgLegend.Name = "lcgLegend";
            this.lcgLegend.Size = new System.Drawing.Size(208, 191);
            this.lcgLegend.Text = "Обозначения";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdLegend;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(202, 167);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(208, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings;
            this.splitterItem1.Size = new System.Drawing.Size(6, 191);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(214, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(199, 191);
            this.layoutControlGroup2.Text = "Книга в библиотеке";
            this.layoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.briefBookInfo1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(193, 167);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem2
            // 
            this.splitterItem2.CustomizationFormText = "splitterItem2";
            this.splitterItem2.Location = new System.Drawing.Point(413, 0);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings;
            this.splitterItem2.Size = new System.Drawing.Size(6, 191);
            this.splitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(419, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(117, 191);
            this.layoutControlGroup3.Text = "Добавляемая книга";
            this.layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.briefBookInfo2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(111, 167);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // scRight
            // 
            this.scRight.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.scRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.scRight.ExpandableControl = this.grdLegend;
            this.scRight.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scRight.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scRight.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scRight.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.scRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.scRight.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.scRight.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.scRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.scRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.scRight.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scRight.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.scRight.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.scRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.scRight.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.scRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.scRight.Location = new System.Drawing.Point(0, 268);
            this.scRight.Name = "scRight";
            this.scRight.Size = new System.Drawing.Size(596, 3);
            this.scRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.scRight.TabIndex = 9;
            this.scRight.TabStop = false;
            // 
            // grdResult
            // 
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdResult.Location = new System.Drawing.Point(0, 25);
            this.grdResult.MainView = this.grvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2});
            this.grdResult.Size = new System.Drawing.Size(596, 243);
            this.grdResult.TabIndex = 1;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvResult});
            this.grdResult.BindingContextChanged += new System.EventHandler(this.grdResult_BindingContextChanged);
            // 
            // grvResult
            // 
            this.grvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFb2DocumentStatus,
            this.colOriginalFileName,
            this.colFileDate});
            this.grvResult.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvResult.GridControl = this.grdResult;
            this.grvResult.Name = "grvResult";
            this.grvResult.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvResult.OptionsSelection.MultiSelect = true;
            this.grvResult.OptionsView.ShowIndicator = false;
            this.grvResult.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView3_FocusedRowChanged);
            this.grvResult.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvResult_SelectionChanged);
            this.grvResult.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.grvResult_ShowGridMenu);
            // 
            // colFb2DocumentStatus
            // 
            this.colFb2DocumentStatus.Caption = "Status";
            this.colFb2DocumentStatus.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colFb2DocumentStatus.FieldName = "Status";
            this.colFb2DocumentStatus.Name = "colFb2DocumentStatus";
            this.colFb2DocumentStatus.OptionsColumn.AllowEdit = false;
            this.colFb2DocumentStatus.OptionsColumn.AllowFocus = false;
            this.colFb2DocumentStatus.OptionsColumn.AllowSize = false;
            this.colFb2DocumentStatus.OptionsColumn.FixedWidth = true;
            this.colFb2DocumentStatus.OptionsColumn.ShowCaption = false;
            this.colFb2DocumentStatus.Visible = true;
            this.colFb2DocumentStatus.VisibleIndex = 0;
            this.colFb2DocumentStatus.Width = 24;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ready to process", Gremlin.FB2Librarian.Import.ImportStatus.ReadyToProcess, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Successfully added", Gremlin.FB2Librarian.Import.ImportStatus.Added, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Updated", Gremlin.FB2Librarian.Import.ImportStatus.Updated, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (identical)", Gremlin.FB2Librarian.Import.ImportStatus.Duplicate, 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (older)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateOlder, 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (IDs differ)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateIDsDiffer, 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Duplicate (newer)", Gremlin.FB2Librarian.Import.ImportStatus.DuplicateNewer, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Parsing Error", Gremlin.FB2Librarian.Import.ImportStatus.ParsingError, 9),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Bad archive", Gremlin.FB2Librarian.Import.ImportStatus.ArchiveError, 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Error updating database", Gremlin.FB2Librarian.Import.ImportStatus.DatabaseError, 10),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Book description required", Gremlin.FB2Librarian.Import.ImportStatus.NeedDescription, 11),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Filtered out", Gremlin.FB2Librarian.Import.ImportStatus.FilteredOut, 12)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.imgSmallImages;
            // 
            // colOriginalFileName
            // 
            this.colOriginalFileName.Caption = "Имя файла";
            this.colOriginalFileName.FieldName = "OriginalFileName";
            this.colOriginalFileName.Name = "colOriginalFileName";
            this.colOriginalFileName.OptionsColumn.AllowEdit = false;
            this.colOriginalFileName.OptionsColumn.AllowFocus = false;
            this.colOriginalFileName.Visible = true;
            this.colOriginalFileName.VisibleIndex = 1;
            this.colOriginalFileName.Width = 206;
            // 
            // colFileDate
            // 
            this.colFileDate.Caption = "File date";
            this.colFileDate.FieldName = "FileDate";
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.OptionsColumn.AllowEdit = false;
            this.colFileDate.OptionsColumn.AllowFocus = false;
            this.colFileDate.Visible = true;
            this.colFileDate.VisibleIndex = 2;
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Appearance.Options.UseBackColor = true;
            this.standaloneBarDockControl1.AutoSize = true;
            this.standaloneBarDockControl1.AutoSizeInLayoutControl = true;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(596, 25);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // ctlCommandManager
            // 
            this.ctlCommandManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.ctlCommandManager.DockControls.Add(this.barDockControlTop);
            this.ctlCommandManager.DockControls.Add(this.barDockControlBottom);
            this.ctlCommandManager.DockControls.Add(this.barDockControlLeft);
            this.ctlCommandManager.DockControls.Add(this.barDockControlRight);
            this.ctlCommandManager.DockControls.Add(this.standaloneBarDockControl1);
            this.ctlCommandManager.Form = this;
            this.ctlCommandManager.Images = this.imgActionImages;
            this.ctlCommandManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cmdSelectAll,
            this.cmdUnselectAll,
            this.cmdClearList,
            this.barButtonItem1,
            this.barStaticItem1,
            this.cmdStop,
            this.ctlProgressBar,
            this.cmdRemoveProcessed,
            this.cmdReprocessItem,
            this.cmdReplaceBook,
            this.cmdCreateNewBook,
            this.cmdClearResultList,
            this.cmdRemoveEntry,
            this.cmdSaveProcessLog,
            this.cmdViewSourceBook,
            this.cmdViewLibraryBook});
            this.ctlCommandManager.MaxItemId = 18;
            this.ctlCommandManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.ctlCommandManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(380, 277);
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.ctlProgressBar, "", false, true, true, 193),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdStop)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.DrawSizeGrip = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // ctlProgressBar
            // 
            this.ctlProgressBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.ctlProgressBar.Caption = "ctlProgress";
            this.ctlProgressBar.Edit = this.repositoryItemProgressBar1;
            this.ctlProgressBar.Id = 8;
            this.ctlProgressBar.Name = "ctlProgressBar";
            this.ctlProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // cmdStop
            // 
            this.cmdStop.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.cmdStop.Caption = "cmdStop";
            this.cmdStop.Glyph = ((System.Drawing.Image)(resources.GetObject("cmdStop.Glyph")));
            this.cmdStop.Id = 7;
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Caption = "Выделить все";
            this.cmdSelectAll.Id = 3;
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSelectAll_ItemClick);
            // 
            // cmdUnselectAll
            // 
            this.cmdUnselectAll.Caption = "Снять выделение со всего";
            this.cmdUnselectAll.Id = 4;
            this.cmdUnselectAll.Name = "cmdUnselectAll";
            this.cmdUnselectAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdUnselectAll_ItemClick);
            // 
            // cmdClearList
            // 
            this.cmdClearList.Caption = "Очистить список";
            this.cmdClearList.Id = 2;
            this.cmdClearList.Name = "cmdClearList";
            this.cmdClearList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdClearList_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "cmdStopAction";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "ctlProgress";
            this.barStaticItem1.Id = 6;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cmdRemoveProcessed
            // 
            this.cmdRemoveProcessed.Caption = "Убрать успешно обработанные";
            this.cmdRemoveProcessed.Id = 9;
            this.cmdRemoveProcessed.Name = "cmdRemoveProcessed";
            this.cmdRemoveProcessed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRemoveProcessed_ItemClick);
            // 
            // cmdReprocessItem
            // 
            this.cmdReprocessItem.Caption = "Обработать файл повторно";
            this.cmdReprocessItem.Id = 10;
            this.cmdReprocessItem.ImageIndex = 1;
            this.cmdReprocessItem.Name = "cmdReprocessItem";
            this.cmdReprocessItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdReprocessItem_ItemClick);
            // 
            // cmdReplaceBook
            // 
            this.cmdReplaceBook.Caption = "Заменить документ в библиотеке";
            this.cmdReplaceBook.Id = 11;
            this.cmdReplaceBook.ImageIndex = 3;
            this.cmdReplaceBook.Name = "cmdReplaceBook";
            this.cmdReplaceBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdReplaceBook_ItemClick);
            // 
            // cmdCreateNewBook
            // 
            this.cmdCreateNewBook.Caption = "Создать новый документ наряду со старым";
            this.cmdCreateNewBook.Id = 12;
            this.cmdCreateNewBook.ImageIndex = 4;
            this.cmdCreateNewBook.Name = "cmdCreateNewBook";
            this.cmdCreateNewBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdCreateNewBook_ItemClick);
            // 
            // cmdClearResultList
            // 
            this.cmdClearResultList.Caption = "Очистить список";
            this.cmdClearResultList.Id = 13;
            this.cmdClearResultList.ImageIndex = 6;
            this.cmdClearResultList.Name = "cmdClearResultList";
            this.cmdClearResultList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdClearResultList_ItemClick);
            // 
            // cmdRemoveEntry
            // 
            this.cmdRemoveEntry.Caption = "Убрать из списка";
            this.cmdRemoveEntry.Id = 14;
            this.cmdRemoveEntry.ImageIndex = 5;
            this.cmdRemoveEntry.Name = "cmdRemoveEntry";
            this.cmdRemoveEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdRemoveEntry_ItemClick);
            // 
            // cmdSaveProcessLog
            // 
            this.cmdSaveProcessLog.Caption = "Сохранить журнал операций...";
            this.cmdSaveProcessLog.Id = 15;
            this.cmdSaveProcessLog.ImageIndex = 7;
            this.cmdSaveProcessLog.Name = "cmdSaveProcessLog";
            this.cmdSaveProcessLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdSaveProcessLog_ItemClick);
            // 
            // cmdViewSourceBook
            // 
            this.cmdViewSourceBook.Caption = "Просмотр исходной книги";
            this.cmdViewSourceBook.Id = 16;
            this.cmdViewSourceBook.Name = "cmdViewSourceBook";
            this.cmdViewSourceBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdViewSourceBook_ItemClick);
            // 
            // cmdViewLibraryBook
            // 
            this.cmdViewLibraryBook.Caption = "Просмотр книги в библиотеке";
            this.cmdViewLibraryBook.Id = 17;
            this.cmdViewLibraryBook.Name = "cmdViewLibraryBook";
            this.cmdViewLibraryBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cmdViewLibraryBook_ItemClick);
            // 
            // mnuSelectedFiles
            // 
            this.mnuSelectedFiles.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSelectAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdUnselectAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdClearList, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRemoveProcessed)});
            this.mnuSelectedFiles.Manager = this.ctlCommandManager;
            this.mnuSelectedFiles.Name = "mnuSelectedFiles";
            // 
            // mnuResult
            // 
            this.mnuResult.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdViewSourceBook, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdViewLibraryBook),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdReprocessItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdReplaceBook),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdCreateNewBook),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdRemoveEntry, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdSaveProcessLog, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.cmdClearResultList)});
            this.mnuResult.Manager = this.ctlCommandManager;
            this.mnuResult.Name = "mnuResult";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 521);
            this.Controls.Add(this.tabRight);
            this.Controls.Add(this.scLeft);
            this.Controls.Add(this.tabLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ImportForm";
            this.ShowInTaskbar = false;
            this.Text = "Book Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSelectedFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLeft)).EndInit();
            this.tabLeft.ResumeLayout(false);
            this.pageFiles.ResumeLayout(false);
            this.ctlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectFoundFiles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeSubDirs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImportPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabRight)).EndInit();
            this.tabRight.ResumeLayout(false);
            this.tabProcessLog.ResumeLayout(false);
            this.tabProcessLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuSelectedFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSelectedFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSelectedFiles;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevComponents.DotNetBar.ExpandableSplitter scLeft;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraTab.XtraTabControl tabLeft;
        private DevExpress.XtraTab.XtraTabPage pageFiles;
        private DevExpress.XtraTab.XtraTabControl tabRight;
        private DevExpress.XtraTab.XtraTabPage tabProcessLog;
        private System.Windows.Forms.Panel ctlOptions;
        private DevExpress.XtraEditors.SimpleButton cmdStartSearch;
        private DevExpress.XtraEditors.SimpleButton cmdStartImport;
        private DevExpress.XtraEditors.CheckEdit chkSelectFoundFiles;
        private DevExpress.XtraEditors.CheckEdit chkIncludeSubDirs;
        private DevExpress.XtraEditors.ButtonEdit txtImportPath;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager ctlCommandManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ImageList imgSmallImages;
        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraGrid.Views.Grid.GridView grvResult;
        private DevExpress.XtraGrid.Columns.GridColumn colFb2DocumentStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colFileDate;
        private DevExpress.XtraGrid.GridControl grdLegend;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLegend;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevComponents.DotNetBar.ExpandableSplitter scRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgLegend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private System.Windows.Forms.ImageList imgActionImages;
        private DevExpress.XtraBars.PopupMenu mnuSelectedFiles;
        private DevExpress.XtraBars.BarButtonItem cmdSelectAll;
        private DevExpress.XtraBars.BarButtonItem cmdUnselectAll;
        private DevExpress.XtraBars.BarButtonItem cmdClearList;
        private DevExpress.XtraEditors.SimpleButton cmdFilter;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem ctlProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarButtonItem cmdStop;
        private BriefBookInfoControl briefBookInfo1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private BriefBookInfoControl briefBookInfo2;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem cmdRemoveProcessed;
        private DevExpress.XtraBars.PopupMenu mnuResult;
        private DevExpress.XtraBars.BarButtonItem cmdReprocessItem;
        private DevExpress.XtraBars.BarButtonItem cmdReplaceBook;
        private DevExpress.XtraBars.BarButtonItem cmdCreateNewBook;
        private DevExpress.XtraBars.BarButtonItem cmdClearResultList;
        private DevExpress.XtraBars.BarButtonItem cmdRemoveEntry;
        private DevExpress.XtraBars.BarButtonItem cmdSaveProcessLog;
        private DevExpress.XtraBars.BarButtonItem cmdViewSourceBook;
        private DevExpress.XtraBars.BarButtonItem cmdViewLibraryBook;
    }
}