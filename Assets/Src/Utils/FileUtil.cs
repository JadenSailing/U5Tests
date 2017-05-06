using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Util
{
    public class FileUtil
    {
        private static List<string> _filesPathList = new List<string>();
        private static List<string> _fileExList = new List<string>();
        public static string[] GetFilesPath(string rootPath, string fileEx = "")
        {
            _filesPathList.Clear();
            _fileExList.Clear();

            string[] exArr = fileEx.Split(';');

            for (int i = 0; i < exArr.Length; i++)
            {
                if (!string.IsNullOrEmpty(exArr[i]))
                {
                    _fileExList.Add(exArr[i]);
                }
            }
            AddAllFiles(rootPath);
            return _filesPathList.ToArray();
        }

        private static void AddAllFiles(String path)
        {
            if (System.IO.Directory.Exists(path))
            {
                string[] files = System.IO.Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (_fileExList.Count == 0)
                    {
                        _filesPathList.Add(file);
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if (_fileExList.IndexOf((fileInfo.Extension).ToLower()) > -1)
                        {
                            _filesPathList.Add(file);
                        }
                    }
                }
                string[] Dirs = System.IO.Directory.GetDirectories(path);
                foreach (string dir in Dirs)
                {
                    AddAllFiles(dir);
                }
            }
        }

        public static int GetFileLines(string path)
        {
            int lines = 0;
            StreamReader sr = new StreamReader(path);
            while (sr.ReadLine() != null)
            {
                lines++;
            }
            sr.Close();
            return lines;
        }
    }
}
