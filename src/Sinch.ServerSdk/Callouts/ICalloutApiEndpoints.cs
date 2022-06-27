using System.Threading.Tasks;
using Sinch.ServerSdk.Callouts;
using Sinch.WebApiClient;

public interface ICalloutApiEndpoints
{
    [HttpPost("calling/v1/callouts")]
    Task<CalloutResponse> Callout([ToBody] CalloutRequest request);

    [HttpPost("calling/v1/callreport/callId/{callId}")]
    Task ReportCallStatus([ToUri] string callId, [ToBody] CallStatusReportModel report);
}