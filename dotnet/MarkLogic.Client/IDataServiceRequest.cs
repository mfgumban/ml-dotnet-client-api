using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarkLogic.Client
{
    public interface IDataServiceRequest
    {
        string ServicePath { get; }

        string ModuleName { get; }

        ISessionState Session { get; }

        IDataServiceRequest WithSession(ISessionState session, bool allowNull);

        IEnumerable<DataServiceParameter> Parameters { get; }

        IDataServiceRequest WithParameters(params DataServiceParameter[] parameters);

        Task RequestNone();

        Task<TResult> RequestSingle<TResult>(bool allowNull, Func<Stream, Task<TResult>> unmarshalValue);

        Task<IEnumerable<TResult>> RequestMultiple<TResult>(bool allowNull, Func<Stream, Task<TResult>> unmarshalValue);
    }
}