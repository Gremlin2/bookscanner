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
using System.Text.RegularExpressions;

namespace Gremlin.FB2Librarian.Import.Utils
{
    internal static class StringUtils
    {
        private static readonly Dictionary<char, string> table;
        private static readonly Regex invalidCharsRegex;

        static StringUtils()
        {
            table = new Dictionary<char, string>(75);

            table.Add('а', "a");
            table.Add('б', "b");
            table.Add('в', "v");
            table.Add('г', "g");
            table.Add('д', "d");
            table.Add('е', "e");
            table.Add('ж', "zh");
            table.Add('з', "z");
            table.Add('и', "i");
            table.Add('й', "y");
            table.Add('к', "k");
            table.Add('л', "l");
            table.Add('м', "m");
            table.Add('н', "n");
            table.Add('о', "o");
            table.Add('п', "p");
            table.Add('р', "r");
            table.Add('с', "s");
            table.Add('т', "t");
            table.Add('у', "u");
            table.Add('ф', "f");
            table.Add('х', "h");
            table.Add('ц', "ts");
            table.Add('ч', "ch");
            table.Add('ш', "sh");
            table.Add('щ', "sch");
            table.Add('ъ', "'");
            table.Add('ы', "yi");
            table.Add('ь', "");
            table.Add('э', "e");
            table.Add('ю', "yu");
            table.Add('я', "ya");
            table.Add('і', "i");
            table.Add('ґ', "g");
            table.Add('ё', "yo");
            table.Add('є', "e");
            table.Add('ї', "yi");
            table.Add('№', "#");
            table.Add('А', "A");
            table.Add('Б', "B");
            table.Add('В', "V");
            table.Add('Г', "G");
            table.Add('Д', "D");
            table.Add('Е', "E");
            table.Add('Ж', "ZH");
            table.Add('З', "Z");
            table.Add('И', "I");
            table.Add('Й', "Y");
            table.Add('К', "K");
            table.Add('Л', "L");
            table.Add('М', "M");
            table.Add('Н', "N");
            table.Add('О', "O");
            table.Add('П', "P");
            table.Add('Р', "R");
            table.Add('С', "S");
            table.Add('Т', "T");
            table.Add('У', "U");
            table.Add('Ф', "F");
            table.Add('Х', "H");
            table.Add('Ц', "TS");
            table.Add('Ч', "CH");
            table.Add('Ш', "SH");
            table.Add('Щ', "SCH");
            table.Add('Ъ', "'");
            table.Add('Ы', "YI");
            table.Add('Ь', "");
            table.Add('Э', "E");
            table.Add('Ю', "YU");
            table.Add('Я', "YA");
            table.Add('І', "I");
            table.Add('Ґ', "G");
            table.Add('Ё', "YO");
            table.Add('Є', "E");
            table.Add('Ї', "YI");

            char[] invalidChars = Path.GetInvalidFileNameChars();
            List<string> pattern = new List<string>(invalidChars.Length);

            foreach (char invalidChar in invalidChars)
            {
                if (invalidChar == Path.DirectorySeparatorChar)
                {
                    continue;
                }

                if (Char.IsControl(invalidChar))
                {
                    pattern.Add(String.Format("\\u{0:x4}", (int) invalidChar));
                }
                else
                {
                    pattern.Add(Regex.Escape(invalidChar.ToString()));
                }
            }

            invalidCharsRegex = new Regex("[" + String.Join("|", pattern.ToArray()) + "]");
        }

        private static char GetChar(string value, int index)
        {
            if (index < value.Length)
            {
                return value[index];
            }

            return Char.MinValue;
        }

        public static string Capitalize(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            return String.Concat(value.Substring(0, 1).ToUpperInvariant(), value.Substring(1));
        }

        public static string Squeeze(string str, char value)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length <= 1)
            {
                return str;
            }

            StringBuilder buffer = new StringBuilder(str.Length);

            char prevChar = str[0];
            buffer.Append(prevChar);

            for (int index = 1; index < str.Length; index++)
            {
                char nextChar = str[index];

                if (prevChar == nextChar && nextChar == value)
                {
                    continue;
                }

                buffer.Append(nextChar);
                prevChar = nextChar;
            }

