using System.Threading.Tasks;

namespace Sinch.ServerSdk.Calling
{
    public interface IConference
    {
        Task<IGetConferenceResponse> Get();
        Task End();
        IConferenceParticipant Participant(string id);
    }
}