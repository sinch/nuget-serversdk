using System.Net.Http;
using System.Threading.Tasks;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.ApiFilters
{
    public class PublicFilter : IActionFilter
    {
        readonly string _key;
        readonly Task<bool> _successTask = Task.FromResult(true);

        public PublicFilter(string key)
        {
            _key = key;
        }

        public Task OnActionExecuting(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("authorization", "application " + _key);
            return _successTask;
        }

        public Task OnActionExecuted(HttpResponseMessage responseMessage)
        {
            return _successTask;
        }
    }
}