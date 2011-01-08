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
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using Gremlin.FB2Librarian.Import.Utils;
using Gremlin.FB2Librarian.Import.Entities;

namespace Gremlin.FB2Librarian.Import
{
    internal class Genre : IEquatable<Genre>
    {
        private readonly string name;
        private readonly Dictionary<string, string> descriptions;

        public Genre(string name)
        {
            this.name = name;
            this.descriptions = new Dictionary<string, string>(2);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void AddDescription(string lang, string value)
        {
            if (String.IsNullOrEmpty(lang))
            {
                throw new ArgumentException("lang");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            descriptions[lang] = value;
        }

        public string GetDescription(string lang)
        {
            if(descriptions.ContainsKey(lang))
            {
                return descriptions[lang];
            }

            return String.Empty;
        }

        public override string ToString()
        {
            string description = GetDescription("ru");

            if(String.IsNullOrEmpty(description))
            {
                description = GetDescription("en");
                if (String.IsNullOrEmpty(description))
                {
                    description = this.name;
                }
            }

            return description;
        }

        public bool Equals(Genre genre)
        {
            if (genre == null)
            {
                return false;
            }
            return Equals(name, genre.name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as Genre);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }

    internal class GenreTable : IEnumerable<Genre>
    {
        private readonly Dictionary<string, Genre> genres;
        private readonly Dictionary<string, string> genreMap;

        private static volatile GenreTable instance;
        private static readonly object genreSync = new object();

        private GenreTable()
        {
            this.genres = new Dictionary<string, Genre>();
            this.genreMap = new Dictionary<string, string>();
        }

        public static GenreTable Table
        {
            get
            {
                if(instance == null)
                {
                    lock(genreSync)
                    {
                        if(instance == null)
                        {
                            instance = new GenreTable();
                        }
                    }
                }

                return instance;
            }
        }

        public static void ReadGenreList(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            lock (genreSync)
            {
                if(instance == null)
                {
                    instance = new GenreTable();
                }

                XmlDocument genreList = new XmlDocument();
                genreList.Load(reader);

                instance.genres.Clear();
                instance.genreMap.Clear();

                XmlNodeList nodeList = genreList.SelectNodes("//fbgenrestransfer/genre/subgenres/subgenre");
                foreach (XmlNode genreNode in nodeList)
                {
                    XmlElement genreElement = genreNode as XmlElement;
                    if (genreElement != null)
                    {
                        XmlAttribute genreName = genreElement.Attributes["value"];
                        if (genreName != null && !String.IsNullOrEmpty(genreName.Value))
                        {
                            Genre genre = new Genre(genreName.Value);
                            foreach (XmlNode childNode in genreElement.ChildNodes)
                            {
                                if (childNode.NodeType == XmlNodeType.Element)
                                {
                                    XmlElement childElement = childNode as XmlElement;
                                    if (childElement == null)
                                    {
                                        continue;
                                    }

                                    switch (childElement.LocalName)
                                    {
                                        case "genre-descr":
                                            XmlAttribute langAttribute = childElement.Attributes["lang"];
                                            XmlAttribute titleAttribute = childElement.Attributes["title"];

                                            if (langAttribute != null && !String.IsNullOrEmpty(langAttribute.Value))
                                            {
                                                genre.AddDescription(langAttribute.Value, titleAttribute == null ? String.Empty : titleAttribute.Value);
                                            }

                                            break;

                                        case "genre-alt":
                                            XmlAttribute valueAttribute = childElement.Attributes["value"];

                                            if (valueAttribute != null && !String.IsNullOrEmpty(valueAttribute.Value))
                                            {
                                                instance.genreMap[valueAttribute.Value] = genreName.Value;
                                            }

                                            break;
                                    }
                                }
                            }

                            instance.genres[genreName.Value] = genre;
                        }
                    }
                }
            }
        }
        
        public static void ReadGenreList(FirebirdDataAccess database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }

            lock (genreSync)
            {
                if (instance == null)
                {
                    instance = new GenreTable();
                }

                instance.genres.Clear();
                instance.genreMap.Clear();

                List<GenreInfo> genreInfoTable = database.LoadGenreList();

                foreach (GenreInfo genreInfo in genreInfoTable)
                {
                    Genre genre = new Genre(genreInfo.Name);
                    genre.AddDescription("ru", genreInfo.RuDescription);
                    genre.AddDescription("en", genreInfo.EnDescription);

                    foreach (GenreMapInfo genreMapInfo in genreInfo.GenreMap)
                    {
                        instance.genreMap[genreMapInfo.GenreAltName] = genreMapInfo.GenreName;
                    }

                    instance.genres.Add(genre.Name, genre);
                }
            }
        }

        public ReadOnlyDictionary<string, string> MapTable
        {
            get
            {
                return new ReadOnlyDictionary<string, string>(this.genreMap);
            }
        }

        public Genre this[string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }

                if(this.genres.ContainsKey(name))
                {
                    return this.genres[name];
                }

                return null;
            }
        }
        
        IEnumerator<Genre> IEnumerable<Genre>.GetEnumerator()
        {
            foreach (Genre genre in genres.Values)
            {
                yield return genre;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<Genre>) this).GetEnumerator();
        }
    }
}
