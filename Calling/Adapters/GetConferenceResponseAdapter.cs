using Castle.Core.Internal;
using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Adapters
{
    internal class GetConferenceResponseAdapter : IGetConferenceResponse
    {
        private readonly GetConferenceResponse _getConferenceResponse;
        private IParticipant[] _participants;

        public GetConferenceResponseAdapter(GetConferenceResponse getConferenceResponse)
        {
            _getConferenceResponse = getConferenceResponse;
        }

        public IParticipant[] Participants
        {
            get
            {
                return _participants ??
                       (_participants = _getConferenceResponse.Participants.ConvertAll(p => (IParticipant) p));
            }
        }
    }
}
