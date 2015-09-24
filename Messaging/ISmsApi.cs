using System.Threading.Tasks;

namespace Sinch.ServerSdk.Messaging
{
    public interface ISmsApi
    {
        ISms Sms(string to, string message);
        Task<IGetStatusResponse> GetSmsStatus(int messageId);
    }
}