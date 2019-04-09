using MarkLogic.Client.Tools.Services;

namespace MarkLogic.Client.Tools.Actions
{
    public static class ScaffoldUpdateAction
    {
        private static IAction _action;

        public static IAction Default => _action ?? (_action = new SimpleActionBuilder()
            .WithVerb("update")
            .OnExecute(async (serviceProvider) =>
            {
                var console = serviceProvider.GetService<IConsole>();
                var fs = serviceProvider.GetService<IFilesystem>();

                var toolConfig = await ProjectToolConfig.Load(ProjectToolConfig.DefaultFilename, fs);
                var dataServiceAction = ScaffoldDataServiceAction.Default;
                foreach(var dsConfig in toolConfig.DataServices)
                {
                    var args = new[] { "-i", dsConfig.Input, "-o", dsConfig.Output };
                    var retVal = await dataServiceAction.Execute(serviceProvider, args);
                }

                return 0;
            })
            .Create());
    }
}
