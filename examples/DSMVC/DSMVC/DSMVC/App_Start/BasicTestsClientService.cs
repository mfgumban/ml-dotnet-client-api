using MarkLogic.Client;
using MarkLogic.Client.DataService;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataServices.Test
{
    /// <summary>
    /// API endpoints to test basic data service operations.
    /// </summary>
    public partial class BasicTestsClientService : DataServiceBase
    {
        /// <summary>
        /// Constructs a new BasicTestsClientService object.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        protected BasicTestsClientService(IDatabaseClient dbClient) : base(dbClient, "/ServiceTest/")
        {
        }

        /// <summary>
        /// Creates a new service context using the provided client connection.
        /// </summary>
        /// <param name="dbClient">A client connection to the database server.</param>
        /// <returns>A new BasicTestsClientService object.</returns>
        public static BasicTestsClientService Create(IDatabaseClient dbClient)
        {
            return new BasicTestsClientService(dbClient);
        }

        /// <summary>
        /// Inserts a document representing a top-level entity.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>The entity's unique ID.</returns>
        public Task<string> DeleteClient(string Id)
        {
            return CreateRequest("deleteClient.xqy")
                .WithParameters(
                    new SingleParameter<string>("Id", false, Id, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>Get all clients</returns>
        public Task<JArray> GetAllClients()
        {
            return CreateRequest("getAllClients.xqy")
                .RequestSingle<JArray>(false, Unmarshal.JsonArray);
        }

        /// <summary>
        /// Get a client detail
        /// </summary>
        /// <param name="fid"></param>
        /// <returns>Get a client detail</returns>
        public Task<JObject> GetClientDetail(string fid)
        {
            return CreateRequest("getClientDetail.xqy")
                .WithParameters(
                    new SingleParameter<string>("fid", false, fid, Marshal.String))
                .RequestSingle<JObject>(false, Unmarshal.JsonObject);
        }

        /// <summary>
        /// Inserts a document representing a top-level entity.
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="adresse"></param>
        /// <param name="gender"></param>
        /// <returns>The entity's unique ID.</returns>
        public Task<string> InsertClient(string fname, string lname, string adresse, string gender)
        {
            return CreateRequest("insertClient.xqy")
                .WithParameters(
                    new SingleParameter<string>("fname", false, fname, Marshal.String), 
                    new SingleParameter<string>("lname", false, lname, Marshal.String), 
                    new SingleParameter<string>("adresse", false, adresse, Marshal.String), 
                    new SingleParameter<string>("gender", false, gender, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }

        /// <summary>
        /// Inserts a document representing a top-level entity.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="adresse"></param>
        /// <param name="gender"></param>
        /// <returns>The entity's unique ID.</returns>
        public Task<string> UpdateClient(string Id, string fname, string lname, string adresse, string gender)
        {
            return CreateRequest("updateClient.xqy")
                .WithParameters(
                    new SingleParameter<string>("Id", false, Id, Marshal.String), 
                    new SingleParameter<string>("fname", false, fname, Marshal.String), 
                    new SingleParameter<string>("lname", false, lname, Marshal.String), 
                    new SingleParameter<string>("adresse", false, adresse, Marshal.String), 
                    new SingleParameter<string>("gender", false, gender, Marshal.String))
                .RequestSingle<string>(false, Unmarshal.String);
        }
    }
}
