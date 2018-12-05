using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests
{
    public class PartServiceTests : IClassFixture<DatabaseClientFixture>
    {
        private readonly DatabaseClientFixture _dbClientFixture;
        private readonly ITestOutputHelper _output;

        public PartServiceTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
        {
            _dbClientFixture = dbClientFixture;
            _output = output;
        }

        private IDatabaseClient DbClient => _dbClientFixture.DbClient;

        [Fact]
        public async void TestListParts()
        {
            var pageLength = 10;
            var options = new string[] { "the", "quick", "brown", "fox" };
            var doc = new StringReader("<test><node>1</node></test>");

            var ps = PartService.Create(DbClient); 
            var results = await ps.listParts(pageLength, options, doc);

            foreach(var result in results)
            {
                _output.WriteLine(result);
            }
        }
    }
}
