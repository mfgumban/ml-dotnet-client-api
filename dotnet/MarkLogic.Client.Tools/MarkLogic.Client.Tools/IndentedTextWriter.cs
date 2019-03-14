using System;
using System.Collections.Generic;
using System.IO;

namespace MarkLogic.Client.Tools
{
    public class IndentedTextWriter
    {
        public const char IndentSpace = ' ';
        public const char IndentTab = '\t';

        private TextWriter _writer;
        private readonly string _indentStr;
        private string _currentIndent;

        public IndentedTextWriter(TextWriter writer, char indentChar = IndentSpace, int indentWidth = 4)
        {
            if (indentWidth <= 0)
            {
                throw new ArgumentOutOfRangeException("indentWidth", indentWidth, "indentWidth must be greater than zero.");
            }
            _currentIndent = "";
            _writer = writer;
            IndentChar = indentChar;
            IndentWidth = indentWidth;
            _indentStr = new string(indentChar, indentWidth);
        }

        public char IndentChar { get; }

        public int IndentWidth { get; }

        public void AddIndent()
        {
            _currentIndent = _currentIndent + _indentStr;
        }

        public void RemoveIndent()
        {
            if (_currentIndent.Length - IndentWidth < 0)
            {
                throw new InvalidOperationException("Current indent is already zero.");
            }
            _currentIndent = _currentIndent.Remove(0, IndentWidth);
        }

        public void WriteLine()
        {
            _writer.WriteLine();
        }

        public void WriteLine(string value)
        {
            _writer.WriteLine(_currentIndent + value);
        }

        public void WriteLines(IEnumerable<string> values)
        {
            foreach(var value in values)
            {
                WriteLine(value);
            }
        }
    }
}
