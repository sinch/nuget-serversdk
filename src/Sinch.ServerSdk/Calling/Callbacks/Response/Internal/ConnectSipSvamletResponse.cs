using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ConnectSipSvamletResponse : SvamletResponse, IConnectSipSvamletResponse
    {
        public IConnectSipSvamletResponse WithCli(string cli)
        {
            Model.Action.Cli = cli;
            return this;
        }

        public IConnectSipSvamletResponse WithExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
                throw new BuilderException($"{nameof(extension)} cannot be empty");

            if (Model.Action.Destination != null)
                throw new BuilderException("A destination has already been specified");

            if (extension.Contains("@"))
                throw new BuilderException($"{nameof(extension)} should not be a full URI");

            Model.Action.Destination = new IdentityModel
            {
                Endpoint = extension.Replace("sip:", string.Empty),
                Type = "sip"
            };

            return this;
        }

        public IConnectSipSvamletResponse WithAccount(string account)
        {
            Model.Action.Account = account;
            return this;
        }

        public IConnectSipSvamletResponse WithAnonymousCli()
        {
            Model.Action.Cli = "private";
            return this;
        }

        public IConnectSipSvamletResponse WithIncomingCli()
        {
            Model.Action.Cli = "incoming";
            return this;
        }

        public IConnectSipSvamletResponse WithIndications(string indications)
        {
            Model.Action.Indications = indications;
            return this;
        }

        public IConnectSipSvamletResponse WithRecording()
        {
            Model.Action.Record = true;
            return this;
        }

        public IConnectSipSvamletResponse WithoutRecording()
        {
            Model.Action.Record = false;
            return this;
        }
    }
}