using System;
using System.Collections.Generic;
using System.Text;

namespace MarkLogic.NetCoreCLI.Services
{
    public sealed class CLIConsole : IConsole
    {
        public CLIConsole()
        {
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

        public void Write(string output)
        {
            Console.Write(output);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
