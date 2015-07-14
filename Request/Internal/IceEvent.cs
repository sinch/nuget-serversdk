namespace Sinch.Callback.Request.Internal
{
    public class IceEvent : CallingCallbackEvent, IIceEvent
    {
        public IceEvent()
        {
            Event = Event.IncomingCall;
        }

        public ICli Cli { get; set; }
        public IIdentity To { get; set; }
        public IMoney Rate { get; set; }
        public OriginationType OriginationType { get; set; }
    }
}