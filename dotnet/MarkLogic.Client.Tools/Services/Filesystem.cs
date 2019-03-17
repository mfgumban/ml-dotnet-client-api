using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.Tools.Services
{
    public class Filesystem : IFilesystem
    {
        public string CurrentDirectory => Directory.GetCurrentDirectory();

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
