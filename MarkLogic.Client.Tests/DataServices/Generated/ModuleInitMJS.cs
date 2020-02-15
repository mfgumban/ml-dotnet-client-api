using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/moduleInitMjs/".
    /// </summary>
    public partial class ModuleInitMJS : DataServiceBase
    {
        /// <summary>
        /// Constructs a new ModuleInitMJS object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected ModuleInitMJS(IDatabaseClient dbClient) : base(dbClient, "/test/generated/moduleInitMjs/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new ModuleInitMJS object.</returns>
        public static ModuleInitMJS Create(IDatabaseClient dbClient)
        {
            return new ModuleInitMJS(dbClient);
        }

        /// <summary>
        /// Invokes the "initializer.xqy" data service endpoint.
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <returns></returns>
        public Task<bool> Initializer(bool param1, double? param2, IEnumerable<float> param3, IEnumerable<int?> param4)
        {
            return CreateRequest("initializer.xqy")
                .WithParameters(
                    new SingleParameter<bool>("param1", false, param1, Marshal.Boolean), 
                    new SingleParameter<double?>("param2", true, param2, Marshal.Nullable<double>(Marshal.Double)), 
                    new MultipleParameter<float>("param3", false, param3, Marshal.Float), 
                    new MultipleParameter<int?>("param4", true, param4, Marshal.Nullable<int>(Marshal.Integer)))
                .RequestSingle<bool>(false, Unmarshal.Boolean);
        }
    }
}
