using System.Threading.Tasks;
using Sinch.ServerSdk.Calling.Models;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.Calling
{
    public interface IConferenceApiEndpoints
    {
        [HttpGet("/calling/v1/conferences/id/{conferenceId}")]
        Task<GetConferenceResponse> GetConference([ToUri] string conferenceId);

        // Should be:
        //"/calling/v1/conferences/id/{conferenceId}/participants/{participantId}"
        [HttpPatch("/calling/v1/conferences/id/{conferenceId}/{participantId}")]
        Task UpdateConference([ToUri] string conferenceId, [ToUri] string participantId, [ToBody] ConferenceCommand command);

        [HttpDelete("/calling/v1/conferences/id/{conferenceId}")]
        Task End([ToUri] string conferenceId);

        // Should be:
        //"/calling/v1/conferences/id/{conferenceId}/participants/{participantId}"
        [HttpDelete("/calling/v1/conferences/id/{conferenceId}/{participantId}")]
        Task KickParticipant([ToUri] string conferenceId, [ToUri] string participantId);
    }
}