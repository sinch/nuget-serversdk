using System.Threading.Tasks;

namespace Sinch.ServerSdk.Callouts
{
    public interface ICalloutRequest
    {
        string Method { get; set; }

        IConferenceCalloutRequest ConferenceCallout { get; set; }
        ITtsCalloutRequest TtsCallout { get; set; }
        ICustomCalloutCalloutRequest CustomCallout { get; set; }
        
        Task<CalloutResponse> Call();

    }
}