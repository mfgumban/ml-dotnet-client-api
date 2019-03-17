using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.Tools.Services
{
    public interface IFilesystem
    {
        string CurrentDirectory { get; }

        Stream OpenRead(string path);

        Stream OpenWrite(string path);

        IEnumerable<string> EnumerateFiles(string path, string searchPattern);
    }
}