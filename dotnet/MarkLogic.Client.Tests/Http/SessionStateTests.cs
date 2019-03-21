using MarkLogic.Client.Tests.DataServices;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.Http
{
    public class SessionStateTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public SessionStateTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public void Equality()
        {
            var service = BaseService.Create(DbClient);

            var session1 = service.NewSession();
            var session2 = service.NewSession();

            Assert.Equal(session1, session1);
            Assert.Equal(session2, session2);
            Assert.NotEqual(session1, session2);
        }

        [Fact]
        public async void Usage()
        {
            var service = BaseService.Create(DbClient);

            var entityName = "Master Entity Name 1";
            var itemName = "Item Name 1";
            var session = service.NewSession();
            var id = await service.InsertMaster(entityName, session);
            var result = await service.InsertDetail(id, itemName, session);

            Assert.NotNull(result);
            Assert.Equal(id, result.Value<string>("id"));
            Assert.Equal(entityName, result.Value<string>("name"));
            Assert.Equal(itemName, result.SelectToken("items[0].itemName").Value<string>());
        }
    }
}
