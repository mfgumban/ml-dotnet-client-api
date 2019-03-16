using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarkLogic.NetCoreCLI.Actions
{
    public static class DataServiceAction
    {
        private static IAction _action;

        public static IAction Default => _action ?? (_action = new ActionBuilder("dataservice")
            .WithOption("service", "s", 1, 1)
            .OnExecute((serviceProvider) =>
            {
                return Task.FromResult(0);
            })
            .Create());
    }
}
