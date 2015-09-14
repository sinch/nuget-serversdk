using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.Callback.Response.Internal
{
    internal class ConnectConferenceSvamletResponse : SvamletResponse, IConnectConferenceSvamletResponse
    {
        public IConnectConferenceSvamletResponse WithMusicOnHold(string moh)
        {
            Model.ActionModel.Moh = moh;
            return this;
        }

        public IConnectConferenceSvamletResponse WithRecording()
        {
            Model.ActionModel.Record = true;
            return this;
        }

        public IConnectConferenceSvamletResponse WithoutRecording()
        {
            Model.ActionModel.Record = false;
            return this;
        }

        public IConnectConferenceSvamletResponse WithCli(string cli)
        {
            Model.ActionModel.Cli = cli;
            return this;
        }
    }
}