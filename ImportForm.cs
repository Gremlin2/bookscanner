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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;

using FirebirdSql.Data.FirebirdClient;

using Tanone.Common;
using Tanone.Common.DBUtils;
using Tanone.Common.Interfaces;

using Gremlin.FB2Librarian.Import.Utils;
using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Entities;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

using System.Diagnostics;

using VirtualFileSystem;
using VirtualFileSystem.Cache;
using VirtualFileSystem.events;
using VirtualFileSystem.impl;
using VirtualFileSystem.Provider.Local;
using VirtualFileSystem.Provider.Zip;
using System.Xml.Serialization;
using DevExpress.Data.Filtering.Helpers;
using Gremlin.FB2Librarian.Import.Filtering;
using DevExpress.XtraGrid;
using Gremlin.FB2Librarian.Import.SevenZip;

namespace Gremlin.FB2Librarian.Import
{
    public partial class ImportForm : XtraForm, IFileSystemListener
    {
        [XmlRoot("State")]
        public class ScannerState
        {
            public string SearchPath { get; set; }
            public bool? IncludeSubDirs { get; set; }
            public bool? SelectFoundFiles { get; set; }

            public string Filter { get; set; }

            [XmlArray]
            [XmlArrayItem("Entry")]
            public List<XmlImportFileEntry> Entries { get; set; }

            [XmlArray]
            [XmlArrayItem("LegendItem")]
            public List<XmlLegendItem> Legend { get; set; }

            [XmlArray]
            [XmlArrayItem("Book")]
            public List<XmlFb2DocumentEntry> Log { get; set; }

            public ScannerState()
            {
            }
        }

        private Set<string> processedItems;
        private Dictionary<string, ImportFileEntry> excludeList;
        private List<ImportFileEntry> fileEntries;

        private List<Fb2DocumentEntry> processLog;
        private ProcessLegendItemCollection processLegend;

        private PluginCallBack callback;
        private TCommonFireBirdDB db;

        private string tempFolder;
        private string badFolder;
        private string sourceFolder;
        private string dupFolder;
        private string lastFolder;
        private string oldFileFolder;

        private FirebirdDataAccess database;

        private DefaultFileSystemManager manager;

        private string filterCriteria;
        private PropertyDescriptorCollection properties;
        private FilterEvaluator filter;

        private bool dontCheckForDuplicate;

        private BufferPool bufferPool;

        internal ImportForm(object pluginParams, ImportOptions options) : this()
        {
            if (pluginParams == null)
            {
                throw new ArgumentNullException("pluginParams");
            }

            object pluginCallBack = CommonParams.GetParam(CommonConsts.cParamCallbackMethod, pluginParams, null, 1);

            this.callback =  pluginCallBack as PluginCallBack;
            this.db = ConnectionManager.Instance().Connection<TCommonFireBirdDB>("MainConnection");

            object callParams = CommonParams.AddParam(CommonConsts.cParamCallbackMethod, callback, null);
            callParams = CommonParams.AddParam(CommonConsts.cParamPlugin, "Configuration", callParams);
            callParams = CommonParams.AddParam(CommonConsts.cParamAction, "Configuration.Get", callParams);
            callParams = CommonParams.AddParam("Info", "SystemFolders", callParams);

            object result = this.callback(callParams);

            this.tempFolder = CommonParams.GetParam("TempFolder", result, Path.GetTempPath(), 1);
            if(!Directory.Exists(this.tempFolder))
            {
                this.tempFolder = Path.GetTempPath();
            }

            this.badFolder = CommonParams.GetParam("BadFolder", result, String.Empty, 1);
            this.sourceFolder = CommonParams.GetParam("SourcesFolder", result, String.Empty, 1);
            this.dupFolder = CommonParams.GetParam("DupFolder", result, String.Empty, 1);
            this.lastFolder = CommonParams.GetParam("LastFolder", result, String.Empty, 1);
            this.oldFileFolder = CommonParams.GetParam("OldFileFolder", result, String.Empty, 1);

            if(!String.IsNullOrEmpty(this.lastFolder))
            {
                this.txtImportPath.Text = this.lastFolder;
            }

            callParams = CommonParams.AddParam(CommonConsts.cParamCallbackMethod, callback, null);
            callParams = CommonParams.AddParam(CommonConsts.cParamPlugin, "Configuration", callParams);
            callParams = CommonParams.AddParam(CommonConsts.cParamAction, "Configuration.Get", callParams);
            callParams = CommonParams.AddParam("Info", "MountPoint", callParams);

            result = this.callback(callParams);

            this.database = new FirebirdDataAccess(this.db);
            this.database.CheckDatabaseSchema();

            DatabaseInfo databaseInfo = this.database.DatabaseInfo;
            databaseInfo.MountPoint = CommonParams.GetParam("MountPoint", result, String.Empty, 1);
            databaseInfo.WorkMode = CommonParams.GetParam("WorkMode", result, (short) StorageMode.FileSystem, 1);

            callParams = CommonParams.AddParam(CommonConsts.cParamCallbackMethod, callback, null);
            callParams = CommonParams.AddParam(CommonConsts.cParamPlugin, "Configuration", callParams);
            callParams = CommonParams.AddParam(CommonConsts.cParamAction, "Configuration.Get", callParams);
            callParams = CommonParams.AddParam("Info", "CurrentUserInfo", callParams);

            result = this.callback(callParams);

            databaseInfo.CurrentUserId = CommonParams.GetParam("UserID", result, -1, 1);
            databaseInfo.CurrentUserName = CommonParams.GetParam("UserName", result, String.Empty, 1);

            GenreTable.ReadGenreList(this.database);

            ZipConstants.DefaultCodePage = 866;
            SevenZipFormat.DefaultCodePage = 866;

            manager = new DefaultFileSystemManager();
            manager.setCacheStrategy(CacheStrategy.ON_RESOLVE);
            manager.init();

            SevenZipFileProvider provider = new SevenZipFileProvider();
            provider.addListener(this);

            manager.addProvider("file", new DefaultLocalFileProvider());

            manager.addProvider("zip", provider);
            manager.addExtensionMap("zip", "zip");
            manager.addMimeTypeMap("application/zip", "zip");

            manager.addProvider("sevenzip", provider);
            manager.addExtensionMap("7z", "sevenzip");
            manager.addMimeTypeMap("application/x-7z-compressed", "sevenzip");

            manager.addProvider("rar", provider);
            manager.addExtensionMap("rar", "rar");
            manager.addMimeTypeMap("application/x-rar-compressed", "rar");

            manager.Replicator = new DefaultFileReplicator();

            properties = TypeDescriptor.GetProperties(typeof(FilterAdapter));

            bufferPool = new BufferPool(4, 16384);

            legendViewMode = LegendViewMode.None;

            if (File.Exists("FBScanner.xml"))
            {
                ScannerState scannerState = LoadImportState("FBScanner.xml");
                if(scannerState != null)
                {
                    txtImportPath.Text = scannerState.SearchPath ?? this.lastFolder;
                    chkIncludeSubDirs.Checked = scannerState.IncludeSubDirs ?? false;
                    chkSelectFoundFiles.Checked = scannerState.SelectFoundFiles ?? false;
                    filterCriteria = scannerState.Filter;

                    if (!String.IsNullOrEmpty(filterCriteria))
                    {
                        filter = new FilterEvaluator(properties, filterCriteria);
                    }

                    if(scannerState.Entries != null)
                    {
                        fileEntries = scannerState.Entries.ConvertAll(x => new ImportFileEntry(x));
                        foreach (ImportFileEntry fileEntry in fileEntries)
                        {
                            excludeList.Add(fileEntry.Uri, fileEntry);
                        }

                        grdSelectedFiles.DataSource = fileEntries;
                    }

                    if(scannerState.Legend != null)
                    {
                        foreach (XmlLegendItem legendItem in scannerState.Legend)
                        {
                            processLegend.SetCounterValue(legendItem.Status, legendItem.Counter);
                        }
                    }

                    if(scannerState.Log != null)
                    {
                        processLog = scannerState.Log.ConvertAll(x => new Fb2DocumentEntry(x));
                        grdResult.DataSource = processLog;
                    }
                }
            }

            dontCheckForDuplicate = options.DontCheckForDuplicate;
        }

