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
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Xsl;
using Tanone.Common.DBUtils;

using Gremlin.FB2Librarian.Import.Entities;
using Gremlin.FB2Librarian.Import.ObjectModel;
using Gremlin.FB2Librarian.Import.Utils;

using FirebirdSql.Data.FirebirdClient;
using Gremlin.FB2Librarian.Import.SevenZip;

namespace Gremlin.FB2Librarian.Import
{
    internal class FirebirdDataAccess
    {
        private FbConnection connection;
        private TCommonFireBirdDB manager;

        private volatile List<Author> authorList;
        private volatile List<AuthorSynonym> synonyms;
        private readonly object authorListLock = new object();

        private XslCompiledTransform xslt;

        private volatile DatabaseInfo databaseInfo;
        private volatile FileNameProvider provider;

        private readonly object dataAccessLock = new object();
        private readonly SevenZipFormat format;

        public FirebirdDataAccess(TCommonFireBirdDB manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }

            this.manager = manager;
            this.connection = manager.Connection;

            XsltSettings settings = new XsltSettings();

            this.xslt = new XslCompiledTransform();
            this.xslt.Load("fb2_text_annotation.xsl", settings, new XmlResourceResolver());
            format = new SevenZipFormat("other/7z.dll");
        }

        private List<Author> AuthorList
        {
            get
            {
                if (this.authorList == null)
                {
                    lock (this.authorListLock)
                    {
                        if (this.authorList == null)
                        {
                            this.authorList = LoadAuthorList();
                        }
                    }
                }

                return this.authorList;
            }
        }

        private List<AuthorSynonym> SynonymList
        {
            get
            {
                if (this.synonyms == null)
                {
                    lock (this.authorListLock)
                    {
                        if (this.synonyms == null)
                        {
                            this.synonyms = LoadAuthorSynonyms();
                        }
                    }
                }

                return this.synonyms;
            }
        }

        public DatabaseInfo DatabaseInfo
        {
            get
            {
                if(this.databaseInfo == null)
                {
                    lock(this.dataAccessLock)
                    {
                        if(this.databaseInfo == null)
                        {
                            this.databaseInfo = LoadDatabaseInfo();
                        }
                    }
                }

                return databaseInfo;
            }
        }

        public void BeginConnect()
        {
            this.manager.BeginConnect();
        }

        public void EndConnect()
        {
            this.manager.EndConnect();
        }

        public IDbTransaction BeginTransaction(IsolationLevel level)
        {
            return this.connection.BeginTransaction(level);
        }

        public IDbTransaction BeginTransaction()
        {
            return this.connection.BeginTransaction();
        }

        private class UpdateBookCallback : IProgress, IArchiveUpdateCallback
        {
            private Stream content;
            private string filename;
            private Fb2DocumentEntry documentEntry;

            public UpdateBookCallback(Stream content, string filename, Fb2DocumentEntry documentEntry)
            {
                this.content = content;
                this.filename = filename;
                this.documentEntry = documentEntry;
            }

            public void SetTotal(ulong total)
            {
            }

            public void SetCompleted(ref ulong completeValue)
            {
            }

            public void GetUpdateItemInfo(int index, out int newData, out int newProperties, out uint indexInArchive)
            {
                newData = 1;
                newProperties = 1;
                indexInArchive = UInt32.MaxValue;
            }

            public void GetProperty(int index, ItemPropId propID, ref PropVariant value)
            {
                switch (propID)
                {
                    case ItemPropId.kpidPath:
                        value.VarType = VarEnum.VT_BSTR;
                        value.pointerValue = Marshal.StringToBSTR(Path.GetFileName(filename));
                        break;

                    case ItemPropId.kpidIsFolder:
                    case ItemPropId.kpidIsAnti:
                        value.VarType = VarEnum.VT_BOOL;
                        value.longValue = 0;
                        break;

                    case ItemPropId.kpidCreationTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = (documentEntry.FileDate ?? DateTime.Now).ToFileTime();
                        break;

                    case ItemPropId.kpidLastAccessTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = (documentEntry.FileDate ?? DateTime.Now).ToFileTime();
                        break;

                    case ItemPropId.kpidLastWriteTime:
                        value.VarType = VarEnum.VT_FILETIME;
                        value.longValue = (documentEntry.FileDate ?? DateTime.Now).ToFileTime();
                        break;

                    case ItemPropId.kpidSize:
                        value.VarType = VarEnum.VT_UI8;
                        value.longValue = content.Length;
                        break;
                }
            }

            public void GetStream(int index, out ISequentialInStream inStream)
            {
                inStream = new InStreamWrapper(content);
            }

            public void SetOperationResult(int operationResult)
            {
            }
        }

