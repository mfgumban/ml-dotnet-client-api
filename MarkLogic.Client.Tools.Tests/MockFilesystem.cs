using MarkLogic.Client.Tools.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.Tools.Tests
{
    public class MockFilesystem : IFilesystem
    {
        public MockFilesystem()
        {
        }

        public Func<string, bool> OnPathExists { get; set; }

        public Func<string, string, IEnumerable<string>> OnEnumerateFiles { get; set; }

        public Func<string, bool, Stream> OnOpenFile { get; set; }

        public string CurrentDirectory { get; set; }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return OnEnumerateFiles != null 
                ? OnEnumerateFiles(path, searchPattern) 
                : throw new NotImplementedException();
        }

        public Stream OpenRead(string path)
        {
            return OnOpenFile != null
                ? OnOpenFile(path, true)
                : throw new NotImplementedException();
        }

        public Stream OpenWrite(string path)
        {
            return OnOpenFile != null
                ? OnOpenFile(path, false)
                : throw new NotImplementedException();
        }

        public bool PathExists(string path)
        {
            return OnPathExists != null 
                ? OnPathExists(path) 
                : throw new NotImplementedException();
        }
    }
}
