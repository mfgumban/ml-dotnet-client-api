using MarkLogic.Client.DataService;
using MarkLogic.Client.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace MarkLogic.Client.Tests.Http
{
    public class DataServiceRequestTests
    {
        private static IDatabaseClient CreateTestDbClient()
        {
            return DatabaseClientFactory.Create(UriScheme.Http, "not-a-valid-host", 9999, new NetworkCredential("", ""), AuthenticationType.Basic);
        }
        private static HttpDataServiceRequest CreateTestRequest()
        {
            var dbClient = CreateTestDbClient();
            return (HttpDataServiceRequest)dbClient.CreateDataServiceRequest("path/to/service", "name-of-module");
        }

        [Fact]
        public void WithParameters()
        {
            var parameters = new DataServiceParameter[] 
            {
                new SingleParameter<int>("singleParam", false, 0, Marshal.Integer),
                new MultipleParameter<int>("multiParam", false, new[] { 0, 1, 2 }, Marshal.Integer)
            };

            var request = CreateTestRequest()
                .WithParameters(parameters);

            Assert.Equal(parameters, request.Parameters);
        }

        public class MockSessionState : ISessionState
        {
            public string SessionId => "some-unique-session-id";

            public bool Equals(ISessionState session)
            {
                return session != null && SessionId == session.SessionId;
            }
        }

        public static IEnumerable<object[]> WithSessionTestData()
        {
            var dbClient = CreateTestDbClient();
            var validSession = dbClient.CreateSession();
            var nonHttpSession = new MockSessionState();

            return new[]
            {
                new object[] { validSession, true, null },
                new object[] { validSession, false, null },
                new object[] { nonHttpSession, true, typeof(ArgumentException) },
                new object[] { nonHttpSession, false, typeof(ArgumentException) },
                new object[] { null, true, null },
                new object[] { null, false, typeof(ArgumentNullException) },
            };
        }

        [Theory]
        [MemberData(nameof(WithSessionTestData))]
        public void WithSession(ISessionState session, bool allowNull, Type expectedException)
        {
            var createRequestFunc = new Func<IDataServiceRequest>(() => 
            {
                var dbClient = CreateTestDbClient();
                return CreateTestRequest().WithSession(session, allowNull);
            });

            if (expectedException != null)
            {
                Assert.Throws(expectedException, createRequestFunc);
            }
            else
            {
                var request = createRequestFunc();
                Assert.Equal(session, request.Session);
            }
        }
    }
}