        public BookInfo CreateFictionBook(FictionBook fictionBook, Stream content, Fb2DocumentEntry documentEntry)
        {
            this.manager.BeginConnect();

            try
            {
                List<Author> authorList = AuthorList;

                FbTransaction transaction = this.connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                try
                {
                    DatabaseInfo info = this.DatabaseInfo;
                    FileNameProvider provider = this.NamingProvider;

                    BookInfo book = CreateFictionBook(fictionBook, content, documentEntry, transaction);

                    if (info.WorkMode == (short)StorageMode.FileSystem)
                    {
                        string bookFilename = GetFilename(fictionBook) + ".fb2";
                        string outputFullPath = Path.Combine(info.MountPoint, bookFilename);
                        string outputDirectory = Path.GetDirectoryName(outputFullPath).Trim();

                        string outputFilename = Path.GetFileNameWithoutExtension(outputFullPath).Trim();
                        outputFilename = FileUtils.GetOutputFileName(outputDirectory, outputFilename, ".fb2.zip");

                        if (!Directory.Exists(outputDirectory))
                        {
                            Directory.CreateDirectory(outputDirectory);
                        }

                        //using (ZipFile file = ZipFile.Create(outputFilename))
                        //{
                        //    file.UseZip64 = UseZip64.Off;

                        //    file.BeginUpdate();
                        //    file.Add(new StreamDataSource(content), Path.GetFileName(bookFilename));
                        //    file.CommitUpdate();
                        //}

                        IOutArchive archive = this.format.CreateOutArchive(SevenZipFormat.GetClassIdFromKnownFormat(KnownSevenZipFormat.Zip));

                        try
                        {
                            using (FileStream stream = File.Open(outputFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                            {
                                OutStreamWrapper archiveStream = new OutStreamWrapper(stream);
                                archive.UpdateItems(archiveStream, 1, new UpdateBookCallback(content, Path.GetFileName(bookFilename), documentEntry));
                            }
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(archive);
                        }

                        string commandText =
                            " UPDATE BOOK " +
                            "   SET FILENAME = @filename " +
                            "   WHERE BOOKID = @bookid ";

                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = commandText;
                            command.Transaction = transaction;

                            command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                            command.Parameters.Add("@filename", FbDbType.VarChar).Value = FileUtils.SplitFilePath(info.MountPoint, outputFilename);

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (info.WorkMode == (short)StorageMode.Database)
                    {
                        string bookFilename = GetFilename(fictionBook) + ".fb2";

                        using(MemoryStream stream = new MemoryStream())
                        {
                            //using (ZipFile file = ZipFile.Create(stream))
                            //{
                            //    file.UseZip64 = UseZip64.Off;

                            //    file.BeginUpdate();
                            //    file.Add(new StreamDataSource(content), Path.GetFileName(bookFilename));
                            //    file.CommitUpdate();
                            //}

                            IOutArchive archive = this.format.CreateOutArchive(SevenZipFormat.GetClassIdFromKnownFormat(KnownSevenZipFormat.Zip));

                            try
                            {
                                OutStreamWrapper archiveStream = new OutStreamWrapper(stream);
                                archive.UpdateItems(archiveStream, 1, new UpdateBookCallback(content, bookFilename, documentEntry));
                            }
                            finally
                            {
                                Marshal.ReleaseComObject(archive);
                            }

                            stream.Capacity = (int)stream.Length;

                            string commandText =
                                " UPDATE BOOK " +
                                "   SET FILENAME = @filename, TEXT = @text " +
                                "   WHERE BOOKID = @bookid ";

                            using (FbCommand command = this.connection.CreateCommand())
                            {
                                command.CommandType = CommandType.Text;
                                command.CommandText = commandText;
                                command.Transaction = transaction;

                                command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                                command.Parameters.Add("@text", FbDbType.Binary).Value = stream.GetBuffer();
                                command.Parameters.Add("@filename", FbDbType.VarChar).Value = bookFilename + ".zip";

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (info.WorkMode == (short)StorageMode.IndexOnly)
                    {
                        string commandText =
                            " UPDATE BOOK " +
                            "   SET FILENAME = @filename " +
                            "   WHERE BOOKID = @bookid ";

                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = commandText;
                            command.Transaction = transaction;

                            command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                            command.Parameters.Add("@filename", FbDbType.VarChar).Value = documentEntry.Filename;

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return book;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            finally 
            {
                this.manager.EndConnect();
            }
        }

        public BookInfo CreateFictionBook(FictionBook fictionBook, Stream content, Fb2DocumentEntry documentEntry, IDbTransaction transaction)
        {
            if (fictionBook == null)
            {
                throw new ArgumentNullException("fictionBook");
            }

            this.manager.BeginConnect();

            try
            {
                DatabaseInfo info = this.DatabaseInfo;

                List<Author> bookAuthors = new List<Author>(fictionBook.TitleInfo.Authors.Count);
                List<Author> documentAuthors = new List<Author>(fictionBook.DocumentInfo.Authors.Count);
                List<Author> bookTranslators = new List<Author>(fictionBook.TitleInfo.Translators.Count);
                List<SequenceInfo> bookSequences = new List<SequenceInfo>(fictionBook.TitleInfo.Sequences.Count);
                List<Genre> bookGenres = new List<Genre>(fictionBook.TitleInfo.Genres.Count);

                foreach (AuthorInfoNode authorInfoNode in fictionBook.TitleInfo.Authors)
                {
                    Author author = this.FindOrCreateAuthor(authorInfoNode, transaction);
                    if(author != null)
                    {
                        bookAuthors.Add(author);
                    }
                }

                foreach (AuthorInfoNode authorInfoNode in fictionBook.DocumentInfo.Authors)
                {
                    Author author = this.FindOrCreateDocumentAuthor(authorInfoNode, transaction);
                    if(author != null)
                    {
                        documentAuthors.Add(author);
                    }
                }

                foreach (AuthorInfoNode authorInfoNode in fictionBook.TitleInfo.Translators)
                {
                    Author translator = this.FindOrCreateTranslator(authorInfoNode, transaction);
                    if(translator != null)
                    {
                        bookTranslators.Add(translator);
                    }
                }

                foreach (SequenceInfoNode sequenceInfoNode in fictionBook.TitleInfo.Sequences)
                {
                    SequenceInfo sequence = this.FindOrCreateBookSequence(sequenceInfoNode, transaction);
                    if(sequence != null)
                    {
                        bookSequences.Add(sequence);
                    }
                }

                Set<Genre> genres = new Set<Genre>(fictionBook.TitleInfo.Genres.Count);
                foreach (GenreInfoNode genreInfoNode in fictionBook.TitleInfo.Genres)
                {
                    string genreName = genreInfoNode.Genre;
                    if (GenreTable.Table.MapTable.ContainsKey(genreName))
                    {
                        genreName = GenreTable.Table.MapTable[genreName];
                    }

                    Genre bookGenre = GenreTable.Table[genreName];
                    if(bookGenre != null)
                    {
                        genres.Add(bookGenre);
                    }
                }

                bookGenres.AddRange(genres);

                BookInfo book = new BookInfo();
                book.Genrelist = StringUtils.Truncate(StringUtils.Join(", ", bookGenres), 1024);

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "annotation");
                    this.xslt.Transform(fictionBook.Document, arguments, writer);
                    book.Annotation = StringUtils.Truncate(writer.ToString(), 4096);
                }

                book.AuthorList = StringUtils.Truncate(StringUtils.Join("; ", bookAuthors), 254);
                book.Keywords = StringUtils.Truncate(fictionBook.TitleInfo.Keywords, 254);
                book.BookTitle = StringUtils.Truncate(fictionBook.TitleInfo.BookTitle, 252);

                if (fictionBook.TitleInfo.DateNode != null)
                {
                    book.DateValue = fictionBook.TitleInfo.DateNode.Value;
                    book.DateText = StringUtils.Truncate(fictionBook.TitleInfo.DateNode.DateString, 25);
                }

                book.Lang = StringUtils.Truncate(fictionBook.TitleInfo.Lang, 10);
                book.SrcLang = StringUtils.Truncate(fictionBook.TitleInfo.SourceLang, 10);

                foreach (SequenceInfo sequenceInfo in bookSequences)
                {
                    book.SequenceId = sequenceInfo.SequenceId;
                    book.Sequence = StringUtils.Truncate(sequenceInfo.SequenceName, 125);
                    if (sequenceInfo.SequenceNumber != null)
                    {
                        book.SequenceNumber = sequenceInfo.SequenceNumber.Value.ToString("000", CultureInfo.InvariantCulture);
                    }

                    break;
                }

                book.ProgrammUsed = StringUtils.Truncate(fictionBook.DocumentInfo.ProgramUsed ?? String.Empty, 254);
                
                if (fictionBook.DocumentInfo.DateNode != null)
                {
                    book.DocumentDateValue = fictionBook.DocumentInfo.DateNode.Value;
                    book.DocumentDateText = StringUtils.Truncate(fictionBook.DocumentInfo.DateNode.DateString ?? String.Empty, 14);
                }
                else
                {
                    book.DocumentDateValue = null;
                    book.DocumentDateText = String.Empty;
                }

                book.SrcUrl = StringUtils.Truncate(StringUtils.Join(", ", fictionBook.DocumentInfo.SourceUrl), 254);
                book.SrcOcr = StringUtils.Truncate(fictionBook.DocumentInfo.SourceOCR ?? String.Empty, 254);
                book.Id = StringUtils.Truncate(fictionBook.DocumentInfo.Id, 254);
                book.Version = DocumentInfoNode.FormatVersion(fictionBook.DocumentInfo.Version ?? 0.0f);

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "history");
                    this.xslt.Transform(fictionBook.Document, arguments, writer);
                    book.History = writer.ToString();
                }

                if (fictionBook.PublishInfo != null)
                {
                    book.BookName = StringUtils.Truncate(fictionBook.PublishInfo.BookName ?? String.Empty, 254);
                    book.Publisher = StringUtils.Truncate(fictionBook.PublishInfo.Publisher ?? String.Empty, 254);
                    book.City = StringUtils.Truncate(fictionBook.PublishInfo.City ?? String.Empty, 50);

                    if (fictionBook.PublishInfo.Year != null)
                    {
                        book.Year = StringUtils.Truncate(fictionBook.PublishInfo.Year.ToString(), 10);
                    }
                    else
                    {
                        book.Year = String.Empty;
                    }

                    book.Isbn = StringUtils.Truncate(fictionBook.PublishInfo.ISBN ?? String.Empty, 125);
                }
                else
                {
                    book.BookName = String.Empty;
                    book.Publisher = String.Empty;
                    book.City = String.Empty;
                    book.Year = String.Empty;
                    book.Isbn = String.Empty;
                }

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "custom-info");
                    this.xslt.Transform(fictionBook.Document, arguments, writer);
                    book.CustomInfo = writer.ToString();
                }

                book.DateInserted = DateTime.Now;
                book.DateUpdated = null;
                book.Extension = "FB2";

                book.FileDate = documentEntry.FileDate ?? DateTime.Now;
                book.FileSize = documentEntry.FileSize;

                book.SurrogateId = Regex.Replace(String.Concat(book.BookTitle, book.AuthorList), @"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]", "").Trim().ToUpperInvariant();

                book.Userid = info.CurrentUserId;
                book.Username = info.CurrentUserName;

                string commandText =
                    " INSERT INTO BOOK " +
                    " ( " +
                    "   BOOKID, GENRELIST, ANNOTATION, AUTORLIST, KEYWORDS, BOOKNAME, DATEVALUE, DATEVISIBLE, " +
                    "   LANG, COVERPAGE, SRCLANG, \"SEQUENCE\", SEQNUMBER, SEQUENCEID, DI_PROGUSED, " +
                    "   DI_DATEVALUE, DI_DATEVISIBLE, DI_SRCURL, DI_SRCOCR, OLDID, DI_VERSION, DI_HISTORY, " +
                    "   PI_BOOKNAME, PI_PUBLISHER, PI_CITY, PI_YEAR, PI_ISBN, CUSTOMINFO, DATEIN, " +
                    "   DATEUPDATED, MYID, EXT, FILESIZE, FILENAME, FILEPATH, FILEDATE, USERID, USERNAME " +
                    " ) " +
                    " VALUES " +
                    " ( " +
                    "   GEN_ID(GEN_BOOK_ID,1), @genrelist, @annotation, @autorlist, @keywords, @bookname, @datevalue, " +
                    "   @datevisible, @lang, @coverpage, @srclang, @sequencename, @seqnumber, @sequenceid, " +
                    "   @di_progused, @di_datevalue, @di_datevisible, @di_srcurl, @di_srcocr, @oldid, " +
                    "   @di_version, @di_history, @pi_bookname, @pi_publisher, @pi_city, @pi_year, @pi_isbn, " +
                    "   @custominfo, @datein, @dateupdated, @myid, @ext, @filesize, @filename, @filepath, " +
                    "   @filedate, @userid, @username " +
                    " ) RETURNING BOOKID";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@genrelist", FbDbType.VarChar).Value = book.Genrelist;
                    command.Parameters.Add("@annotation", FbDbType.VarChar).Value = book.Annotation;
                    command.Parameters.Add("@autorlist", FbDbType.VarChar).Value = book.AuthorList;
                    command.Parameters.Add("@keywords", FbDbType.VarChar).Value = book.Keywords;
                    command.Parameters.Add("@bookname", FbDbType.VarChar).Value = book.BookTitle;
                    command.Parameters.Add("@datevalue", FbDbType.Date).Value = book.DateValue;
                    command.Parameters.Add("@datevisible", FbDbType.VarChar).Value = book.DateText;
                    command.Parameters.Add("@lang", FbDbType.VarChar).Value = book.Lang;
                    command.Parameters.Add("@coverpage", FbDbType.Binary).Value = fictionBook.CoverpageImage;
                    command.Parameters.Add("@srclang", FbDbType.VarChar).Value = book.SrcLang;
                    command.Parameters.Add("@sequencename", FbDbType.VarChar).Value = book.Sequence;
                    command.Parameters.Add("@seqnumber", FbDbType.VarChar).Value = book.SequenceNumber;
                    command.Parameters.Add("@sequenceid", FbDbType.Integer).Value = book.SequenceId;
                    command.Parameters.Add("@di_progused", FbDbType.VarChar).Value = book.ProgrammUsed;
                    command.Parameters.Add("@di_datevalue", FbDbType.Date).Value = book.DocumentDateValue;
                    command.Parameters.Add("@di_datevisible", FbDbType.VarChar).Value = book.DocumentDateText;
                    command.Parameters.Add("@di_srcurl", FbDbType.VarChar).Value = book.SrcUrl;
                    command.Parameters.Add("@di_srcocr", FbDbType.VarChar).Value = book.SrcOcr;
                    command.Parameters.Add("@oldid", FbDbType.VarChar).Value = book.Id;
                    command.Parameters.Add("@di_version", FbDbType.VarChar).Value = book.Version;
                    command.Parameters.Add("@di_history", FbDbType.Text).Value = book.History;
                    command.Parameters.Add("@pi_bookname", FbDbType.VarChar).Value = book.BookName;
                    command.Parameters.Add("@pi_publisher", FbDbType.VarChar).Value = book.Publisher;
                    command.Parameters.Add("@pi_city", FbDbType.VarChar).Value = book.City;
                    command.Parameters.Add("@pi_year", FbDbType.VarChar).Value = book.Year;
                    command.Parameters.Add("@pi_isbn", FbDbType.VarChar).Value = book.Isbn;
                    command.Parameters.Add("@custominfo", FbDbType.Text).Value = book.CustomInfo;
                    command.Parameters.Add("@datein", FbDbType.TimeStamp).Value = book.DateInserted;
                    command.Parameters.Add("@dateupdated", FbDbType.TimeStamp).Value = book.DateUpdated;
                    command.Parameters.Add("@myid", FbDbType.VarChar).Value = book.SurrogateId;
                    command.Parameters.Add("@ext", FbDbType.VarChar).Value = book.Extension;
                    command.Parameters.Add("@filesize", FbDbType.Float).Value = book.FileSize;
                    command.Parameters.Add("@filename", FbDbType.VarChar).Value = book.FileName;
                    command.Parameters.Add("@filepath", FbDbType.VarChar).Value = book.FilePath;
                    command.Parameters.Add("@filedate", FbDbType.TimeStamp).Value = book.FileDate;
                    command.Parameters.Add("@userid", FbDbType.Integer).Value = book.Userid;
                    command.Parameters.Add("@username", FbDbType.VarChar).Value = book.Username;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    book.BookId = Convert.ToInt32(command.Parameters["@bookid"].Value);
                }

                commandText = 
                    "INSERT INTO BOOK_AUTOR (ID, BOOKID, AUTORID) VALUES (GEN_ID(GEN_BOOK_AUTOR_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author bookAuthor in bookAuthors)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = bookAuthor.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "INSERT INTO BOOK_DOCAUTOR (ID, BOOKID, DOCAUTORID) VALUES (GEN_ID(GEN_BOOK_DOCAUTOR_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author documentAuthor in documentAuthors)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = documentAuthor.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "INSERT INTO BOOK_TRANSLATE (ID, BOOKID, TRANSLATEID) VALUES (GEN_ID(GEN_BOOK_TRANSLATE_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author translator in bookTranslators)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = translator.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "INSERT INTO BOOK_SEQUENCE (BOOKID, SEQUENCEID) VALUES (@bookid, @sequenceid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@sequenceid", FbDbType.Integer);
                    command.Prepare();

                    foreach (SequenceInfo sequenceInfo in bookSequences)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@sequenceid"].Value = sequenceInfo.SequenceId;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "INSERT INTO BOOK_GENRE (ID, BOOKID, GENREID) VALUES (GEN_ID(GEN_BOOK_GENRE_ID, 1), @bookid, @genreid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@genreid", FbDbType.Char);
                    command.Prepare();

                    foreach (Genre genre in bookGenres)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@genreid"].Value = genre.Name;

                        command.ExecuteNonQuery();
                    }
                }

                return book;
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        private string GetFilename(FictionBook fictionBook)
        {
            string filename = this.provider.GetFileName(fictionBook);
            filename = StringUtils.Dirify(filename, false);

            string separator = Path.DirectorySeparatorChar.ToString();
            while (filename.StartsWith(separator))
            {
                filename = filename.Substring(1);
            }

            filename = StringUtils.Squeeze(filename, Path.DirectorySeparatorChar);

            return filename;
        }

        private DatabaseInfo LoadDatabaseInfo()
        {
            this.manager.BeginConnect();

            try
            {
                string commandText = "SELECT * FROM VERINFO";

                using (SqlDbCommand command = new SqlDbCommand(connection.CreateCommand()))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    return command.ExecuteObject<DatabaseInfo>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        public List<Author> FindSimularAuthors(AuthorInfoNode info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            List<Author> result = new List<Author>();
            List<Author> searchList = this.AuthorList;

            //BKTree<Author> tree = new BKTree<Author>(searchList, null);
            //IList<Author> test = tree.RangeSearch(info, (x, y) => StringUtils.DamerauLevenshteinDistance(x.DisplayName, y.DisplayName), 0, 5);

            foreach (Author author in searchList)
            {
                int firstNameDistance = StringUtils.DamerauLevenshteinDistance(info.FirstName ?? String.Empty, author.FirstName ?? String.Empty);
                int middleNameDistance = StringUtils.DamerauLevenshteinDistance(info.MiddleName ?? String.Empty, author.MiddleName ?? String.Empty);
                int lastNameDistance = StringUtils.DamerauLevenshteinDistance(info.LastName ?? String.Empty, author.LastName ?? String.Empty);

                double sourceMetric = (info.FirstName ?? String.Empty).Length * 0.45 + (info.MiddleName ?? String.Empty).Length * 0.1 + (info.LastName ?? String.Empty).Length * 0.45;
                double distanceMetric = firstNameDistance * 0.45 + middleNameDistance * 0.1 + lastNameDistance * 0.45;

                double metric = (sourceMetric > 0) ? (1 - distanceMetric / sourceMetric) * 100 : 0;

                if (metric >= 70.0)
                {
                    result.Add(author);
                }
            }

            return result;
        }

        public void CheckDatabaseSchema()
        {
            //if (indices.Select("TABLE_NAME = 'AUTOR' AND INDEX_NAME = 'IDX_AUTHOR_FIRSTNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTHOR_FIRSTNAME ON AUTOR COMPUTED BY (UPPERCASE(FIRSTNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR' AND INDEX_NAME = 'IDX_AUTHOR_MIDNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTHOR_MIDNAME ON AUTOR COMPUTED BY (UPPERCASE(MIDNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR' AND INDEX_NAME = 'IDX_AUTHOR_LASTNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTHOR_LASTNAME ON AUTOR COMPUTED BY (UPPERCASE(LASTNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR' AND INDEX_NAME = 'IDX_AUTHOR_NICKNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTHOR_NICKNAME ON AUTOR COMPUTED BY (UPPERCASE(NICKNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR_SYNONIMS' AND INDEX_NAME = 'IDX_AUTOR_SYNONIMS_FIRSTNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTOR_SYNONIMS_FIRSTNAME ON AUTOR_SYNONIMS COMPUTED BY (UPPERCASE(FIRSTNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR_SYNONIMS' AND INDEX_NAME = 'IDX_AUTOR_SYNONIMS_MIDNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTOR_SYNONIMS_MIDNAME ON AUTOR_SYNONIMS COMPUTED BY (UPPERCASE(MIDNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR_SYNONIMS' AND INDEX_NAME = 'IDX_AUTOR_SYNONIMS_LASTNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTOR_SYNONIMS_LASTNAME ON AUTOR_SYNONIMS COMPUTED BY (UPPERCASE(LASTNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            //if (indices.Select("TABLE_NAME = 'AUTOR_SYNONIMS' AND INDEX_NAME = 'IDX_AUTOR_SYNONIMS_NICKNAME'").Length == 0)
            //{
            //    FbCommand command = this.connection.CreateCommand();
            //    command.CommandText = "CREATE INDEX IDX_AUTOR_SYNONIMS_NICKNAME ON AUTOR_SYNONIMS COMPUTED BY (UPPERCASE(NICKNAME))";
            //    command.CommandType = CommandType.Text;

            //    command.ExecuteNonQuery();
            //}

            this.manager.BeginConnect();

            try
            {
                //DataTable indices = connection.GetSchema("Indexes");
                DataTable tables = connection.GetSchema("Tables");
                DataTable indexColumns = connection.GetSchema("IndexColumns");

                if (tables.Select("TABLE_NAME = 'AUTHOR_INFO' AND TABLE_TYPE = 'TABLE'").Length == 0)
                {
                    using (FbCommand command = this.connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"CREATE TABLE AUTHOR_INFO
                        (
                            AUTORID INTEGER NOT NULL,
                            ID VARCHAR(254),
                            CONSTRAINT PK_AUTHOR_INFO PRIMARY KEY (AUTORID),
                            CONSTRAINT FK_AUTHOR_INFO_AUTORID FOREIGN KEY (AUTORID) REFERENCES AUTOR(AUTORID) ON DELETE CASCADE
                        )";

                        command.ExecuteNonQuery();
                    }
                }

                DataTable fk = connection.GetSchema("ForeignKeys");

                if (fk.Select("TABLE_NAME = 'AUTHOR_INFO' AND CONSTRAINT_NAME = 'FK_AUTHOR_INFO_AUTORID' AND DELETE_RULE = 'CASCADE'").Length == 0)
                {
                    FbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = @"ALTER TABLE AUTHOR_INFO DROP CONSTRAINT FK_AUTHOR_INFO_AUTORID";
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();
                        }

                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = @"ALTER TABLE AUTHOR_INFO ADD CONSTRAINT FK_AUTHOR_INFO_AUTORID FOREIGN KEY (AUTORID) REFERENCES AUTOR(AUTORID) ON DELETE CASCADE";
                            command.Transaction = transaction;

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                bool found = false;
                foreach (DataRow dataRow in indexColumns.Select("TABLE_NAME = 'BOOK' AND COLUMN_NAME = 'OLDID'"))
                {
                    if (indexColumns.Select(String.Format("TABLE_NAME = 'BOOK' AND CONSTRAINT_NAME = '{0}'", dataRow["CONSTRAINT_NAME"])).Length == 1)
                    {
                        found = true;
                        break;
                    }
                }

                if(!found)
                {
                    try
                    {
                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = @"CREATE INDEX IDX_GREMLIN_BOOK_OLDID ON BOOK(OLDID)";

                            command.ExecuteNonQuery();
                        }
                    }
                    catch (FbException)
                    {
                    }
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        private List<Author> LoadAuthorList()
        {
            this.manager.BeginConnect();

            try 
            {
                string commandText =
                    @"SELECT autor.autorid, autor.lastname, autor.firstname, autor.midname, autor.nickname, author_info.id as library_id
                      FROM autor
                      LEFT JOIN author_info ON autor.autorid = author_info.autorid
                      UNION ALL
                      SELECT autor_synonims.autorid, autor_synonims.lastname, autor_synonims.firstname, autor_synonims.midname, autor_synonims.nickname, author_info.id as library_id
                      FROM autor_synonims
                      LEFT JOIN author_info ON autor_synonims.autorid = author_info.autorid";

                using (SqlDbCommand command = new SqlDbCommand(connection.CreateCommand()))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    return command.ExecuteList<Author>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        private List<AuthorSynonym> LoadAuthorSynonyms()
        {
            this.manager.BeginConnect();

            try
            {
                string commandText = @"SELECT autor_synonims.* FROM autor_synonims";

                using (SqlDbCommand command = new SqlDbCommand(connection.CreateCommand()))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    return command.ExecuteList<AuthorSynonym>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }

        }

        public List<GenreInfo> LoadGenreList()
        {
            this.manager.BeginConnect();

            try
            {
                string commandText = "SELECT * FROM GENRE";

                Dictionary<string, GenreInfo> genreTable;
                List<GenreInfo> result;

                using (SqlDbCommand command = new SqlDbCommand(connection.CreateCommand()))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    result = command.ExecuteList<GenreInfo>();

                    foreach (GenreInfo genreInfo in result)
                    {
                        genreInfo.Name = (genreInfo.Name != null) ? genreInfo.Name.Trim() : null;
                    }

                    genreTable = new Dictionary<string, GenreInfo>(result.Count);
                    foreach (GenreInfo genreInfo in result)
                    {
                        try
                        {
                            genreTable.Add(genreInfo.Name, genreInfo);
                        }
                        catch (ArgumentException)
                        {
                        }
                    }
                }

                commandText = "SELECT * FROM GENREALT";

                using (SqlDbCommand command = new SqlDbCommand(connection.CreateCommand()))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;

                    List<GenreMapInfo> genreMap = command.ExecuteList<GenreMapInfo>();
                    foreach (GenreMapInfo genreMapInfo in genreMap)
                    {
                        genreMapInfo.GenreName = (genreMapInfo.GenreName != null) ? genreMapInfo.GenreName.Trim() : null;
                        genreMapInfo.GenreAltName = (genreMapInfo.GenreAltName != null) ? genreMapInfo.GenreAltName.Trim() : null;
                    }

                    foreach (GenreMapInfo genreMapInfo in genreMap)
                    {
                        if (genreTable.ContainsKey(genreMapInfo.GenreName))
                        {
                            genreTable[genreMapInfo.GenreName].GenreMap.Add(genreMapInfo);
                        }
                    }

                    return result;
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        public Author FindOrCreateAuthor(AuthorInfoNode info, IDbTransaction transaction)
        {
            string commandText;
            FbCommand command;
            Author author;

            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.manager.BeginConnect();

            try
            {
                commandText = 
                        @"SELECT autor.* FROM autor 
                          INNER JOIN autor_synonims ON autor_synonims.autorid = autor.autorid 
                          WHERE UPPERCASE(autor_synonims.lastname) = UPPERCASE(@lastname) AND 
                                UPPERCASE(autor_synonims.firstname) = UPPERCASE(@firstname) AND 
                                UPPERCASE(autor_synonims.midname) = UPPERCASE(@midname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT autor.* FROM autor 
                      INNER JOIN autor_synonims ON autor_synonims.autorid = autor.autorid 
                      WHERE UPPERCASE(autor_synonims.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(autor_synonims.firstname) = UPPERCASE(@firstname) AND 
                            ((autor_synonims.midname = '' AND CAST(@midname AS VARCHAR(40)) <> '') OR (autor_synonims.midname <> '' AND CAST(@midname AS VARCHAR(40)) = ''))";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = info.MiddleName ?? String.Empty;
                command.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT * FROM autor 
                      WHERE UPPERCASE(autor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(autor.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(autor.midname) = UPPERCASE(@midname) AND
                            UPPERCASE(autor.nickname) = UPPERCASE(@nickname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;
                command.Parameters.Add("@nickname", FbDbType.VarChar).Value = info.NickName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT * FROM autor 
                      WHERE UPPERCASE(autor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(autor.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(autor.midname) = UPPERCASE(@midname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT autor.* FROM autor 
                      WHERE UPPERCASE(autor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(autor.firstname) = UPPERCASE(@firstname) AND 
                            ((autor.midname = '' AND CAST(@midname AS VARCHAR(40)) <> '') OR (autor.midname <> '' AND CAST(@midname AS VARCHAR(40)) = ''))";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = info.MiddleName ?? String.Empty;
                command.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                if (String.IsNullOrEmpty(info.FirstName) && String.IsNullOrEmpty(info.LastName) && !String.IsNullOrEmpty(info.NickName))
                {
                    commandText =
                        @"SELECT autor.* FROM autor WHERE UPPERCASE(autor.nickname) = UPPERCASE(@nickname)";

                    command = this.connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = info.NickName;

                    using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                    {
                        author = dbCommand.ExecuteObject<Author>();
                    }

                    if (author != null)
                    {
                        return author;
                    }
                }

                author = new Author();

                author.FirstName = info.FirstName;
                author.MiddleName = info.MiddleName;
                author.LastName = info.LastName;
                author.NickName = info.NickName;
                author.LibraryId = info.Id;
                author.EMail = StringUtils.Truncate(StringUtils.Join(", ", info.Email), 125);
                author.Homepage = StringUtils.Truncate(StringUtils.Join(", ", info.Homepage), 125);

                commandText =
                    "INSERT INTO AUTOR (AUTORID, FIRSTNAME, MIDNAME, LASTNAME, NICKNAME, EMAIL, HOMEPAGE) " +
                    "VALUES (GEN_ID(GEN_AUTOR_ID, 1), @firstname, @midname, @lastname, @nickname, @email, @homepage) " +
                    "RETURNING AUTORID";

                using (FbCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    cmd.Transaction = transaction as FbTransaction;

                    cmd.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = author.FirstName ?? String.Empty;
                    cmd.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = author.MiddleName ?? String.Empty;
                    cmd.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = author.LastName ?? String.Empty;
                    cmd.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = author.NickName ?? String.Empty;
                    cmd.Parameters.Add("@email", FbDbType.VarChar, 125).Value = author.EMail;
                    cmd.Parameters.Add("@homepage", FbDbType.VarChar, 125).Value = author.Homepage;

                    cmd.Parameters.Add("@authorid", FbDbType.Integer).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    author.Id = Convert.ToInt32(cmd.Parameters["@authorid"].Value);
                }

                if (!String.IsNullOrEmpty(author.LibraryId))
                {
                    commandText =
                        "INSERT INTO AUTHOR_INFO (AUTORID, ID) VALUES (@autorid, @id)";

                    using (FbCommand cmd = this.connection.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = commandText;
                        cmd.Transaction = transaction as FbTransaction;

                        cmd.Parameters.Add("@autorid", FbDbType.Integer).Value = author.Id;
                        cmd.Parameters.Add("@id", FbDbType.VarChar, 254).Value = author.LibraryId;

                        cmd.ExecuteNonQuery();
                    }
                }

                List<Author> authors = AuthorList;
                authors.Add(author);
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }

            return author;
        }

        public Author FindOrCreateAuthor(AuthorInfoNode info)
        {
            return FindOrCreateAuthor(info, null);
        }

        public Author FindOrCreateDocumentAuthor(AuthorInfoNode info, IDbTransaction transaction)
        {
            string commandText;
            FbCommand command;
            Author author;

            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.manager.BeginConnect();

            try
            {
                commandText = 
                    @"SELECT docauthor.docautorid as autorid, docauthor.* FROM docauthor 
                      WHERE UPPERCASE(docauthor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(docauthor.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(docauthor.midname) = UPPERCASE(@midname) AND
                            UPPERCASE(docauthor.nickname) = UPPERCASE(@nickname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;
                command.Parameters.Add("@nickname", FbDbType.VarChar).Value = info.NickName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText = 
                    @"SELECT docauthor.docautorid as autorid, docauthor.* FROM docauthor
                      WHERE UPPERCASE(docauthor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(docauthor.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(docauthor.midname) = UPPERCASE(@midname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText = 
                    @"SELECT docauthor.docautorid as autorid, docauthor.* FROM docauthor 
                      WHERE UPPERCASE(docauthor.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(docauthor.firstname) = UPPERCASE(@firstname) AND 
                            ((docauthor.midname = '' AND CAST(@midname AS VARCHAR(40)) <> '') OR (docauthor.midname <> '' AND CAST(@midname AS VARCHAR(40)) = ''))";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = info.MiddleName ?? String.Empty;
                command.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                if (String.IsNullOrEmpty(info.FirstName) && String.IsNullOrEmpty(info.LastName) && !String.IsNullOrEmpty(info.NickName))
                {
                    commandText = @"SELECT docauthor.docautorid as autorid, docauthor.* FROM docauthor WHERE UPPERCASE(docauthor.nickname) = UPPERCASE(@nickname)";

                    command = this.connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = info.NickName;

                    using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                    {
                        author = dbCommand.ExecuteObject<Author>();
                    }

                    if (author != null)
                    {
                        return author;
                    }
                }

                author = new Author();

                author.FirstName = info.FirstName;
                author.MiddleName = info.MiddleName;
                author.LastName = info.LastName;
                author.NickName = info.NickName;
                author.LibraryId = info.Id;
                author.EMail = StringUtils.Truncate(StringUtils.Join(", ", info.Email), 125);
                author.Homepage = StringUtils.Truncate(StringUtils.Join(", ", info.Homepage), 125);

                commandText = "INSERT INTO DOCAUTHOR (DOCAUTORID, FIRSTNAME, MIDNAME, LASTNAME, NICKNAME, EMAIL, HOMEPAGE) " + "VALUES (GEN_ID(GEN_DOCAUTHOR_ID, 1), @firstname, @midname, @lastname, @nickname, @email, @homepage) " + "RETURNING DOCAUTORID";

                using (FbCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    cmd.Transaction = transaction as FbTransaction;

                    cmd.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = author.FirstName ?? String.Empty;
                    cmd.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = author.MiddleName ?? String.Empty;
                    cmd.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = author.LastName ?? String.Empty;
                    cmd.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = author.NickName ?? String.Empty;
                    cmd.Parameters.Add("@email", FbDbType.VarChar, 125).Value = author.EMail;
                    cmd.Parameters.Add("@homepage", FbDbType.VarChar, 125).Value = author.Homepage;

                    cmd.Parameters.Add("@authorid", FbDbType.Integer).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    author.Id = Convert.ToInt32(cmd.Parameters["@authorid"].Value);
                }

            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }

            return author;
        }

        public Author FindOrCreateDocumentAuthor(AuthorInfoNode info)
        {
            return FindOrCreateDocumentAuthor(info, null);
        }

        public Author FindOrCreateTranslator(AuthorInfoNode info, IDbTransaction transaction)
        {
            string commandText;
            FbCommand command;
            Author author;

            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.manager.BeginConnect();

            try 
            {
                commandText =
                    @"SELECT translate.translateid as autorid, translate.* FROM translate 
                      WHERE UPPERCASE(translate.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(translate.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(translate.midname) = UPPERCASE(@midname) AND
                            UPPERCASE(translate.nickname) = UPPERCASE(@nickname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;
                command.Parameters.Add("@nickname", FbDbType.VarChar).Value = info.NickName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT translate.translateid as autorid, translate.* FROM translate
                      WHERE UPPERCASE(translate.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(translate.firstname) = UPPERCASE(@firstname) AND 
                            UPPERCASE(translate.midname) = UPPERCASE(@midname)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar).Value = info.MiddleName;
                command.Parameters.Add("@lastname", FbDbType.VarChar).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                commandText =
                    @"SELECT translate.translateid as autorid, translate.* FROM translate 
                      WHERE UPPERCASE(translate.lastname) = UPPERCASE(@lastname) AND 
                            UPPERCASE(translate.firstname) = UPPERCASE(@firstname) AND 
                            ((translate.midname = '' AND CAST(@midname AS VARCHAR(40)) <> '') OR (translate.midname <> '' AND CAST(@midname AS VARCHAR(40)) = ''))";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = info.FirstName;
                command.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = info.MiddleName ?? String.Empty;
                command.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = info.LastName;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    author = dbCommand.ExecuteObject<Author>();
                }

                if (author != null)
                {
                    return author;
                }

                if (String.IsNullOrEmpty(info.FirstName) && String.IsNullOrEmpty(info.LastName) && !String.IsNullOrEmpty(info.NickName))
                {
                    commandText =
                        @"SELECT translate.translateid as autorid, translate.* FROM translate WHERE UPPERCASE(translate.nickname) = UPPERCASE(@nickname)";

                    command = this.connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = info.NickName;

                    using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                    {
                        author = dbCommand.ExecuteObject<Author>();
                    }

                    if (author != null)
                    {
                        return author;
                    }
                }

                author = new Author();

                author.FirstName = info.FirstName;
                author.MiddleName = info.MiddleName;
                author.LastName = info.LastName;
                author.NickName = info.NickName;
                author.LibraryId = info.Id;
                author.EMail = StringUtils.Truncate(StringUtils.Join(", ", info.Email), 125);
                author.Homepage = StringUtils.Truncate(StringUtils.Join(", ", info.Homepage), 125);

                commandText =
                    "INSERT INTO TRANSLATE (TRANSLATEID, FIRSTNAME, MIDNAME, LASTNAME, NICKNAME, EMAIL, HOMEPAGE) " +
                    "VALUES (GEN_ID(GEN_TRANSLATE_ID, 1), @firstname, @midname, @lastname, @nickname, @email, @homepage) " +
                    "RETURNING TRANSLATEID";

                using (FbCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    cmd.Transaction = transaction as FbTransaction;

                    cmd.Parameters.Add("@firstname", FbDbType.VarChar, 40).Value = author.FirstName ?? String.Empty;
                    cmd.Parameters.Add("@midname", FbDbType.VarChar, 40).Value = author.MiddleName ?? String.Empty;
                    cmd.Parameters.Add("@lastname", FbDbType.VarChar, 40).Value = author.LastName ?? String.Empty;
                    cmd.Parameters.Add("@nickname", FbDbType.VarChar, 40).Value = author.NickName ?? String.Empty;
                    cmd.Parameters.Add("@email", FbDbType.VarChar, 125).Value = author.EMail;
                    cmd.Parameters.Add("@homepage", FbDbType.VarChar, 125).Value = author.Homepage;

                    cmd.Parameters.Add("@authorid", FbDbType.Integer).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    author.Id = Convert.ToInt32(cmd.Parameters["@authorid"].Value);
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }

            return author;
        }

        public Author FindOrCreateTranslator(AuthorInfoNode info)
        {
            return FindOrCreateTranslator(info, null);
        }

        public SequenceInfo FindOrCreateBookSequence(SequenceInfoNode info, IDbTransaction transaction)
        {
            string commandText;
            FbCommand command;
            SequenceInfo sequence;

            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            this.manager.BeginConnect();

            try
            {
                commandText =
                    @"SELECT sequences.* FROM sequences 
                      WHERE UPPERCASE(sequences.""SEQUENCE"") = UPPERCASE(@sequencename)";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                command.Transaction = transaction as FbTransaction;

                command.Parameters.Add("@sequencename", FbDbType.VarChar).Value = info.Name;


                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    sequence = dbCommand.ExecuteObject<SequenceInfo>();
                }

                if (sequence != null)
                {
                    sequence.SequenceNumber = info.Number;
                    return sequence;
                }

                sequence = new SequenceInfo();
                sequence.SequenceName = StringUtils.Truncate(info.Name, 125);

                commandText =
                    "INSERT INTO SEQUENCES (SEQUENCEID, \"SEQUENCE\") " +
                    "VALUES (GEN_ID(GEN_SEQUENCES_ID, 1), @sequencename) " +
                    "RETURNING SEQUENCEID";

                using (FbCommand cmd = this.connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    cmd.Transaction = transaction as FbTransaction;

                    cmd.Parameters.Add("@sequencename", FbDbType.VarChar, 125).Value = sequence.SequenceName ?? String.Empty;

                    cmd.Parameters.Add("@sequenceid", FbDbType.Integer).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    sequence.SequenceId = Convert.ToInt32(cmd.Parameters["@sequenceid"].Value);
                }

                sequence.SequenceNumber = info.Number;
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }

            return sequence;
        }

        public SequenceInfo FindOrCreateBookSequence(SequenceInfoNode info)
        {
            return FindOrCreateBookSequence(info, null);
        }

        public List<BookInfo> LoadBookInfoByAuthorIdList(IEnumerable<int> list)
        {
            string commandText;
            FbCommand command;

            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            this.manager.BeginConnect();

            try
            {
                string idsList = StringUtils.Join(", ", list);
                if (String.IsNullOrEmpty(idsList))
                {
                    return new List<BookInfo>();
                }

                commandText =
                    @"SELECT BOOK.BOOKID, BOOKNAME, ""SEQUENCE"", SEQNUMBER, OLDID, DI_VERSION, FILENAME, FILEDATE, DATEIN
                      FROM BOOK
                      INNER JOIN BOOK_AUTOR ON BOOK_AUTOR.BOOKID = BOOK.BOOKID
                      WHERE BOOK_AUTOR.AUTORID IN (" + idsList + ")";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    return dbCommand.ExecuteList<BookInfo>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        public List<BookInfo> LoadBookInfoByDocumentId(string documentId)
        {
            string commandText;
            FbCommand command;

            if (String.IsNullOrEmpty(documentId))
            {
                throw new ArgumentException("documentId");
            }

            this.manager.BeginConnect();

            try
            {
                commandText =
                    @"SELECT BOOKID, BOOKNAME, ""SEQUENCE"", SEQNUMBER, OLDID, DI_VERSION, FILENAME, FILEDATE, DATEIN
                      FROM BOOK
                      WHERE OLDID = @documentid";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;

                command.Parameters.Add("@documentid", FbDbType.VarChar, 254).Value = documentId;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    return dbCommand.ExecuteList<BookInfo>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }

        public BookInfo LoadBookInfoByBookId(int bookId)
        {
            string commandText;
            FbCommand command;

            this.manager.BeginConnect();

            try
            {
                commandText =
                    @"SELECT BOOKID, AUTORLIST, GENRELIST, BOOKNAME, ""SEQUENCE"", SEQNUMBER, OLDID, DI_VERSION, FILENAME, FILEDATE, FILESIZE, DATEIN
                      FROM BOOK
                      WHERE BOOKID = @bookid";

                command = this.connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;

                command.Parameters.Add("@bookid", FbDbType.Integer).Value = bookId;

                using (SqlDbCommand dbCommand = new SqlDbCommand(command))
                {
                    return dbCommand.ExecuteObject<BookInfo>();
                }
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }


        private FileNameProvider NamingProvider
        {
            get
            {
                if (this.provider == null)
                {
                    lock (this.dataAccessLock)
                    {
                        if (this.provider == null)
                        {
                            this.provider = new FileNameProvider(this.DatabaseInfo.NamingPattern);
                        }
                    }
                }

                return this.provider;
            }
        }

        public BookInfo UpdateFictionBook(BookInfo bookInfo, FictionBook fictionBook, Stream content, Fb2DocumentEntry documentEntry)
        {
            this.manager.BeginConnect();

            try
            {
                FbTransaction transaction = this.connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                try
                {
                    DatabaseInfo info = this.DatabaseInfo;
                    FileNameProvider provider = this.NamingProvider;

                    BookInfo book = UpdateFictionBook(bookInfo, fictionBook, content, documentEntry, transaction);

                    if (info.WorkMode == (short)StorageMode.FileSystem)
                    {
                        if(!String.IsNullOrEmpty(book.FileName))
                        {
                            string filename = Path.Combine(info.MountPoint, book.FileName);
                            if (File.Exists(filename))
                            {
                                File.Delete(filename);
                            }
                        }

                        string bookFilename = GetFilename(fictionBook) + ".fb2";
                        string outputFullPath = Path.Combine(info.MountPoint, bookFilename);
                        string outputDirectory = Path.GetDirectoryName(outputFullPath).Trim();

                        string outputFilename = Path.GetFileNameWithoutExtension(outputFullPath).Trim();
                        outputFilename = FileUtils.GetOutputFileName(outputDirectory, outputFilename, ".fb2.zip");

                        if (!Directory.Exists(outputDirectory))
                        {
                            Directory.CreateDirectory(outputDirectory);
                        }

                        //using (ZipFile file = ZipFile.Create(outputFilename))
                        //{
                        //    file.UseZip64 = UseZip64.Off;

                        //    file.BeginUpdate();
                        //    file.Add(new StreamDataSource(content), Path.GetFileName(bookFilename));
                        //    file.CommitUpdate();
                        //}

                        IOutArchive archive = this.format.CreateOutArchive(SevenZipFormat.GetClassIdFromKnownFormat(KnownSevenZipFormat.Zip));

                        try
                        {
                            using (FileStream stream = File.Open(outputFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                            {
                                OutStreamWrapper archiveStream = new OutStreamWrapper(stream);
                                archive.UpdateItems(archiveStream, 1, new UpdateBookCallback(content, Path.GetFileName(bookFilename), documentEntry));
                            }
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(archive);
                        }

                        string commandText =
                            " UPDATE BOOK " +
                            "   SET FILENAME = @filename " +
                            "   WHERE BOOKID = @bookid ";

                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = commandText;
                            command.Transaction = transaction;

                            command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                            command.Parameters.Add("@filename", FbDbType.VarChar).Value = FileUtils.SplitFilePath(info.MountPoint, outputFilename);

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (info.WorkMode == (short)StorageMode.Database)
                    {
                        string bookFilename = GetFilename(fictionBook) + ".fb2";

                        using (MemoryStream stream = new MemoryStream())
                        {
                            //using (ZipFile file = ZipFile.Create(stream))
                            //{
                            //    file.UseZip64 = UseZip64.Off;

                            //    file.BeginUpdate();
                            //    file.Add(new StreamDataSource(content), Path.GetFileName(bookFilename));
                            //    file.CommitUpdate();
                            //}

                            IOutArchive archive = this.format.CreateOutArchive(SevenZipFormat.GetClassIdFromKnownFormat(KnownSevenZipFormat.Zip));

                            try
                            {
                                OutStreamWrapper archiveStream = new OutStreamWrapper(stream);
                                archive.UpdateItems(archiveStream, 1, new UpdateBookCallback(content, bookFilename, documentEntry));
                            }
                            finally
                            {
                                Marshal.ReleaseComObject(archive);
                            }

                            stream.Capacity = (int)stream.Length;

                            string commandText =
                                " UPDATE BOOK " +
                                "   SET FILENAME = @filename, TEXT = @text " +
                                "   WHERE BOOKID = @bookid ";

                            using (FbCommand command = this.connection.CreateCommand())
                            {
                                command.CommandType = CommandType.Text;
                                command.CommandText = commandText;
                                command.Transaction = transaction;

                                command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                                command.Parameters.Add("@text", FbDbType.Binary).Value = stream.GetBuffer();
                                command.Parameters.Add("@filename", FbDbType.VarChar).Value = bookFilename + ".zip";

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (info.WorkMode == (short)StorageMode.IndexOnly)
                    {
                        string commandText =
                            " UPDATE BOOK " +
                            "   SET FILENAME = @filename " +
                            "   WHERE BOOKID = @bookid ";

                        using (FbCommand command = this.connection.CreateCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = commandText;
                            command.Transaction = transaction;

                            command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                            command.Parameters.Add("@filename", FbDbType.VarChar).Value = documentEntry.Filename;

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return book;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            finally
            {
                this.manager.EndConnect();
            }
        }


        public BookInfo UpdateFictionBook(BookInfo bookInfo, FictionBook fictionBook, Stream content, Fb2DocumentEntry documentEntry, IDbTransaction transaction)
        {
            if (bookInfo == null)
            {
                throw new ArgumentNullException("bookInfo");
            }

            if (fictionBook == null)
            {
                throw new ArgumentNullException("fictionBook");
            }

            this.manager.BeginConnect();

            try
            {
                DatabaseInfo info = this.DatabaseInfo;

                FileNameProvider provider = NamingProvider;

                List<Author> bookAuthors = new List<Author>(fictionBook.TitleInfo.Authors.Count);
                List<Author> documentAuthors = new List<Author>(fictionBook.DocumentInfo.Authors.Count);
                List<Author> bookTranslators = new List<Author>(fictionBook.TitleInfo.Translators.Count);
                List<SequenceInfo> bookSequences = new List<SequenceInfo>(fictionBook.TitleInfo.Sequences.Count);
                List<Genre> bookGenres = new List<Genre>(fictionBook.TitleInfo.Genres.Count);

                foreach (AuthorInfoNode authorInfoNode in fictionBook.TitleInfo.Authors)
                {
                    Author author = this.FindOrCreateAuthor(authorInfoNode, transaction);
                    if (author != null)
                    {
                        bookAuthors.Add(author);
                    }
                }

                foreach (AuthorInfoNode authorInfoNode in fictionBook.DocumentInfo.Authors)
                {
                    Author author = this.FindOrCreateDocumentAuthor(authorInfoNode, transaction);
                    if (author != null)
                    {
                        documentAuthors.Add(author);
                    }
                }

                foreach (AuthorInfoNode authorInfoNode in fictionBook.TitleInfo.Translators)
                {
                    Author translator = this.FindOrCreateTranslator(authorInfoNode, transaction);
                    if (translator != null)
                    {
                        bookTranslators.Add(translator);
                    }
                }

                foreach (SequenceInfoNode sequenceInfoNode in fictionBook.TitleInfo.Sequences)
                {
                    SequenceInfo sequence = this.FindOrCreateBookSequence(sequenceInfoNode, transaction);
                    if (sequence != null)
                    {
                        bookSequences.Add(sequence);
                    }
                }

                Set<Genre> genres = new Set<Genre>(fictionBook.TitleInfo.Genres.Count);
                foreach (GenreInfoNode genreInfoNode in fictionBook.TitleInfo.Genres)
                {
                    string genreName = genreInfoNode.Genre;
                    if (GenreTable.Table.MapTable.ContainsKey(genreName))
                    {
                        genreName = GenreTable.Table.MapTable[genreName];
                    }

                    Genre bookGenre = GenreTable.Table[genreName];
                    if (bookGenre != null)
                    {
                        genres.Add(bookGenre);
                    }
                }

                bookGenres.AddRange(genres);

                BookInfo book = new BookInfo();
                book.BookId = bookInfo.BookId;
                book.Genrelist = StringUtils.Truncate(StringUtils.Join(", ", bookGenres), 1024);

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "annotation");
                    xslt.Transform(fictionBook.Document, arguments, writer);
                    book.Annotation = StringUtils.Truncate(writer.ToString(), 4096);
                }

                book.AuthorList = StringUtils.Truncate(StringUtils.Join("; ", bookAuthors), 254);
                book.Keywords = StringUtils.Truncate(fictionBook.TitleInfo.Keywords, 254);
                book.BookTitle = StringUtils.Truncate(fictionBook.TitleInfo.BookTitle, 252);
                
                if (fictionBook.TitleInfo.DateNode != null)
                {
                    book.DateValue = fictionBook.TitleInfo.DateNode.Value;
                    book.DateText = StringUtils.Truncate(fictionBook.TitleInfo.DateNode.DateString, 25);
                }

                book.Lang = StringUtils.Truncate(fictionBook.TitleInfo.Lang, 10);
                book.SrcLang = StringUtils.Truncate(fictionBook.TitleInfo.SourceLang, 10);

                foreach (SequenceInfo sequenceInfo in bookSequences)
                {
                    book.SequenceId = sequenceInfo.SequenceId;
                    book.Sequence = StringUtils.Truncate(sequenceInfo.SequenceName, 125);
                    if (sequenceInfo.SequenceNumber != null)
                    {
                        book.SequenceNumber = sequenceInfo.SequenceNumber.Value.ToString("000", CultureInfo.InvariantCulture);
                    }

                    break;
                }

                book.ProgrammUsed = StringUtils.Truncate(fictionBook.DocumentInfo.ProgramUsed ?? String.Empty, 254);

                if (fictionBook.DocumentInfo.DateNode != null)
                {
                    book.DocumentDateValue = fictionBook.DocumentInfo.DateNode.Value;
                    book.DocumentDateText = StringUtils.Truncate(fictionBook.DocumentInfo.DateNode.DateString ?? String.Empty, 14);
                }
                else
                {
                    book.DocumentDateValue = null;
                    book.DocumentDateText = String.Empty;
                }

                book.SrcUrl = StringUtils.Truncate(StringUtils.Join(", ", fictionBook.DocumentInfo.SourceUrl), 254);
                book.SrcOcr = StringUtils.Truncate(fictionBook.DocumentInfo.SourceOCR ?? String.Empty, 254);
                book.Id = StringUtils.Truncate(fictionBook.DocumentInfo.Id, 254);
                book.Version = DocumentInfoNode.FormatVersion(fictionBook.DocumentInfo.Version ?? 0.0f);

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "history");
                    xslt.Transform(fictionBook.Document, arguments, writer);
                    book.History = writer.ToString();
                }

                if (fictionBook.PublishInfo != null)
                {
                    book.BookName = StringUtils.Truncate(fictionBook.PublishInfo.BookName ?? String.Empty, 254);
                    book.Publisher = StringUtils.Truncate(fictionBook.PublishInfo.Publisher ?? String.Empty, 254);
                    book.City = StringUtils.Truncate(fictionBook.PublishInfo.City ?? String.Empty, 50);

                    if (fictionBook.PublishInfo.Year != null)
                    {
                        book.Year = StringUtils.Truncate(fictionBook.PublishInfo.Year.ToString(), 10);
                    }
                    else
                    {
                        book.Year = String.Empty;
                    }

                    book.Isbn = StringUtils.Truncate(fictionBook.PublishInfo.ISBN ?? String.Empty, 125);
                }
                else
                {
                    book.BookName = String.Empty;
                    book.Publisher = String.Empty;
                    book.City = String.Empty;
                    book.Year = String.Empty;
                    book.Isbn = String.Empty;
                }

                using (StringWriter writer = new StringWriter())
                {
                    XsltArgumentList arguments = new XsltArgumentList();
                    arguments.AddParam("nodeType", "", "custom-info");
                    xslt.Transform(fictionBook.Document, arguments, writer);
                    book.CustomInfo = writer.ToString();
                }

                book.DateUpdated = DateTime.Now;
                book.Extension = "FB2";

                book.FileSize = documentEntry.FileSize;

                book.SurrogateId = Regex.Replace(String.Concat(book.BookTitle, book.AuthorList), @"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}]", "").Trim().ToUpperInvariant();

                book.Userid = info.CurrentUserId;
                book.Username = info.CurrentUserName;

                string commandText =
                    " UPDATE BOOK " +
                    "   SET GENRELIST = @genrelist, ANNOTATION = @annotation, AUTORLIST = @autorlist, KEYWORDS = @keywords, BOOKNAME = @bookname, DATEVALUE = @datevalue, DATEVISIBLE = @datevisible, " +
                    "   LANG = @lang, COVERPAGE = @coverpage, SRCLANG = @srclang, \"SEQUENCE\" = @sequencename, SEQNUMBER = @seqnumber, SEQUENCEID = @sequenceid, DI_PROGUSED = @di_progused, " +
                    "   DI_DATEVALUE = @di_datevalue, DI_DATEVISIBLE = @di_datevisible, DI_SRCURL = @di_srcurl, DI_SRCOCR = @di_srcocr, OLDID = @oldid, DI_VERSION = @di_version, DI_HISTORY = @di_history, " +
                    "   PI_BOOKNAME = @pi_bookname, PI_PUBLISHER = @pi_publisher, PI_CITY = @pi_city, PI_YEAR = @pi_year, PI_ISBN = @pi_isbn, CUSTOMINFO = @custominfo, " +
                    "   DATEUPDATED = @dateupdated, MYID = @myid, EXT = @ext, FILESIZE = @filesize, USERID = @userid, USERNAME = @username " +
                    "   WHERE BOOKID = @bookid ";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;
                    command.Parameters.Add("@genrelist", FbDbType.VarChar).Value = book.Genrelist;
                    command.Parameters.Add("@annotation", FbDbType.VarChar).Value = book.Annotation;
                    command.Parameters.Add("@autorlist", FbDbType.VarChar).Value = book.AuthorList;
                    command.Parameters.Add("@keywords", FbDbType.VarChar).Value = book.Keywords;
                    command.Parameters.Add("@bookname", FbDbType.VarChar).Value = book.BookTitle;
                    command.Parameters.Add("@datevalue", FbDbType.Date).Value = book.DateValue;
                    command.Parameters.Add("@datevisible", FbDbType.VarChar).Value = book.DateText;
                    command.Parameters.Add("@lang", FbDbType.VarChar).Value = book.Lang;
                    command.Parameters.Add("@coverpage", FbDbType.Binary).Value = fictionBook.CoverpageImage;
                    command.Parameters.Add("@srclang", FbDbType.VarChar).Value = book.SrcLang;
                    command.Parameters.Add("@sequencename", FbDbType.VarChar).Value = book.Sequence;
                    command.Parameters.Add("@seqnumber", FbDbType.VarChar).Value = book.SequenceNumber;
                    command.Parameters.Add("@sequenceid", FbDbType.Integer).Value = book.SequenceId;
                    command.Parameters.Add("@di_progused", FbDbType.VarChar).Value = book.ProgrammUsed;
                    command.Parameters.Add("@di_datevalue", FbDbType.Date).Value = book.DocumentDateValue;
                    command.Parameters.Add("@di_datevisible", FbDbType.VarChar).Value = book.DocumentDateText;
                    command.Parameters.Add("@di_srcurl", FbDbType.VarChar).Value = book.SrcUrl;
                    command.Parameters.Add("@di_srcocr", FbDbType.VarChar).Value = book.SrcOcr;
                    command.Parameters.Add("@oldid", FbDbType.VarChar).Value = book.Id;
                    command.Parameters.Add("@di_version", FbDbType.VarChar).Value = book.Version;
                    command.Parameters.Add("@di_history", FbDbType.Text).Value = book.History;
                    command.Parameters.Add("@pi_bookname", FbDbType.VarChar).Value = book.BookName;
                    command.Parameters.Add("@pi_publisher", FbDbType.VarChar).Value = book.Publisher;
                    command.Parameters.Add("@pi_city", FbDbType.VarChar).Value = book.City;
                    command.Parameters.Add("@pi_year", FbDbType.VarChar).Value = book.Year;
                    command.Parameters.Add("@pi_isbn", FbDbType.VarChar).Value = book.Isbn;
                    command.Parameters.Add("@custominfo", FbDbType.Text).Value = book.CustomInfo;
                    command.Parameters.Add("@dateupdated", FbDbType.TimeStamp).Value = book.DateUpdated;
                    command.Parameters.Add("@myid", FbDbType.VarChar).Value = book.SurrogateId;
                    command.Parameters.Add("@ext", FbDbType.VarChar).Value = book.Extension;
                    command.Parameters.Add("@filesize", FbDbType.Float).Value = book.FileSize;
                    command.Parameters.Add("@userid", FbDbType.Integer).Value = book.Userid;
                    command.Parameters.Add("@username", FbDbType.VarChar).Value = book.Username;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "DELETE FROM BOOK_AUTOR WHERE BOOKID = @bookid";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "INSERT INTO BOOK_AUTOR (ID, BOOKID, AUTORID) VALUES (GEN_ID(GEN_BOOK_AUTOR_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author bookAuthor in bookAuthors)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = bookAuthor.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "DELETE FROM BOOK_DOCAUTOR WHERE BOOKID = @bookid";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "INSERT INTO BOOK_DOCAUTOR (ID, BOOKID, DOCAUTORID) VALUES (GEN_ID(GEN_BOOK_DOCAUTOR_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author documentAuthor in documentAuthors)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = documentAuthor.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "DELETE FROM BOOK_TRANSLATE WHERE BOOKID = @bookid";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "INSERT INTO BOOK_TRANSLATE (ID, BOOKID, TRANSLATEID) VALUES (GEN_ID(GEN_BOOK_TRANSLATE_ID, 1), @bookid, @autorid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@autorid", FbDbType.Integer);
                    command.Prepare();

                    foreach (Author translator in bookTranslators)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@autorid"].Value = translator.Id;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "DELETE FROM BOOK_SEQUENCE WHERE BOOKID = @bookid";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "INSERT INTO BOOK_SEQUENCE (BOOKID, SEQUENCEID) VALUES (@bookid, @sequenceid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@sequenceid", FbDbType.Integer);
                    command.Prepare();

                    foreach (SequenceInfo sequenceInfo in bookSequences)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@sequenceid"].Value = sequenceInfo.SequenceId;

                        command.ExecuteNonQuery();
                    }
                }

                commandText =
                    "DELETE FROM BOOK_GENRE WHERE BOOKID = @bookid";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer).Value = book.BookId;

                    command.ExecuteNonQuery();
                }

                commandText =
                    "INSERT INTO BOOK_GENRE (ID, BOOKID, GENREID) VALUES (GEN_ID(GEN_BOOK_GENRE_ID, 1), @bookid, @genreid)";

                using (FbCommand command = this.connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    command.Transaction = transaction as FbTransaction;

                    command.Parameters.Add("@bookid", FbDbType.Integer);
                    command.Parameters.Add("@genreid", FbDbType.Char);
                    command.Prepare();

                    foreach (Genre genre in bookGenres)
                    {
                        command.Parameters["@bookid"].Value = book.BookId;
                        command.Parameters["@genreid"].Value = genre.Name;

                        command.ExecuteNonQuery();
                    }
                }

                return book;
            }
            catch (FbException exp)
            {
                throw new DatabaseException(exp.Message, exp);
            }
            finally
            {
                this.manager.EndConnect();
            }
        }
    }
}
