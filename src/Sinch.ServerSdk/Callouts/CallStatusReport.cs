namespace Sinch.ServerSdk.Callouts
{
    public class CallStatusReport
    {
        public CallStatus Status { get; set; }
        public string Details { get; set; }

        public CallStatusReport(CallStatus status) : this(status, null) { }

        public CallStatusReport(CallStatus status, string details)
        {
            Status = status;
            Details = details;
        }
    }
}