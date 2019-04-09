using System;
using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.Tools.Services
{
    public class Filesystem : IFilesystem
    {
        public string CurrentDirectory => Directory.GetCurrentDirectory();

        public bool PathExists(string path)
        {
            try
            {
                var attr = File.GetAttributes(path);
                return true;
            }
            catch(Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                return false;
            }
        }

        public Stream OpenRead(string path)
        {
            return File.OpenRead(path);
        }

        public Stream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
        }
    }
}
