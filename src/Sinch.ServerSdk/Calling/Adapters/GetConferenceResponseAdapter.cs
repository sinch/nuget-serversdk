using Sinch.ServerSdk.Calling.Models;
using System.Linq;

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

        public IParticipant[] Participants => _participants ??
                                              (_participants = _getConferenceResponse.Participants.Cast<IParticipant>().ToArray());
    }
}
