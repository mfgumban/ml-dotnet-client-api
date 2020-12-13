using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarkLogic.Client
{
    public class UnmarshalException : Exception
    {
        public UnmarshalException(string valueToConvert, Type convertToType, string message, Exception innerException = null)
            : base(message, innerException)
        {
            ValueToConvert = valueToConvert;
            ConvertToType = convertToType;
        }

        public string ValueToConvert { get; private set; }

        public Type ConvertToType { get; private set; }

        public static UnmarshalException Create(string valueToConvert, Type convertToType, Exception innerException = null)
        {
            var msg = $"Error trying to convert \"{valueToConvert.Truncate(20, "...(truncated)")}\" to {convertToType.FullName}";
            return new UnmarshalException(valueToConvert, convertToType, msg, innerException);
        }
    }
}
