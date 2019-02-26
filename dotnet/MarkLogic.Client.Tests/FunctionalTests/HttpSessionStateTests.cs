using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests
{
    public class HttpSessionStateTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public HttpSessionStateTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void TestGetSessionId()
        {
            await BasicTestsService.Create(DbClient).returnNone();
        }
    }
}