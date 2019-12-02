using MarkLogic.Client.DataService;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class DecoratorBaseService : DataServiceBase
    {
        protected DecoratorBaseService(IDatabaseClient dbClient) : base(dbClient, "/test/decoratorBase/")
        {
        }

        public static DecoratorBaseService Create(IDatabaseClient dbClient)
        {
            return new DecoratorBaseService(dbClient);
        }

        public ISessionState NewSession()
        {
            return DbClient.CreateSession();
        }

        public Task<JObject> Docify(string value)
        {
            return CreateRequest("docify.sjs")
                .WithParameters(
                    new SingleParameter<string>("value", false, value, Marshal.String)
                )
                .RequestSingle<JObject>(true, Unmarshal.JsonObject);
        }
    }
}
