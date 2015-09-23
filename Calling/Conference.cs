using System.Threading.Tasks;
using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling
{
    public interface IConference
    {
        Task<GetConferenceResponse> Get();
        Task End();
        IParticipant Participant(string id);
    }

    class Conference : IConference
    {
        private readonly IConferenceApiEndpoints _api;
        private readonly string _conferenceId;

        public Conference(IConferenceApiEndpoints api, string conferenceId)
        {
            _api = api;
            _conferenceId = conferenceId;
        }

        public Task<GetConferenceResponse> Get()
        {
            return _api.GetConference(_conferenceId);
        }

        public Task End()
        {
            return _api.End(_conferenceId);
        }

        public IParticipant Participant(string id)
        {
            return new Participant(_api, _conferenceId, id);
        }
    }
}