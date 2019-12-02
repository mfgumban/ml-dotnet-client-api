using MarkLogic.Client.DataService;
using System.Threading.Tasks;

namespace MarkLogic.Client.Tests.DataServices
{
    public class SessionsService : DataServiceBase
    {
        protected SessionsService(IDatabaseClient dbClient) : base(dbClient, "/test/sessions/")
        {
        }

        public static SessionsService Create(IDatabaseClient dbClient)
        {
            return new SessionsService(dbClient);
        }

        public ISessionState NewSession()
        {
            return DbClient.CreateSession();
        }

        public Task BeginTransaction(ISessionState transaction, string uri, string text)
        {
            return CreateRequest("beginTransaction.sjs")
                .WithSession(transaction, false)
                .WithParameters(
                    new SingleParameter<string>("uri", false, uri, Marshal.String),
                    new SingleParameter<string>("text", false, text, Marshal.String)
                )
                .RequestNone();
        }

        public Task BeginTransactionNoSession(string uri, string text)
        {
            return CreateRequest("beginTransactionNoSession.sjs")
                .WithParameters(
                    new SingleParameter<string>("uri", false, uri, Marshal.String),
                    new SingleParameter<string>("text", false, text, Marshal.String)
                )
                .RequestNone();
        }

        public Task<bool> CheckTransaction(ISessionState transaction, string uri)
        {
            return CreateRequest("checkTransaction.sjs")
                .WithSession(transaction, true)
                .WithParameters(
                    new SingleParameter<string>("uri", false, uri, Marshal.String)
                )
                .RequestSingle(false, Unmarshal.Boolean);
        }

        public Task<bool> GetSessionField(ISessionState timestamper, string fieldName, ulong fieldValue)
        {
            return CreateRequest("getSessionField.sjs")
                .WithSession(timestamper, false)
                .WithParameters(
                    new SingleParameter<string>("fieldName", false, fieldName, Marshal.String),
                    new SingleParameter<ulong>("fieldValue", false, fieldValue, Marshal.UnsignedLong)
                )
                .RequestSingle(false, Unmarshal.Boolean);
        }

        public Task RollbackTransaction(ISessionState transaction)
        {
            return CreateRequest("rollbackTransaction.sjs")
                .WithSession(transaction, false)
                .RequestNone();
        }

        public Task<ulong> SetSessionField(ISessionState timestamper, string fieldName)
        {
            return CreateRequest("setSessionField.sjs")
                .WithSession(timestamper, false)
                .WithParameters(
                    new SingleParameter<string>("fieldName", false, fieldName, Marshal.String)
                )
                .RequestSingle(false, Unmarshal.UnsignedLong);
        }

        public Task SetSessionFieldNoSession(string fieldName)
        {
            return CreateRequest("setSessionFieldNoSession.sjs")
                .WithParameters(
                    new SingleParameter<string>("fieldName", false, fieldName, Marshal.String)
                )
                .RequestNone();
        }

        public Task<bool> Sleepify(ISessionState sleeper, uint sleeptime)
        {
            return CreateRequest("sleepify.sjs")
                .WithSession(sleeper, false)
                .WithParameters(
                    new SingleParameter<uint>("sleeptime", false, sleeptime, Marshal.UnsignedInteger)
                )
                .RequestSingle(false, Unmarshal.Boolean);
        }
    }
}
