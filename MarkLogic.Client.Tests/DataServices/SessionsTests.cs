using MarkLogic.Client.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MarkLogic.Client.Tests.DataServices
{
    public class SessionsTests : DbTestBase, IClassFixture<DatabaseClientFixture>
    {
        public SessionsTests(DatabaseClientFixture dbClientFixture, ITestOutputHelper output)
            : base(dbClientFixture, output)
        {
        }

        [Fact]
        public async void SessionField()
        {
            const string timestampField = "timestamped";
            var service = SessionsService.Create(DbClient);
            var session = DbClient.CreateSession();

            var timestampValue = await service.SetSessionField(session, timestampField);
            var valueMatched = await service.GetSessionField(session, timestampField, timestampValue);
            Assert.True(valueMatched, $"Failed to get the value {timestampValue} from the session field {timestampField}.");

            var otherSession = DbClient.CreateSession();
            var otherValueMatched = await service.GetSessionField(otherSession, timestampField, timestampValue);
            Assert.False(otherValueMatched, $"Got the value {timestampValue} from the session field {timestampField} for the wrong session.");
        }

        [Fact]
        public async void Transaction()
        {
            const string docUri = "/test/session/transaction/doc1.txt";
            var service = SessionsService.Create(DbClient);
            var session = DbClient.CreateSession();

            var hasRolledBack = false;
            var sessionId = session.SessionId;
            var docText = $"Transaction for session: {sessionId}";

            try
            {
                var docExists = await service.CheckTransaction(null, docUri);
                Assert.False(docExists, $"Found {docUri} outside unopened transaction in session {sessionId}.");

                docExists = await service.CheckTransaction(session, docUri);
                Assert.False(docExists, $"Found {docUri} before opening transaction in session {sessionId}.");

                await service.BeginTransaction(session, docUri, docText);

                docExists = await service.CheckTransaction(session, docUri);
                Assert.True(docExists, $"Failed tofind {docUri} after opening transaction in session {sessionId}.");

                docExists = await service.CheckTransaction(null, docUri);
                Assert.False(docExists, $"Found {docUri} outside open transaction in session {sessionId}.");

                await service.RollbackTransaction(session);
                hasRolledBack = true;

                docExists = await service.CheckTransaction(null, docUri);
                Assert.False(docExists, $"Found {docUri} outside rolled back transaction in session {sessionId}.");

                docExists = await service.CheckTransaction(session, docUri);
                Assert.False(docExists, $"Found {docUri} after rolling back transaction in session {sessionId}.");
            }
            catch (Exception e) 
            {
                if (!hasRolledBack)
                {
                    await service.RollbackTransaction(session);
                }
                throw e;
            }
        }

        [Fact]
        public void ConcurrentSessions()
        {
            const int numThreads = 3;
            const int sleepTime = 750;
            var threads = new Task[numThreads];
            var service = SessionsService.Create(DbClient);
            
            for (var i = 0; i < numThreads; i++)
            {
                var id = i;
                var session = service.NewSession();
                var task = new Task(async () =>
                {
                    var sleep = await service.Sleepify(session, sleepTime);
                    Assert.True(sleep, $"Failed to sleep for thread {id}.");
                });
                threads[i] = task;
            }

            foreach(var task in threads)
            {
                task.Start();
            }

            Task.WaitAll(threads);
        }

        [Fact]
        public async void SessionFieldNegative()
        {
            await Assert.ThrowsAsync<Exception>(async () => 
            { 
                await SessionsService.Create(DbClient).SetSessionField(null, "unused"); 
            });
        }

        [Fact]
        public async void TransactionNoSessionNegative() 
        {
            await Assert.ThrowsAsync<Exception>(async () => 
            { 
                await SessionsService.Create(DbClient).BeginTransactionNoSession("/test/session/transaction/negative1.txt", "Should never succeed");
            });
        }

        [Fact]
        public async void SessionFieldNoSessionNegative()
        {
            await Assert.ThrowsAsync<Exception>(async () => 
            {
                await SessionsService.Create(DbClient).SetSessionFieldNoSession("Should never succeed");
            });
        }
    }
}
