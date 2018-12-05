using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkLogic.Client.DataService;

namespace MarkLogic.Client
{
    public interface IDataServiceRequest
    {
        string ServicePath { get; }

        string ModuleName { get; }

        IEnumerable<DataServiceParameter> Parameters { get; }

        IDataServiceRequest WithParameters(params DataServiceParameter[] parameters);

        Task RequestNone();

        Task<TResult> RequestSingle<TResult>(bool allowNull, Func<string, TResult> unmarshalValue);

        Task<IEnumerable<TResult>> RequestMultiple<TResult>(bool allowNull, Func<string, TResult> unmarshalValue);
    }
}