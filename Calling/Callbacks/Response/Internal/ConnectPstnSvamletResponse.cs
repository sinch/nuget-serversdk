using System;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class ConnectPstnSvamletResponse : SvamletResponse, IConnectPstnSvamletResponse
    {
        public IConnectPstnSvamletResponse WithDialTimeout(TimeSpan timeout)
        {
            Model.Action.DialTimeout = (int) timeout.TotalSeconds;
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

            Model.Action.MaxDuration = (int)timeout.TotalSeconds;
            return this;
        }

        public IConnectPstnSvamletResponse WithCli(string cli)
        {
            Model.Action.Cli = cli;
            return this;
        }

        public IConnectPstnSvamletResponse WithAnonymousCli()
        {
            Model.Action.Cli = "private";
            return this;
        }

        public IConnectPstnSvamletResponse WithCallbacks()
        {
            Model.Action.SuppressCallbacks = false;
            return this;
        }

        public IConnectPstnSvamletResponse WithoutCallbacks()
        {
            Model.Action.SuppressCallbacks = true;
            return this;
        }
    }
}
