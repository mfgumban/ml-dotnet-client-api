using System;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.FunctionalTests
{
    public abstract class DbTestBase
    {
        protected DbTestBase(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
        {
            DbClientFixture = dbClientFixture;
            Output = output;
        }

        protected DatabaseClientFixture DbClientFixture { get; private set; }

        protected ITestOutputHelper Output { get; private set; }

        protected IDatabaseClient DbClient => DbClientFixture.DbClient;
    }
}
