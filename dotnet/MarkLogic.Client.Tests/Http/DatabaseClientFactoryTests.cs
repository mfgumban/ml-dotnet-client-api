using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkLogic.Client.Tests.Http
{
    public class DatabaseClientFactoryTests
    {
        [Fact]
        public void MultipleCreate()
        {
            // specifically tests the behavior of the shared credential cache
            var createFunc = new Func<IDatabaseClient>(() => DatabaseClientFactory.Create(
                UriScheme.Http,
                Configuration.Instance.MLHost,
                Configuration.Instance.MLPort,
                new NetworkCredential(
                    Configuration.Instance.MLUsername,
                    Configuration.Instance.MLPassword,
                    "public"),
                AuthenticationType.Digest));

            var totalTasks = 50;
            var tasks = new Task<IDatabaseClient>[totalTasks];
            for (int i = 0; i < totalTasks; i++)
            {
                tasks[i] = Task.Run(createFunc);
            }
            Task.WaitAll(tasks);

            Assert.True(!tasks.Any(t => t.IsFaulted));
            Assert.True(!tasks.Any(t => t.Result == null));
            
            foreach(var task in tasks)
            {
                task.Result.Dispose();
            }
        }
    }
}
