using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ConnectConferenceSvamletResponse : SvamletResponse, IConnectConferenceSvamletResponse
    {
        public IConnectConferenceSvamletResponse WithMusicOnHold(string moh)
        {
            Model.Action.Moh = moh;
            return this;
        }

        public IConnectConferenceSvamletResponse WithRecording()
        {
            Model.Action.Record = true;
            return this;
        }

        public IConnectConferenceSvamletResponse WithoutRecording()
        {
            Model.Action.Record = false;
            return this;
        }

        public IConnectConferenceSvamletResponse WithCli(string cli)
        {
            Model.Action.Cli = cli;
            return this;
        }

        public IConnectConferenceSvamletResponse WithEnterAndLeaveSounds()
        {
            Model.Action.EnterLeaveSound = true;
            return this;
        }

        public IConnectConferenceSvamletResponse WithoutEnterAndLeaveSounds()
        {
            Model.Action.EnterLeaveSound = false;
            return this;
        }

        public IConnectConferenceSvamletResponse WithTwoParts()
        {
            Model.Action.ConferenceType = "twopart";
            return this;
        }

        public IConnectConferenceSvamletResponse WithMultiParts()
        {
            Model.Action.ConferenceType = "multipart";
            return this;
        }

        public IConnectConferenceSvamletResponse WithCallTag(CallTag tagType, string value)
        {
            AddCallTag(tagType, value);

            return this;
        }
    }
}