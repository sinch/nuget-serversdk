namespace Sinch.Callback.Request
{
    public interface IIceEvent : ICallbackEvent
    {
        ICli Cli { get; }
        IIdentity To { get; }
        OriginationType OriginationType { get; }
        IMoney Rate { get; }
    }
}