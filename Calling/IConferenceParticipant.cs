using System.Threading.Tasks;

namespace Sinch.ServerSdk.Calling
{
    public interface IConferenceParticipant
    {
        Task Mute();
        Task Unmute();
        Task Kick();
    }
}