using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ConnectPstnSvamletResponse : SvamletResponse, IConnectPstnSvamletResponse
    {
        public IConnectPstnSvamletResponse WithDialTimeout(TimeSpan timeout)
        {
            Model.Action.DialTimeout = (int) timeout.TotalSeconds;
            return this;
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

        public IConnectPstnSvamletResponse WithIncomingCli()
        {
            Model.Action.Cli = "incoming";
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

        public IConnectPstnSvamletResponse WithIndications(string indications)
        {
            Model.Action.Indications = indications;
            return this;
        }
        public IConnectPstnSvamletResponse WithRecording()
        {
            Model.Action.Record = true;
            return this;
        }

        public IConnectPstnSvamletResponse WithoutRecording()
        {
            Model.Action.Record = false;
            return this;
        }
    }
}
