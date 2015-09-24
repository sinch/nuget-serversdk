using System.Threading.Tasks;

namespace Sinch.ServerSdk.Messaging
{
    public interface ISms : ISmsSend, ISmsWithCli { }

    public interface ISmsSend
    {
        Task<ISendSmsResponse> Send();
    }

    public interface ISmsWithCli
    {
        ISmsSend WithCli(string from);
    }
}