using System.Net.Http;
using System.Threading.Tasks;

namespace Sinch.ServerSdk.WebApiClient
{
    public interface IActionFilter
    {
        Task OnActionExecuting(HttpRequestMessage requestMessage);
        Task OnActionExecuted(HttpResponseMessage responseMessage);
    }
}