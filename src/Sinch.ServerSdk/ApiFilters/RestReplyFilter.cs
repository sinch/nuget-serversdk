using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.ApiFilters
{
    public class RestReplyFilter : IActionFilter
    {
        public Task OnActionExecuting(HttpRequestMessage requestMessage)
        {
            return Task.FromResult(true);
        }

        public async Task OnActionExecuted(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK &&
                responseMessage.StatusCode != HttpStatusCode.NoContent)
            {
                var body = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiError error;
                try
                {
                    error = JsonConvert.DeserializeObject<ApiError>(body) ??
                            new ApiError { ErrorCode = (int)responseMessage.StatusCode, Message = "Unable to deserialize exception (because it seems to be empty): " + body };
                }
                catch (JsonSerializationException)
                {
                    error = new ApiError { ErrorCode = (int)responseMessage.StatusCode, Message = "Unable to deserialize exception: " + body };
                }

                throw new ApiException(error);
            }
        }
    }
}