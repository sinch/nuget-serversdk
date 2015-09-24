using System.Threading.Tasks;
using Sinch.ServerSdk.Calling.Adapters;

namespace Sinch.ServerSdk.Calling.Fluent
{
    class Conference : IConference
    {
        private readonly IConferenceApiEndpoints _api;
        private readonly string _conferenceId;

        public Conference(IConferenceApiEndpoints api, string conferenceId)
        {
            _api = api;
            _conferenceId = conferenceId;
        }

        public async Task<IGetConferenceResponse> Get()
        {
            return new GetConferenceResponseAdapter(await _api.GetConference(_conferenceId).ConfigureAwait(false));
        }

        public Task End()
        {
            return _api.End(_conferenceId);
        }

        public IConferenceParticipant Participant(string id)
        {
            return new ConferenceParticipant(_api, _conferenceId, id);
        }

        public IConferenceParticipant Participant(IParticipant participant)
        {
            return new ConferenceParticipant(_api, _conferenceId, participant.Id);
        }
    }
}