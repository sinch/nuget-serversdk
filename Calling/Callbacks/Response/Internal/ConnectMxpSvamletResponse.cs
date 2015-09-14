using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class ConnectMxpSvamletResponse : SvamletResponse, IConnectMxpSvamletResponse
    {
        public IConnectMxpSvamletResponse WithCli(string cli)
        {
            Model.ActionModel.Cli = cli;
            return this;
        }

        public IConnectMxpSvamletResponse WithAnonymousCli()
        {
            Model.ActionModel.Cli = "private";
            return this;
        }
    }
}