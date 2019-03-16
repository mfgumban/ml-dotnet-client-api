using System;

namespace MarkLogic.NetCoreCLI
{
    public static class ExtensionMethods
    {
        public static bool EqualsIgnoreCase(this string value, string valueToCompare)
        {
            return value.Equals(valueToCompare, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}