            return buffer.ToString();
        }

        public static string Translify(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            StringBuilder buffer = new StringBuilder(value.Length);

            for (int index = 0; index < value.Length; index++)
            {
                if (table.ContainsKey(value[index]))
                {
                    if (Char.IsUpper(value[index]) && Char.IsLower(GetChar(value, index + 1)))
                    {
                        buffer.Append(Capitalize(table[value[index]].ToLowerInvariant()));
                    }
                    else
                    {
                        buffer.Append(table[value[index]]);
                    }
                }
                else
                {
                    buffer.Append(value[index]);
                }
            }

            return buffer.ToString();
        }

        public static string Dirify(string value)
        {
            return Dirify(value, false);
        }

        public static string Dirify(string value, bool strict)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            string filename = value;

            filename = Regex.Replace(filename, @"(\s\&\s)|(\s\&amp\;\s)", " and ");

            filename = filename.Replace("«", "'");
            filename = filename.Replace("»", "'");
            filename = filename.Replace("–", "-");

            if (strict)
            {
                filename = Regex.Replace(filename, @"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}\p{Lm}\\/\[\]\-_\*,\(\)<>]", " ");
                filename = Squeeze(filename, ' ');
            }

            filename = invalidCharsRegex.Replace(filename, "");

            filename = Regex.Replace(filename, @"(_)$", "");
            filename = Regex.Replace(filename, @"^(_)", "");

            filename = filename.Trim();

            return filename;
        }

        public static string Truncate(string value, int maxLength)
        {
            int length;

            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            if (value.Length < maxLength)
            {
                return value;
            }

            length = Math.Min(value.Length, maxLength);

            return value.Substring(0, length);
        }

        public static string CleanupFileName(string filename)
        {
            if (String.IsNullOrEmpty(filename))
            {
                return filename;
            }

            return invalidCharsRegex.Replace(filename, "");
        }

        public static int DamerauLevenshteinDistance(string src, string dest)
        {
            int[,] d = new int[src.Length + 1, dest.Length + 1];
            int i, j;

            for (i = 0; i <= src.Length; i++)
            {
                d[i, 0] = i;
            }

            for (j = 0; j <= dest.Length; j++)
            {
                d[0, j] = j;
            }

            for (i = 1; i <= src.Length; i++)
            {
                for (j = 1; j <= dest.Length; j++)
                {
                    int cost = (src[i - 1] == dest[j - 1]) ? 0 : 1;

                    d[i, j] =
                        Math.Min(d[i - 1, j] + 1,     // Deletion
                        Math.Min(d[i, j - 1] + 1,     // Insertion
                        d[i - 1, j - 1] + cost));     // Substitution

                    if ((i > 1) && (j > 1) && (src[i - 1] == dest[j - 2]) && (src[i - 2] == dest[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }
            }

            return d[src.Length, dest.Length];
        }

        public static int LongestCommonSubstring(string str1, string str2)
        {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
            {
                return 0;
            }

            int[,] num = new int[str1.Length,str2.Length];
            int maxlen = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                    {
                        num[i, j] = 0;
                    }
                    else
                    {
                        if ((i == 0) || (j == 0))
                        {
                            num[i, j] = 1;
                        }
                        else
                        {
                            num[i, j] = 1 + num[i - 1, j - 1];
                        }

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                        }
                    }
                }
            }

            return maxlen;
        }

        public static string Join<T>(string separator, List<T> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Join(separator, value, 0, value.Count);
        }

        public static string Join<T>(string separator, List<T> value, int startIndex, int count)
        {
            if (separator == null)
            {
                separator = String.Empty;
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (startIndex > (value.Count - count))
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (count == 0)
            {
                return String.Empty;
            }

            int capacity = 0;
            int length = (startIndex + count) - 1;
            for (int index = startIndex; index <= length; index++)
            {
                if (value[index] != null)
                {
                    capacity += value[index].ToString().Length;
                }
            }

            capacity += (count - 1) * separator.Length;

            if ((capacity < 0) || ((capacity + 1) < 0))
            {
                throw new OutOfMemoryException();
            }

            if (capacity == 0)
            {
                return String.Empty;
            }

            StringBuilder buffer = new StringBuilder(capacity);

            buffer.Append(value[startIndex]);

            for (int index = startIndex + 1; index <= length; index++)
            {
                buffer.Append(separator);
                buffer.Append(value[index]);
            }

            return buffer.ToString();
        }

        public static string Join<T>(string separator, IEnumerable<T> value)
        {
            if (separator == null)
            {
                separator = String.Empty;
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            StringBuilder buffer = new StringBuilder();

            bool firstItem = true;

            foreach (T item in value)
            {
                if (firstItem)
                {
                    buffer.Append(item);
                    firstItem = false;
                }
                else
                {
                    buffer.Append(separator);
                    buffer.Append(item);
                }
            }

            return buffer.ToString();
        }


        public static object ToDbString(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return DBNull.Value;
            }

            return value;
        }

        public static byte[] FromBase64(string s)
        {
            int length = s == null ? 0 : s.Length;

            if (length == 0)
            {
                return new byte[0];
            }

            int padding = 0;
            if (length > 2 && s[length - 2] == '=')
            {
                padding = 2;
            }
            else if (length > 1 && s[length - 1] == '=')
            {
                padding = 1;
            }

            int blocks = (length - 1) / 4 + 1;
            int bytes = blocks * 3;

            byte[] data = new byte[bytes - padding];

            for (int i = 0; i < blocks; i++)
            {
                bool finalBlock = i == blocks - 1;
                bool pad2 = false;
                bool pad1 = false;
                if (finalBlock)
                {
                    pad2 = padding == 2;
                    pad1 = padding > 0;
                }

                int index = i * 4;
                byte temp1 = CharToSixBit(s[index]);
                byte temp2 = CharToSixBit(s[index + 1]);
                byte temp3 = CharToSixBit(s[index + 2]);
                byte temp4 = CharToSixBit(s[index + 3]);

                byte b = (byte) (temp1 << 2);
                byte b1 = (byte) ((temp2 & 0x30) >> 4);
                b1 += b;

                b = (byte) ((temp2 & 0x0F) << 4);
                byte b2 = (byte) ((temp3 & 0x3C) >> 2);
                b2 += b;

                b = (byte) ((temp3 & 0x03) << 6);
                byte b3 = temp4;
                b3 += b;

                index = i * 3;
                data[index] = b1;
                if (!pad2)
                {
                    data[index + 1] = b2;
                }
                if (!pad1)
                {
                    data[index + 2] = b3;
                }
            }

            return data;
        }

        private static byte CharToSixBit(char c)
        {
            if (c == '=')
            {
                return 0;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return (byte) (c - 'A');
            }
            else if (c >= 'a' && c <= 'z')
            {
                return (byte) (c - 'a' + 26);
            }
            else if (c >= '0' && c <= '9')
            {
                return (byte) (c - '0' + 52);
            }
            else if (c == '+')
            {
                return 62;
            }
            else if (c == '/')
            {
                return 63;
            }

            throw new FormatException();
        }

        public static string FilterBin64(string value)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (((value[i] != ' ') && (value[i] != '\n')) && (value[i] != '\r'))
                {
                    builder.Append(value[i]);
                }
            }
            return builder.ToString();
        }
    }
}