        private ImportForm()
        {
            InitializeComponent();

            this.fileEntries = new List<ImportFileEntry>();
            this.excludeList = new Dictionary<string, ImportFileEntry>(StringComparer.InvariantCultureIgnoreCase);
            this.processedItems = new Set<string>();

            this.processLog = new List<Fb2DocumentEntry>();
            this.processLegend = new ProcessLegendItemCollection();

            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.ReadyToProcess, "Ready to process"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.Added, "Successfully added"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.Updated, "Updated"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.Duplicate, "Duplicate (identical)"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateOlder, "Duplicate (older)"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateIDsDiffer, "Duplicate (IDs differ)"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateNewer, "Duplicate (newer)"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.ParsingError, "Parsing Error"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.ArchiveError, "Bad archive"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.DatabaseError, "Error updating database"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.NeedDescription, "Book description required"));
            //this.processLegend.Add(new ProcessLegendItem(ImportStatus.FilteredOut, "Filtered out"));

            this.processLegend.Add(new ProcessLegendItem(ImportStatus.ReadyToProcess, "Отмечен для обработки"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.Added, "Успешно добавлен"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.Updated, "Обновлено"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.Duplicate, "Дубликат (идентичный)"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateOlder, "Дубликат (старее)"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateIDsDiffer, "Дубликат (ID отличается)"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.DuplicateNewer, "Дубликат (новее)"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.ParsingError, "Ошибка разбора"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.ArchiveError, "Поврежденный архив"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.DatabaseError, "Ошибка обновления базы"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.NeedDescription, "Требуется описание книги"));
            this.processLegend.Add(new ProcessLegendItem(ImportStatus.FilteredOut, "Oтфильтрован"));

            foreach (RepositoryItemImageComboBox imageComboBox in new[] { repositoryItemImageComboBox1, repositoryItemImageComboBox2, repositoryItemImageComboBox3 })
            {
                foreach (ImageComboBoxItem comboBoxItem in imageComboBox.Items)
                {
                    ProcessLegendItem item = processLegend[(ImportStatus) comboBoxItem.Value];
                    comboBoxItem.Description = item.Description;
                }
            }

            this.grdSelectedFiles.DataSource = this.fileEntries;
            this.grdResult.DataSource = this.processLog;
            this.grdLegend.DataSource = this.processLegend;

