using System.Threading.Tasks;
using Sinch.ServerSdk.ApiFilters;

namespace Sinch.ServerSdk.Callouts
{
    internal class CallStatusReportRequest : ICallStatusReportRequest
    {
        private readonly ICalloutApiEndpoints _endpoints;
        private readonly string _callId;
        private readonly CallStatusReportModel _callStatusReport;

        public CallStatusReportRequest(ICalloutApiEndpoints endpoints, string callId, CallStatusReportModel callStatusReport)
        {
            _endpoints = endpoints;
            _callId = callId;
            _callStatusReport = callStatusReport;
        }

        public async Task Call()
        {
            try
            {
                await _endpoints.ReportCallStatus(_callId, _callStatusReport);
            }
            catch (ApiException e) when(e.Error?.ErrorCode == 201)
            {
                // do nothing!
            }
        }
    }
}