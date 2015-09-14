using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class ConnectPstnSvamletResponse : SvamletResponse, IConnectPstnSvamletResponse
    {
        public IConnectPstnSvamletResponse WithDialTimeout(TimeSpan timeout)
        {
            Model.ActionModel.DialTimeout = (int) timeout.TotalSeconds;
            return this;
        }

        public IConnectPstnSvamletResponse WithOptimizedDialTimeout()
        {
            return WithDialTimeout(TimeSpan.FromSeconds(-1));
        }

        public IConnectPstnSvamletResponse WithBridgeTimeout(TimeSpan timeout)
        {
            if (timeout.TotalMinutes > 240)
                throw new BuilderException("Cannot specify more than 4 hours of calling");

            Model.ActionModel.MaxDuration = (int)timeout.TotalSeconds;
            return this;
        }

        public IConnectPstnSvamletResponse WithCli(string cli)
        {
            Model.ActionModel.Cli = cli;
            return this;
        }

        public IConnectPstnSvamletResponse WithAnonymousCli()
        {
            Model.ActionModel.Cli = "private";
            return this;
        }

        public IConnectPstnSvamletResponse WithCallbacks()
        {
            Model.ActionModel.SuppressCallbacks = false;
            return this;
        }

        public IConnectPstnSvamletResponse WithoutCallbacks()
        {
            Model.ActionModel.SuppressCallbacks = true;
            return this;
        }
    }
}
