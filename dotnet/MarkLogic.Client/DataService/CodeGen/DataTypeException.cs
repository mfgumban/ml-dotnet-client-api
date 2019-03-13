using System;

namespace MarkLogic.Client.DataService.CodeGen
{
    public class DataTypeException : Exception
    {
        public DataTypeException(string dataType)
            : base($"Invalid or unsupported data type {dataType}.")
        {
            DataType = dataType;
        }

        public DataTypeException(string dataType, string netClass)
            : base($"Invalid or unsupported mapping {netClass} on data type {dataType}.")
        {
            DataType = dataType;
        }

        public string DataType { get; }

        public string NetClass { get; }
    }
}
