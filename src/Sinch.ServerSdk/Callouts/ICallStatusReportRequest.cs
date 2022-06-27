using System.Threading.Tasks;

namespace Sinch.ServerSdk.Callouts
{
    public interface ICallStatusReportRequest
    {
        Task Call();
    }
}