namespace Sinch.Callback.Request
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