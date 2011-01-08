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
using System.Globalization;
using System.IO;

namespace Gremlin.FB2Librarian.Import.Utils
{
    internal static class FileUtils
    {
        public static string GetOutputFileName(string path, string filename, string extension, bool overwrite, int maxLength)
        {
            string fullFilename;

            if (maxLength > 0)
            {
                fullFilename = Path.Combine(path, StringUtils.Truncate(filename, maxLength - extension.Length)) + extension;
            }
            else
            {
                fullFilename = Path.Combine(path, filename) + extension;
            }

            if (overwrite)
            {
                return fullFilename;
            }

            int fileIndex = 0;
            while (File.Exists(fullFilename))
            {
                fileIndex++;
                string suffix = fileIndex.ToString(CultureInfo.InvariantCulture);

                if (maxLength > 0)
                {
                    fullFilename = Path.Combine(path, StringUtils.Truncate(filename, maxLength - extension.Length - suffix.Length)) + suffix + extension;
                }
                else
                {
                    fullFilename = Path.Combine(path, filename) + suffix + extension;
                }
            }

            return fullFilename;
        }

        public static string GetOutputFileName(string path, string filename, string extension)
        {
            return GetOutputFileName(path, filename, extension, false, 0);
        }

        public static string GetOutputFileName(string path, string filename, string extension, bool overwrite)
        {
            return GetOutputFileName(path, filename, extension, overwrite, 0);
        }

        public static string SplitFilePath(string pathRoot, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            
            if(String.IsNullOrEmpty(pathRoot))
            {
                return path;
            }
            
            if(!pathRoot.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                pathRoot += Path.DirectorySeparatorChar.ToString();
            }

            return path.Substring(pathRoot.Length);
        }
    }
}