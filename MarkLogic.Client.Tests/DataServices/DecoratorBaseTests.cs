using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class DecoratorBaseTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public DecoratorBaseTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void Docify()
        {
            const string input = "value1";
            var dbNode = await DecoratorBaseService.Create(DbClient).Docify(input);
            Assert.NotNull(dbNode);

            JToken dbValue = null;
            var success = dbNode.TryGetValue("value", out dbValue);
            Assert.True(success);
            Assert.NotNull(dbValue);
            Assert.Equal(JTokenType.String, dbValue.Type);
            Assert.Equal(input, dbValue.ToString());
        }
    }
}