            titleRegex = new Regex(@"[^\p{L}\p{Nd}]");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            try
            {
                manager.close();
                StoreImportState("FBScanner.xml");
            }
            finally 
            {
                RefreshMainForm();
            }
        }

        private void RefreshMainForm()
        {
            object args = CommonParams.AddParam(CommonConsts.cParamPlugin, CommonConsts.cPluginMainExe, null);
            args = CommonParams.AddParam(CommonConsts.cParamAction, PluginActions.Refresh, args);
            callback(args);
        }

        private void StoreImportState(string filename)
        {
            ScannerState state = new ScannerState();
            state.SearchPath = txtImportPath.Text;
            state.IncludeSubDirs = chkIncludeSubDirs.Checked;
            state.SelectFoundFiles = chkSelectFoundFiles.Checked;

            state.Filter = filterCriteria;

            state.Entries = fileEntries.ConvertAll(x => new XmlImportFileEntry(x));
            
            state.Legend = new List<XmlLegendItem>(processLegend.Count);
            foreach (ProcessLegendItem legendItem in processLegend)
            {
                state.Legend.Add(new XmlLegendItem(legendItem));
            }

            state.Log = processLog.ConvertAll(x => new XmlFb2DocumentEntry(x));

            XmlSerializer serializer = new XmlSerializer(typeof(ScannerState));
            try
            {
                using (TextWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, state);
                }
            }
            catch (Exception)
            {
                // TODO: Add error message box
            }
        }

        private ScannerState LoadImportState(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ScannerState));
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    ScannerState scannerState = (ScannerState)serializer.Deserialize(reader);
                    return scannerState;
                }
            }
            catch (Exception)
            {
                // TODO: Add error message box
            }

            return null;
        }

        public void VolumeOpenend(VolumeOpenedEventArgs args)
        {
            if (!excludeList.ContainsKey(args.Volume.Name.URI))
            {
                excludeList.Add(args.Volume.Name.URI, null);
            }
        }

        private void ProcessDirectory(IFileObject directory, bool includeSubDirs)
        {
            IFileObject[] files = directory.findFiles(Selectors.SELECT_CHILDREN);
            if (files == null)
            {
                return;
            }

            foreach (IFileObject file in files)
            {
                if (this.excludeList.ContainsKey(file.Name.URI))
                {
                    continue;
                }

                if (file.Type == FileType.FILE)
                {
                    IFileName name = file.Name;
                    string extension = name.Extension;

                    switch (extension)
                    {
                        case "fb2":
                            ImportFileEntry entry = new ImportFileEntry(chkSelectFoundFiles.Checked, name.BaseName, name.URI);
                            entry.Status = ImportStatus.ReadyToProcess;

                            if (entry.Selected)
                            {
                                this.processLegend.IncrementCounter(ImportStatus.ReadyToProcess);
                                this.grdLegend.RefreshDataSource();
                            }

                            this.fileEntries.Add(entry);
                            this.excludeList.Add(file.Name.URI, entry);
                            break;

                        case "zip":
                            String url = "zip:" + name.URI + "!/";
                            
                            //string filename = Path.ChangeExtension(name.BaseName, null);
                            //if(String.Compare(Path.GetExtension(filename), ".fb2", true) == 0)
                            //{
                            //    if (this.excludeList.ContainsKey(url + filename))
                            //    {
                            //        continue;
                            //    }

                            //    entry = new ImportFileEntry(chkSelectFoundFiles.Checked, filename, url + filename);
                            //    entry.Status = ImportStatus.ReadyToProcess;

                            //    if (entry.Selected)
                            //    {
                            //        this.processLegend.IncrementCounter(ImportStatus.ReadyToProcess);
                            //        this.grdLegend.RefreshDataSource();
                            //    }

                            //    this.fileEntries.Add(entry);
                            //    this.excludeList.Add(entry.Uri, entry);
                            //    break;

                            //}

                            IFileObject zipFile = manager.resolveFile(url);
                            ProcessDirectory(zipFile, true);
                            break;

                        case "7z":
                            IFileObject sevenZipFile = manager.resolveFile("sevenzip:" + name.URI + "!/");
                            ProcessDirectory(sevenZipFile, true);
                            break;

                        case "rar":
                            IFileObject rarFile = manager.resolveFile("rar:" + name.URI + "!/");
                            ProcessDirectory(rarFile, true);
                            break;
                    }
                }
                else if (file.Type == FileType.FOLDER && includeSubDirs)
                {
                    ProcessDirectory(file, true);
                }
            }
        }
        
        private enum BookAction
        { 
            None = 0,
            Add = 1,
            Update = 2
        }

        private static bool IsDuplicate(ImportStatus status)
        {
            return status == ImportStatus.Duplicate || status == ImportStatus.DuplicateIDsDiffer || status == ImportStatus.DuplicateNewer || status == ImportStatus.DuplicateOlder;
        }

        private BookAction CheckForDuplicate(FictionBook fictionBook, Fb2DocumentEntry documentEntry, IEnumerable<BookInfo> list)
        {
            BookAction action = BookAction.None;
            
            if(fictionBook.DocumentInfo == null)
            {
                throw new InvalidFictionBookFormatException("Missing required element: document-info");
            }

            ImportStatus checkStatus = ImportStatus.None;

            foreach (BookInfo book in list)
            {
                string srcBookTitle = this.titleRegex.Replace(fictionBook.TitleInfo.BookTitle, "");
                string dstBookTitle = this.titleRegex.Replace(book.BookTitle, "");

                if (String.Compare(srcBookTitle, dstBookTitle, true) == 0)
                {
                    if (String.Compare(book.Id, fictionBook.DocumentInfo.Id) == 0)
                    {
                        float version = float.Parse(book.Version, CultureInfo.InvariantCulture);
                        float documentVersion = fictionBook.DocumentInfo.Version ?? 0;

                        if (documentVersion > version)
                        {
                            checkStatus = ImportStatus.Updated;
                            documentEntry.BookId = book.BookId;
                            action = BookAction.Update;
                            break;
                        }

                        checkStatus = documentVersion < version ? ImportStatus.DuplicateOlder : ImportStatus.Duplicate;
                    }
                    else
                    {
                        checkStatus = ImportStatus.DuplicateIDsDiffer;
                    }
                }
                else
                {
                    string bookTitle = fictionBook.TitleInfo.BookTitle;
                    
                    int distance = StringUtils.DamerauLevenshteinDistance(bookTitle, book.BookTitle);
                    double metric = (1 - (double)distance / bookTitle.Length) * 100.0;

                    if (metric > 70)
                    {
                        metric = StringUtils.LongestCommonSubstring(bookTitle, book.BookTitle) * 100.0 / bookTitle.Length;

                        if(metric > 80)
                        {
                            continue;
                        }

                        if (!String.IsNullOrEmpty(book.Sequence) && !String.IsNullOrEmpty(book.SequenceNumber))
                        {
                            string sequence = null;
                            string sequenceNumber = null;

                            foreach (SequenceInfoNode sequenceInfo in fictionBook.TitleInfo.Sequences)
                            {
                                sequence = StringUtils.Truncate(sequenceInfo.Name, 125);
                                if (sequenceInfo.Number != null)
                                {
                                    sequenceNumber = sequenceInfo.Number.Value.ToString("000", CultureInfo.InvariantCulture);
                                }

                                break;
                            }

                            if(!String.IsNullOrEmpty(sequenceNumber))
                            {
                                if (String.Compare(book.Sequence, sequence) == 0 && String.Compare(book.SequenceNumber, sequenceNumber) != 0)
                                {
                                    continue;
                                }
                            }
                        }

                        if (String.Compare(book.Id, fictionBook.DocumentInfo.Id) == 0)
                        {
                            checkStatus = ImportStatus.Duplicate;
                        }
                        else
                        {
                            checkStatus = ImportStatus.DuplicateIDsDiffer;
                        }
                    }
                }

                if (IsDuplicate(checkStatus))
                {
                    documentEntry.Status = checkStatus;
                    documentEntry.BookId = book.BookId;

                    if (checkStatus == ImportStatus.Duplicate)
                    {
                        if (documentEntry.FileDate > book.FileDate)
                        {
                            documentEntry.Status = ImportStatus.DuplicateNewer;
                        }
                        else if (documentEntry.FileDate < book.FileDate)
                        {
                            documentEntry.Status = ImportStatus.DuplicateOlder;
                        }
                    }

                    break;
                }
            }

            if (checkStatus == ImportStatus.None)
            {
                action = BookAction.Add;
            }

            return action;
        }

        private string SaveFictionBook(string directory, string filename, FictionBook fictionBook, Encoding encoding)
        {
            string outputFilename = String.Empty;
            XmlDocument document = fictionBook.Document;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(memoryStream, encoding))
                    {
                        writer.Formatting = Formatting.None;
                        writer.WriteStartDocument();

                        document.WriteTo(writer);
                        writer.Flush();

                        memoryStream.Capacity = (int) memoryStream.Length;
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        using (ZipFile file = ZipFile.Create(outputFilename))
                        {
                            file.UseZip64 = UseZip64.Off;

                            file.BeginUpdate();
                            file.Add(new StreamDataSource(memoryStream), Path.ChangeExtension(filename, ".fb2"));
                            file.CommitUpdate();
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (!String.IsNullOrEmpty(outputFilename))
                {
                    if (File.Exists(outputFilename))
                    {
                        try
                        {
                            File.Delete(outputFilename);
                        }
                        catch (Exception exp)
                        {
                            Logger.WriteLine(TraceEventType.Verbose, exp);
                        }
                    }
                }
                throw;
            }

            return outputFilename;
        }

        private Encoding GetDocumentEncoding(XmlDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }


            String encodingName = null;
            Encoding encoding;

            if (document.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                XmlDeclaration xmlDeclaration = document.FirstChild as XmlDeclaration;
                if(xmlDeclaration != null)
                {
                    encodingName = xmlDeclaration.Encoding;
                }
            }

            if(String.IsNullOrEmpty(encodingName))
            {
                throw new InvalidFictionBookFormatException("Can't detect the document encoding.");
            }

            try
            {
                encoding = Encoding.GetEncoding(encodingName);

            }
            catch(ArgumentException)
            {
                throw new InvalidFictionBookFormatException(String.Format("The document code page \"{0}\" is not supported by the underlying platform.", encodingName));
            }

            return encoding;
        }

        private ImportStatus ProcessDocument(Fb2DocumentEntry documentEntry, String filename)
        {
            using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return ProcessDocument(documentEntry, stream);
            }
        }

        private ImportStatus ProcessDocument(Fb2DocumentEntry documentEntry, Stream stream)
        {
            ImportStatus importResult;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(new StreamWrapper(stream)))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(reader);

                    importResult = ProcessDocument(documentEntry, stream, document, reader.Encoding);
                }
            }
            catch (XmlException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }
            catch (IOException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }

            return importResult;
        }

        private ImportStatus ProcessDocument(Fb2DocumentEntry documentEntry, Stream stream, XmlDocument document, Encoding encoding)
        {
            ImportStatus importResult;
            FictionBook fictionBook;
            
            try
            {
                importResult = documentEntry.Status;

                fictionBook = new FictionBook(document, encoding);

                if(filter != null && !filter.Fit(new FilterAdapter(fictionBook)))
                {
                    documentEntry.Status = ImportStatus.FilteredOut;
                    this.processLegend.IncrementCounter(documentEntry.Status);

                    return documentEntry.Status;
                }

                BookAction action = BookAction.None;

                if (!dontCheckForDuplicate)
                {
                    Set<int> simularAuthors = new Set<int>();

                    foreach (AuthorInfoNode authorInfoNode in fictionBook.TitleInfo.Authors)
                    {
                        List<Author> list = this.database.FindSimularAuthors(authorInfoNode);
                        simularAuthors.AddRange(list.ConvertAll(delegate(Author author)
                        {
                            return author.Id ?? 0;
                        }));
                    }

                    List<BookInfo> books = this.database.LoadBookInfoByDocumentId(fictionBook.DocumentInfo.Id);
                    action = CheckForDuplicate(fictionBook, documentEntry, books);

                    if (action == BookAction.Add)
                    {
                        List<BookInfo> simularBooks = this.database.LoadBookInfoByAuthorIdList(simularAuthors);
                        action = CheckForDuplicate(fictionBook, documentEntry, simularBooks);
                    }
                }
                else
                {
                    action = BookAction.Add;
                }

                stream.Seek(0, SeekOrigin.Begin);

                BookInfo bookInfo;

                switch (action)
                {
                    case BookAction.Add:
                        importResult = ImportStatus.Added;

                        bookInfo = this.database.CreateFictionBook(fictionBook, stream, documentEntry);
                        documentEntry.BookId = bookInfo.BookId;
                        documentEntry.Status = ImportStatus.Added;
                        break;

                    case BookAction.Update:
                        importResult = ImportStatus.Updated;

                        bookInfo = this.database.LoadBookInfoByBookId(documentEntry.BookId ?? -1);
                        this.database.UpdateFictionBook(bookInfo, fictionBook, stream, documentEntry);

                        documentEntry.BookId = bookInfo.BookId;
                        documentEntry.Status = ImportStatus.Updated;
                        break;

                    case BookAction.None:
                        importResult = documentEntry.Status;
                        break;
                }

                switch (documentEntry.Status)
                {
                    case ImportStatus.Added:
                    case ImportStatus.Updated:
                    case ImportStatus.Duplicate:
                    case ImportStatus.DuplicateIDsDiffer:
                    case ImportStatus.DuplicateNewer:
                    case ImportStatus.DuplicateOlder:
                        this.processLegend.IncrementCounter(documentEntry.Status);
                        break;
                }
            }
            catch(DatabaseException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.DatabaseError);
                importResult = ImportStatus.DatabaseError;
            }
            catch (InvalidFictionBookFormatException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }

            return importResult;
        }

        private ImportStatus CreateOrReplace(Fb2DocumentEntry documentEntry, BookAction action, Stream stream)
        {
            ImportStatus importResult;
            FictionBook fictionBook;

            try
            {
                importResult = documentEntry.Status;

                using (MemoryStream memoryStream = new MemoryStream((int)documentEntry.FileSize))
                {
                    byte[] buffer = bufferPool.Aquire();

                    try
                    {
                        StreamUtils.Copy(stream, memoryStream, buffer);
                    }
                    finally
                    {
                        bufferPool.Release(buffer);
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (XmlTextReader reader = new XmlTextReader(memoryStream))
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(reader);

                        fictionBook = new FictionBook(document, reader.Encoding);

                        memoryStream.Seek(0, SeekOrigin.Begin);

                        switch(action)
                        {
                            case BookAction.Add:
                                BookInfo bookInfo = this.database.CreateFictionBook(fictionBook, memoryStream, documentEntry);
                                documentEntry.BookId = bookInfo.BookId;
                                importResult = ImportStatus.Added;
                                break;

                            case BookAction.Update:
                                bookInfo = database.LoadBookInfoByBookId(documentEntry.BookId ?? -1);
                                this.database.UpdateFictionBook(bookInfo, fictionBook, memoryStream, documentEntry);
                                importResult = ImportStatus.Updated;
                                break;

                        }

                        this.processLegend.IncrementCounter(importResult);
                    }
                }
            }
            catch (DatabaseException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.DatabaseError);
                importResult = ImportStatus.DatabaseError;
            }
            catch (InvalidFictionBookFormatException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }
            catch (XmlException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }
            catch (IOException exp)
            {
                documentEntry.ErrorText = exp.Message;

                this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                importResult = ImportStatus.ParsingError;
            }

            return importResult;
        }

        private void CreateOrReplace(Fb2DocumentEntry documentEntry, BookAction action)
        {
            IFileObject fileObject = manager.resolveFile(documentEntry.Filename);

            ImportFileEntry entry = null;
            if (excludeList.ContainsKey(documentEntry.Filename))
            {
                entry = excludeList[documentEntry.Filename];
            }

            try
            {
                try
                {
                    this.processLegend.DecrementCounter(documentEntry.Status);

                    using (Stream stream = fileObject.Content.InputStream)
                    {
                        try
                        {
                            documentEntry.Status = CreateOrReplace(documentEntry, action, stream);
                        }
                        finally
                        {
                            stream.Close();
                        }
                    }

                    if (entry != null)
                    {
                        entry.Status = documentEntry.Status;
                    }
                }
                catch (Exception exp)
                {
                    Logger.WriteError(exp.Message);
                    Logger.WriteLine(TraceEventType.Verbose, exp);

                    documentEntry.Status = ImportStatus.ParsingError;
                    documentEntry.ErrorText = exp.Message;

                    if (entry != null)
                    {
                        entry.Status = documentEntry.Status;
                    }

                    this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                }
            }
            finally
            {
                manager.closeFileSystem(fileObject.FileSystem);
            }

            this.grdResult.RefreshDataSource();
            this.grdLegend.RefreshDataSource();

            Application.DoEvents();
        }

        private void Process(ImportFileEntry entry)
        {
            Fb2DocumentEntry documentEntry = null;

            try
            {
                IFileObject fileObject = manager.resolveFile(entry.Uri);

                documentEntry = new Fb2DocumentEntry();
                documentEntry.OriginalFileName = entry.DisplayText;
                documentEntry.Filename = entry.Uri;
                documentEntry.FileDate = new DateTime(fileObject.Content.LastModifiedTime);
                documentEntry.FileSize = fileObject.Content.Size;

                try
                {
                    try
                    {
                        processLog.Add(documentEntry);

                        using (Stream stream = fileObject.Content.InputStream)
                        {
                            try
                            {
                                if (stream.CanSeek)
                                {
                                    documentEntry.Status = ProcessDocument(documentEntry, stream);
                                }
                                else
                                {
                                    using (MemoryStream memoryStream = new MemoryStream((int)documentEntry.FileSize))
                                    {
                                        byte[] buffer = bufferPool.Aquire();

                                        try
                                        {
                                            StreamUtils.Copy(stream, memoryStream, buffer);
                                        }
                                        finally
                                        {
                                            bufferPool.Release(buffer);
                                        }

                                        memoryStream.Seek(0, SeekOrigin.Begin);

                                        documentEntry.Status = ProcessDocument(documentEntry, stream);
                                    }
                                }

                            }
                            finally
                            {
                                stream.Close();
                            }
                        }

                        entry.Status = documentEntry.Status;
                    }
                    catch (Exception exp)
                    {
                        Logger.WriteError(exp.Message);
                        Logger.WriteLine(TraceEventType.Verbose, exp);

                        documentEntry.Status = ImportStatus.ParsingError;
                        documentEntry.ErrorText = exp.Message;

                        entry.Status = ImportStatus.ParsingError;

                        this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                    }
                }
                finally
                {
                    manager.closeFileSystem(fileObject.FileSystem);
                }

                this.grdResult.RefreshDataSource();

                switch (documentEntry.Status)
                {
                    case ImportStatus.Added:
                    case ImportStatus.FilteredOut:
                    case ImportStatus.Updated:
                    case ImportStatus.Duplicate:
                        entry.Selected = false;
                        this.processLegend.DecrementCounter(ImportStatus.ReadyToProcess);
                        break;
                }
            }
            catch (FileSystemException exp)
            {
                Logger.WriteError(exp.Message);
                Logger.WriteLine(TraceEventType.Verbose, exp);

                if (documentEntry != null)
                {
                    documentEntry.Status = ImportStatus.ArchiveError;
                    documentEntry.ErrorText = exp.Message;
                }

                entry.Status = ImportStatus.ArchiveError;

                this.processLegend.IncrementCounter(ImportStatus.ArchiveError);
            }

            this.grdSelectedFiles.RefreshDataSource();
            this.grdLegend.RefreshDataSource();

            Application.DoEvents();
        }

        private void Process(Fb2DocumentEntry documentEntry)
        {
            IFileObject fileObject = manager.resolveFile(documentEntry.Filename);

            ImportFileEntry entry = null;
            if(excludeList.ContainsKey(documentEntry.Filename))
            {
                entry = excludeList[documentEntry.Filename];
            }

            try
            {
                try
                {
                    this.processLegend.DecrementCounter(documentEntry.Status);

                    using (Stream stream = fileObject.Content.InputStream)
                    {
                        try
                        {
                            if (stream.CanSeek)
                            {
                                documentEntry.Status = ProcessDocument(documentEntry, stream);
                            }
                            else
                            {
                                using (MemoryStream memoryStream = new MemoryStream((int)documentEntry.FileSize))
                                {
                                    byte[] buffer = bufferPool.Aquire();

                                    try
                                    {
                                        StreamUtils.Copy(stream, memoryStream, buffer);
                                    }
                                    finally
                                    {
                                        bufferPool.Release(buffer);
                                    }

                                    memoryStream.Seek(0, SeekOrigin.Begin);

                                    documentEntry.Status = ProcessDocument(documentEntry, stream);
                                }
                            }

                        }
                        finally
                        {
                            stream.Close();
                        }
                    }

                    if(entry != null)
                    {
                        entry.Status = documentEntry.Status;
                    }
                }
                catch (Exception exp)
                {
                    Logger.WriteError(exp.Message);
                    Logger.WriteLine(TraceEventType.Verbose, exp);

                    documentEntry.Status = ImportStatus.ParsingError;
                    documentEntry.ErrorText = exp.Message;

                    if (entry != null)
                    {
                        entry.Status = documentEntry.Status;
                    }

                    this.processLegend.IncrementCounter(ImportStatus.ParsingError);
                }
            }
            finally
            {
                manager.closeFileSystem(fileObject.FileSystem);
            }

            if (entry != null)
            {
                switch (documentEntry.Status)
                {
                    case ImportStatus.Added:
                    case ImportStatus.FilteredOut:
                    case ImportStatus.Updated:
                    case ImportStatus.Duplicate:
                        if (entry.Selected)
                        {
                            this.processLegend.DecrementCounter(ImportStatus.ReadyToProcess);
                            entry.Selected = false;
                        }
                        break;
                }
            }

            this.grdResult.RefreshDataSource();
            this.grdLegend.RefreshDataSource();

            Application.DoEvents();
        }

        private void txtImportPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string currentDirectory = Environment.CurrentDirectory;

            try
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                browser.ShowNewFolderButton = false;
                browser.SelectedPath = txtImportPath.Text;

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    txtImportPath.Text = browser.SelectedPath;
                }
            }
            finally
            {
                Environment.CurrentDirectory = currentDirectory;
            }
        }

        private void cmdStartImport_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                try
                {
                    db.BeginConnect();

                    this.processedItems = new Set<string>(this.fileEntries.Count);

                    ctlProgressBar.Visibility = BarItemVisibility.Always;
                    cmdStop.Visibility = BarItemVisibility.Always;
                    Application.DoEvents();

                    bool stop = false;

                    ItemClickEventHandler handler = delegate
                    {
                        stop = true;
                    };

                    cmdStop.ItemClick += handler;

                    try
                    {
                        int index = 0;
                        foreach (ImportFileEntry entry in fileEntries)
                        {
                            if (stop)
                            {
                                break;
                            }

                            if (!entry.Selected)
                            {
                                ctlProgressBar.EditValue = ((double)++index / fileEntries.Count) * 100;
                                Application.DoEvents();

                                continue;
                            }

                            Process(entry);
                            
                            ctlProgressBar.EditValue = ((double) ++index / fileEntries.Count) * 100;
                            Application.DoEvents();
                        }
                    }
                    finally
                    {
                        cmdStop.ItemClick -= handler;

                        ctlProgressBar.Visibility = BarItemVisibility.Never;
                        cmdStop.Visibility = BarItemVisibility.Never;
                    }

                    grdSelectedFiles.RefreshDataSource();
                    StoreImportState("FBScanner.xml");
                }
                finally
                {
                    db.EndConnect();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (String.Compare(e.Column.FieldName, "Selected") == 0)
            {
                if (Convert.ToBoolean(e.Value))
                {
                    this.processLegend.IncrementCounter(ImportStatus.ReadyToProcess);
                }
                else
                {
                    this.processLegend.DecrementCounter(ImportStatus.ReadyToProcess);
                }

                grdLegend.RefreshDataSource();
            }
        }
        private void cmdStartSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                IFileObject directory = this.manager.resolveFile(this.txtImportPath.Text);
                this.manager.setBaseFile(directory);

                ProcessDirectory(directory, this.chkIncludeSubDirs.Checked);

                this.grdSelectedFiles.RefreshDataSource();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int index = 0; index < grvSelectedFiles.RowCount; index++)
            {
                ImportFileEntry entry = grvSelectedFiles.GetRow(index) as ImportFileEntry;
                if (entry != null)
                {
                    entry.Selected = true;
                }
            }

            this.processLegend.SetCounterValue(ImportStatus.ReadyToProcess, processLegend[ImportStatus.ReadyToProcess].Counter + grvSelectedFiles.RowCount);

            grdSelectedFiles.RefreshDataSource();
            grdLegend.RefreshDataSource();
        }

        private void cmdUnselectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int index = 0; index < grvSelectedFiles.RowCount; index++)
            {
                ImportFileEntry entry = grvSelectedFiles.GetRow(index) as ImportFileEntry;
                if (entry != null)
                {
                    entry.Selected = false;
                }
            }

            this.processLegend.SetCounterValue(ImportStatus.ReadyToProcess, processLegend[ImportStatus.ReadyToProcess].Counter - grvSelectedFiles.RowCount);

            grdSelectedFiles.RefreshDataSource();
            grdLegend.RefreshDataSource();
        }

        private void cmdClearList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fileEntries.Clear();
            excludeList.Clear();
            
            this.processLegend.SetCounterValue(ImportStatus.ReadyToProcess, 0);

            grdSelectedFiles.RefreshDataSource();
            grdLegend.RefreshDataSource();
        }

        private void cmdRemoveProcessed_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = 0;
            while (index < fileEntries.Count)
            {
                ImportFileEntry entry = fileEntries[index];
                if (!entry.Selected)
                {
                    switch (entry.Status)
                    {
                        case ImportStatus.Added:
                        case ImportStatus.Updated:
                            if(excludeList.ContainsKey(entry.Uri))
                            {
                                excludeList.Remove(entry.Uri);
                            }

                            fileEntries.RemoveAt(index);
                            continue;
                    }
                }
                index++;
            }

            grdSelectedFiles.RefreshDataSource();
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            BookFilterEditor editor = new BookFilterEditor(db);
            editor.FilterString = this.filterCriteria ?? String.Empty;
            if(editor.ShowDialog(this) == DialogResult.OK)
            {
                this.filterCriteria = editor.FilterString;

                this.filter = null;
                if (!String.IsNullOrEmpty(this.filterCriteria))
                {
                    this.filter = new FilterEvaluator(properties, this.filterCriteria);
                }
            }
        }

        private LegendViewMode legendViewMode;
        private readonly Regex titleRegex;

        private LegendViewMode LegendViewMode
        {
            get
            {
                return legendViewMode;
            }

            set
            {
                if(legendViewMode != value)
                {
                    legendViewMode = value;
                    OnLegendViewModeChanged();
                }
            }
        }

        protected void OnLegendViewModeChanged()
        {
            switch (legendViewMode)
            {
                case LegendViewMode.None:
                case LegendViewMode.ErrorInfo:
                    layoutControl1.BeginUpdate();

                    layoutControlGroup2.Visibility = LayoutVisibility.Never;
                    splitterItem2.Visibility = LayoutVisibility.Never;
                    layoutControlGroup3.Visibility = LayoutVisibility.Never;

                    emptySpaceItem1.Visibility = LayoutVisibility.OnlyInRuntime;
                    //emptySpaceItem1.Width = layoutControl1.Width - layoutControlGroup1.Width - splitterItem1.Width * 2;

                    layoutControl1.EndUpdate();
                    break;

                case LegendViewMode.BookInfo:
                    layoutControl1.BeginUpdate();

                    layoutControlGroup2.Visibility = LayoutVisibility.Always;
                    layoutControlGroup2.Width = layoutControl1.Width - layoutControlGroup1.Width - splitterItem1.Width * 2;

                    splitterItem2.Visibility = LayoutVisibility.Never;
                    layoutControlGroup3.Visibility = LayoutVisibility.Never;
                    emptySpaceItem1.Visibility = LayoutVisibility.Never;

                    layoutControl1.EndUpdate();
                    break;


                case LegendViewMode.ConflictInfo:
                    layoutControl1.BeginUpdate();

                    int width = layoutControl1.Width - layoutControlGroup1.Width - splitterItem1.Width * 2;

                    layoutControlGroup2.Visibility = LayoutVisibility.Always;
                    layoutControlGroup2.Width = width / 2;
                    
                    splitterItem2.Visibility = LayoutVisibility.Always;
                    
                    layoutControlGroup3.Visibility = LayoutVisibility.Always;
                    layoutControlGroup3.Width = width / 2;

                    emptySpaceItem1.Visibility = LayoutVisibility.Never;

                    layoutControl1.EndUpdate();
                    break;
            }
        }


        private BriefBookInfo LoadBriefBookInfo(int bookId)
        {
            try
            {
                BookInfo bookInfo = database.LoadBookInfoByBookId(bookId);
                if (bookInfo != null)
                {
                    return new BriefBookInfo(bookInfo);
                }
            }
            catch (DatabaseException)
            {
            }

            return null;
        }

        private BriefBookInfo LoadBriefBookInfo(Fb2DocumentEntry documentEntry)
        {
            try
            {
                IFileObject fileObject = manager.resolveFile(documentEntry.Filename);

                try
                {
                    using (Stream stream = fileObject.Content.InputStream)
                    {
                        try
                        {
                            using (XmlTextReader reader = new XmlTextReader(new StreamWrapper(stream)))
                            {
                                XmlDocument document = new XmlDocument();
                                document.Load(reader);

                                FictionBook fictionBook = new FictionBook(document, reader.Encoding);
                                return new BriefBookInfo(fictionBook, documentEntry);
                            }

                        }
                        finally
                        {
                            stream.Close();
                        }
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    manager.closeFileSystem(fileObject.FileSystem);
                }
            }
            catch (FileSystemException)
            {
            }

            return null;
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(e.FocusedRowHandle != GridControl.InvalidRowHandle)
            {
                if(grvResult.IsDataRow(e.FocusedRowHandle) /*&& grvResult.IsRowSelected(e.FocusedRowHandle)*/)
                {
                    FocusedRowChanged(e.FocusedRowHandle);
                }
            }
        }

        private void FocusedRowChanged(int rowHandle)
        {
            if(rowHandle == GridControl.InvalidRowHandle)
            {
                LegendViewMode = LegendViewMode.None;

                FocusedRowChanged(null);
            }
            else
            {
                Fb2DocumentEntry documentEntry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                FocusedRowChanged(documentEntry);
            }
        }

        private void FocusedRowChanged(Fb2DocumentEntry entry)
        {
            if (entry == null)
            {
                this.cmdReprocessItem.Enabled = false;
                this.cmdReplaceBook.Enabled = false;
                this.cmdCreateNewBook.Enabled = false;
                
                return;
            }

            switch (entry.Status)
            {
                case ImportStatus.Added:
                    this.LegendViewMode = LegendViewMode.BookInfo;
                            
                    this.briefBookInfo1.DataSource = LoadBriefBookInfo(entry.BookId ?? -1);
                    break;

                case ImportStatus.FilteredOut:
                    this.LegendViewMode = LegendViewMode.BookInfo;

                    this.briefBookInfo1.DataSource = LoadBriefBookInfo(entry);
                    break;

                case ImportStatus.Duplicate:
                case ImportStatus.DuplicateIDsDiffer:
                case ImportStatus.DuplicateNewer:
                case ImportStatus.DuplicateOlder:
                    this.LegendViewMode = LegendViewMode.ConflictInfo;

                    this.briefBookInfo1.DataSource = LoadBriefBookInfo(entry.BookId ?? -1);
                    this.briefBookInfo2.DataSource = LoadBriefBookInfo(entry);
                    break;

                case ImportStatus.ArchiveError:
                case ImportStatus.DatabaseError:
                case ImportStatus.ParsingError:
                    this.LegendViewMode = LegendViewMode.ErrorInfo;

                    this.emptySpaceItem1.Text = entry.ErrorText;
                    this.emptySpaceItem1.TextVisible = true;
                    break;

                default:
                    this.LegendViewMode = LegendViewMode.None;
                    this.emptySpaceItem1.TextVisible = false;
                    break;
            }

            switch (this.grvResult.SelectedRowsCount)
            {
                case 0:
                    this.cmdReprocessItem.Enabled = false;
                    this.cmdReplaceBook.Enabled = false;
                    this.cmdCreateNewBook.Enabled = false;

                    this.cmdViewSourceBook.Enabled = false;
                    this.cmdViewLibraryBook.Enabled = false;
                    break;

                case 1:
                    switch (entry.Status)
                    {
                        case ImportStatus.FilteredOut:
                            this.cmdReprocessItem.Enabled = true;
                            this.cmdReplaceBook.Enabled = false;
                            this.cmdCreateNewBook.Enabled = false;

                            this.cmdViewSourceBook.Enabled = true;
                            this.cmdViewLibraryBook.Enabled = false;
                            break;

                        case ImportStatus.ReadyToProcess:
                        case ImportStatus.ArchiveError:
                        case ImportStatus.DatabaseError:
                        case ImportStatus.ParsingError:
                            this.cmdReprocessItem.Enabled = true;
                            this.cmdReplaceBook.Enabled = false;
                            this.cmdCreateNewBook.Enabled = false;
                            
                            this.cmdViewSourceBook.Enabled = false;
                            this.cmdViewLibraryBook.Enabled = false;
                            break;

                        case ImportStatus.Duplicate:
                        case ImportStatus.DuplicateIDsDiffer:
                        case ImportStatus.DuplicateNewer:
                        case ImportStatus.DuplicateOlder:
                            this.cmdReprocessItem.Enabled = true;
                            this.cmdReplaceBook.Enabled = true;
                            this.cmdCreateNewBook.Enabled = true;
                            
                            this.cmdViewSourceBook.Enabled = true;
                            this.cmdViewLibraryBook.Enabled = true;
                            break;

                        case ImportStatus.Added:
                        case ImportStatus.Updated:
                            this.cmdReprocessItem.Enabled = false;
                            this.cmdReplaceBook.Enabled = false;
                            this.cmdCreateNewBook.Enabled = false;
                            
                            this.cmdViewSourceBook.Enabled = false;
                            this.cmdViewLibraryBook.Enabled = true;
                            break;

                        default:
                            this.cmdReprocessItem.Enabled = false;
                            this.cmdReplaceBook.Enabled = false;
                            this.cmdCreateNewBook.Enabled = false;
                            
                            this.cmdViewSourceBook.Enabled = false;
                            this.cmdViewLibraryBook.Enabled = false;
                            break;
                    }
                    break;

                default:
                    this.cmdReprocessItem.Enabled = true;
                    this.cmdReplaceBook.Enabled = true;
                    this.cmdCreateNewBook.Enabled = true;

                    this.cmdViewSourceBook.Enabled = false;
                    this.cmdViewLibraryBook.Enabled = false;
                    break;
            }
        }

        private void grdResult_BindingContextChanged(object sender, EventArgs e)
        {
            //if (grvResult.OptionsSelection.MultiSelect && grdResult.DataSource != null)
            //{
            //    CurrencyManager currencyManager = (CurrencyManager)grdResult.BindingContext[grdResult.DataSource];
        
            //    currencyManager.PositionChanged += (delegate
            //    {
            //        if(currencyManager.Position >= 0 && currencyManager.Position < this.processLog.Count)
            //        {
            //            Fb2DocumentEntry entry = this.processLog[currencyManager.Position];
            //            FocusedRowChanged(entry);
            //        }
            //    });
            //}
        }

        private void grvResult_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
        }

        private void grvSelectedFiles_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridHitInfo hitInfo = grvSelectedFiles.CalcHitInfo(e.Point);

            switch (e.MenuType)
            {
                case GridMenuType.Row:
                    grvSelectedFiles.FocusedRowHandle = hitInfo.RowHandle;
                    mnuSelectedFiles.ShowPopup(this.ctlCommandManager, grdSelectedFiles.PointToScreen(e.Point));
                    break;

                case GridMenuType.User:
                    mnuSelectedFiles.ShowPopup(this.ctlCommandManager, grdSelectedFiles.PointToScreen(e.Point));
                    break;
            }
        }

        private void grvResult_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                switch (e.MenuType)
                {
                    case GridMenuType.Row:
                        view.FocusedRowHandle = hitInfo.RowHandle;
                        goto case GridMenuType.User;
                    
                    case GridMenuType.User:
                        FocusedRowChanged(view.FocusedRowHandle);
                        mnuResult.ShowPopup(this.ctlCommandManager, this.grdResult.PointToScreen(e.Point));
                        break;
                }
            }
        }

        private void cmdReprocessItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                if (grvResult.SelectedRowsCount > 0)
                {
                    int[] selectedRows = grvResult.GetSelectedRows();
                    List<Fb2DocumentEntry> toReprocess = new List<Fb2DocumentEntry>(grvResult.SelectedRowsCount);

                    foreach (int rowHandle in selectedRows)
                    {
                        Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                        if (entry != null)
                        {
                            switch (entry.Status)
                            {
                                case ImportStatus.None:
                                case ImportStatus.Added:
                                case ImportStatus.Updated:
                                case ImportStatus.NeedDescription:
                                    continue;
                            }

                            toReprocess.Add(entry);
                        }
                    }

                    foreach (Fb2DocumentEntry entry in toReprocess)
                    {
                        Process(entry);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdReplaceBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                if (grvResult.SelectedRowsCount > 0)
                {
                    int[] selectedRows = grvResult.GetSelectedRows();
                    List<Fb2DocumentEntry> toReplace = new List<Fb2DocumentEntry>(grvResult.SelectedRowsCount);

                    foreach (int rowHandle in selectedRows)
                    {
                        Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                        if (entry != null)
                        {
                            switch (entry.Status)
                            {
                                case ImportStatus.Duplicate:
                                case ImportStatus.DuplicateIDsDiffer:
                                case ImportStatus.DuplicateNewer:
                                case ImportStatus.DuplicateOlder:
                                    toReplace.Add(entry);
                                    break;
                            }
                        }
                    }

                    foreach (Fb2DocumentEntry entry in toReplace)
                    {
                        CreateOrReplace(entry, BookAction.Update);
                    }

                    FocusedRowChanged(grvResult.FocusedRowHandle);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdCreateNewBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                if (grvResult.SelectedRowsCount > 0)
                {
                    int[] selectedRows = grvResult.GetSelectedRows();
                    List<Fb2DocumentEntry> toCreate = new List<Fb2DocumentEntry>(grvResult.SelectedRowsCount);

                    foreach (int rowHandle in selectedRows)
                    {
                        Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                        if (entry != null)
                        {
                            switch (entry.Status)
                            {
                                case ImportStatus.Duplicate:
                                case ImportStatus.DuplicateIDsDiffer:
                                case ImportStatus.DuplicateNewer:
                                case ImportStatus.DuplicateOlder:
                                    toCreate.Add(entry);
                                    break;
                            }
                        }
                    }

                    foreach (Fb2DocumentEntry entry in toCreate)
                    {
                        CreateOrReplace(entry, BookAction.Add);
                    }

                    FocusedRowChanged(grvResult.FocusedRowHandle);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdClearResultList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(this, "Вы действительно хотите очистить список?", "Журнал обработки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            processLog.Clear();

            foreach (ProcessLegendItem item in processLegend)
            {
                if(item.Status == ImportStatus.ReadyToProcess)
                {
                    continue;
                }

                item.Counter = 0;
            }

            grdResult.RefreshDataSource();
            grdLegend.RefreshDataSource();

            LegendViewMode = LegendViewMode.None;
        }

        private void cmdRemoveEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                if (grvResult.SelectedRowsCount > 0)
                {
                    grvResult.BeginDataUpdate();
                    try
                    {
                        List<Fb2DocumentEntry> toRemove = new List<Fb2DocumentEntry>(grvResult.SelectedRowsCount);

                        int[] selectedRows = grvResult.GetSelectedRows();
                        foreach (int rowHandle in selectedRows)
                        {
                            Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                            if (entry != null)
                            {
                                toRemove.Add(entry);
                            }
                        }

                        foreach (Fb2DocumentEntry entry in toRemove)
                        {
                            processLog.Remove(entry);
                            processLegend.DecrementCounter(entry.Status);
                        }
                    }
                    finally
                    {
                        grvResult.EndDataUpdate();
                        grvResult.ClearSelection();

                        if (grvResult.FocusedRowHandle != GridControl.InvalidRowHandle)
                        {
                            grvResult.SelectRow(grvResult.FocusedRowHandle);
                        }
 
                        FocusedRowChanged(grvResult.FocusedRowHandle);
 
                        grdLegend.RefreshDataSource();
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cmdSaveProcessLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string currentDirectory = Environment.CurrentDirectory;

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.CheckPathExists = true;
                dialog.OverwritePrompt = true;
                dialog.Title = "Сохранить журнал операций...";
                dialog.Filter = "XML файлы|*.xml|Все файлы|*.*";

                if(dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ScannerState state = new ScannerState();

                    state.Legend = new List<XmlLegendItem>(processLegend.Count);
                    foreach (ProcessLegendItem legendItem in processLegend)
                    {
                        state.Legend.Add(new XmlLegendItem(legendItem));
                    }

                    state.Log = processLog.ConvertAll(x => new XmlFb2DocumentEntry(x));

                    XmlSerializer serializer = new XmlSerializer(typeof(ScannerState));
                    try
                    {
                        using (TextWriter writer = new StreamWriter(dialog.FileName))
                        {
                            serializer.Serialize(writer, state);
                        }
                    }
                    catch (IOException)
                    {
                    }
                }
            }
            finally
            {
                Environment.CurrentDirectory = currentDirectory;
            }
        }


        private void ShowBookPreview(Stream stream)
        {
            using (XmlTextReader reader = new XmlTextReader(new StreamWrapper(stream)))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                FictionBook fictionBook = new FictionBook(document, reader.Encoding);

                BookPreviewForm form = new BookPreviewForm();
                form.LoadFrom(fictionBook);

                Cursor = Cursors.Default;

                form.ShowDialog(this);
            }
        }

        private void ShowBookPreview(IFileObject fileObject)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (Stream stream = fileObject.Content.InputStream)
                {
                    try
                    {
                        ShowBookPreview(stream);
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowBookPreview(int bookId)
        {
            db.BeginConnect();

            try
            {
                BookInfo bookInfo = database.LoadBookInfoByBookId(bookId);

                DatabaseInfo info = database.DatabaseInfo;
                if(info.WorkMode == (short) StorageMode.FileSystem)
                {
                    IFileObject fileObject = manager.resolveFile(Path.Combine(info.MountPoint, bookInfo.FileName));
                    try
                    {
                        ShowBookPreview(fileObject);
                    }
                    finally
                    {
                        manager.closeFileSystem(fileObject.FileSystem);
                    }
                }
                else if(info.WorkMode == (short) StorageMode.IndexOnly)
                {
                    IFileObject fileObject = manager.resolveFile(bookInfo.FileName);
                    try
                    {
                        ShowBookPreview(fileObject);
                    }
                    finally
                    {
                        manager.closeFileSystem(fileObject.FileSystem);
                    }
                }
                else if(info.WorkMode == (short) StorageMode.Database)
                {
                    using (FbCommand command = db.Connection.CreateCommand())
                    {
                        command.CommandText = "SELECT FIRST 1 text FROM book WHERE bookid = @bookid";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@bookid", FbDbType.Integer).Value = bookId;

                        FbDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                        byte[] buffer = null;
                        try
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    long textLength = reader.GetBytes(0, 0, null, 0, 0);
                                    if (textLength > 0)
                                    {
                                        buffer = new byte[textLength];
                                        reader.GetBytes(0, 0, buffer, 0, buffer.Length);
                                    }
                                }
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }

                        if(buffer != null)
                        {
                            using(MemoryStream ms = new MemoryStream(buffer, false))
                            {
                                using (ZipFile file = new ZipFile(ms))
                                {
                                    foreach (ZipEntry zipEntry in file)
                                    {
                                        if (!zipEntry.IsFile || !zipEntry.CanDecompress || zipEntry.IsCrypted)
                                        {
                                            continue;
                                        }

                                        using(Stream stream = file.GetInputStream(zipEntry))
                                        {
                                            ShowBookPreview(stream);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                db.EndConnect();
            }
        }

        private void cmdViewSourceBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvResult.SelectedRowsCount > 0)
            {
                int[] selectedRows = grvResult.GetSelectedRows();

                foreach (int rowHandle in selectedRows)
                {
                    Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                    if (entry != null)
                    {
                        IFileObject fileObject = manager.resolveFile(entry.Filename);

                        try
                        {
                            ShowBookPreview(fileObject);
                        }
                        finally
                        {
                            manager.closeFileSystem(fileObject.FileSystem);
                        }

                        break;
                    }
                }
            }
        }

        private void cmdViewLibraryBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvResult.SelectedRowsCount > 0)
            {
                int[] selectedRows = grvResult.GetSelectedRows();

                foreach (int rowHandle in selectedRows)
                {
                    Fb2DocumentEntry entry = grvResult.GetRow(rowHandle) as Fb2DocumentEntry;
                    if (entry != null)
                    {
                        ShowBookPreview(entry.BookId ?? -1);
                        break;
                    }
                }
            }
        }
    }
}