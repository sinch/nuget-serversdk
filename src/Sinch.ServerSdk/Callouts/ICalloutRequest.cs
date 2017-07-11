using System.Threading.Tasks;

public interface ICalloutRequest
{
    IConferenceCalloutRequest conferenceCallout { get; set; }
    string method { get; set; }
    ITTSCalloutRequest ttsCallout { get; set; }
    Task<CalloutResponse> Call();

}