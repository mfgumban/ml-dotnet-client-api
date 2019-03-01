using MarkLogic.Client.Tests.DataServices;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests
{
    public class PartServiceTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public PartServiceTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void TestListParts()
        {
            var pageLength = 10;
            var options = new string[] { "the", "quick", "brown", "fox" };
            var doc = new MemoryStream();
            var docWriter = new StreamWriter(doc);
            
            docWriter.Write("<test><node>1</node></test>");
            docWriter.Flush();
            doc.Position = 0;

            var ps = PartService.Create(DbClient); 
            var results = await ps.listParts(pageLength, options, doc);

            foreach(var result in results)
            {
                Output.WriteLine(result);
            }

            docWriter.Dispose();
            doc.Dispose();
        }
    }
}
