using System;

namespace MarkLogic.Client
{
    public class DataServiceRequestException : Exception
    {
        public DataServiceRequestException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
