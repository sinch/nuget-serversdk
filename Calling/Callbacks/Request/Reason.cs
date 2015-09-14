namespace Sinch.ServerSdk.Calling.Callbacks.Request
{
    public enum Reason
    {
        Error,
        Answered,
        Busy,
        NoAnswer,
        NotApplicable,
        CallerHangup,
        CalleeHangup,
        ManagerHangup,
        Timeout,

        Unknown,
        Unspecified
    }
}