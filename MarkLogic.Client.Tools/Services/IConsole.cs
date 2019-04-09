namespace MarkLogic.Client.Tools.Services
{
    public interface IConsole
    {
        void Write(string output);

        void WriteLine(string output);

        string Prompt(string message, string defaultValue);

        bool PromptYesNo(string message, bool defaultValue);

        int PromptInteger(string message, int defaultValue);
    }
}
