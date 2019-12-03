using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices.Generated
{
    /// <summary>
    /// Provides methods to invoke data services in "/test/generated/postOfNoneForNone/".
    /// </summary>
    public partial class PostOfNoneForNone : DataServiceBase
    {
        /// <summary>
        /// Constructs a new PostOfNoneForNone object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected PostOfNoneForNone(IDatabaseClient dbClient) : base(dbClient, "/test/generated/postOfNoneForNone/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new PostOfNoneForNone object.</returns>
        public static PostOfNoneForNone Create(IDatabaseClient dbClient)
        {
            return new PostOfNoneForNone(dbClient);
        }

        /// <summary>
        /// Invokes the "postOfNoneForNone0.xqy" data service endpoint.
        /// </summary>
        public Task PostOfNoneForNone0()
        {
            return CreateRequest("postOfNoneForNone0.xqy")
                .RequestNone();
        }
    }
}
