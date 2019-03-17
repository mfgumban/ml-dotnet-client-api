using MarkLogic.Client.Tools.Services;
using System;
using System.Collections.Generic;

namespace MarkLogic.Client.Tools.Tests
{
    public class MockConsole : IConsole
    {
        private List<string> _outputLines = new List<string>();
        private List<string> _currentLine = new List<string>();

        public MockConsole()
        {
        }

        public IEnumerable<string> OutputLines => _outputLines;

        public int OutputLineCount => _outputLines.Count;

        public void Write(string output)
        {
            _currentLine.Add(output);
        }

        public void WriteLine(string output)
        {
            _currentLine.Add(output);
            _outputLines.Add(string.Concat(_currentLine));
            _currentLine.Clear();
        }

        public string Prompt(string message, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public int PromptInteger(string message, int defaultValue)
        {
            throw new NotImplementedException();
        }

        public bool PromptYesNo(string message, bool defaultValue)
        {
            throw new NotImplementedException();
        }
    }
}
