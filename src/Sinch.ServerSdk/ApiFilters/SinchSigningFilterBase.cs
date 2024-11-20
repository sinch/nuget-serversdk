using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sinch.WebApiClient;

namespace Sinch.ServerSdk.ApiFilters
{
    internal abstract class SinchSigningFilterBase : IActionFilter
    {
        public abstract Task OnActionExecuting(HttpRequestMessage requestMessage);

        public async Task OnActionExecuted(HttpResponseMessage responseMessage)
        {
            if (responseMessage.StatusCode != HttpStatusCode.OK &&
                responseMessage.StatusCode != HttpStatusCode.NoContent)
            {
                var value = await responseMessage.Content.ReadAsStringAsync();
                ApiError error;
                try
                {
                    error = JsonConvert.DeserializeObject<ApiError>(value) ??
                            new ApiError { ErrorCode = (int)responseMessage.StatusCode, Message = "Unable to deserialize exception (because it seems to be empty): " + value };
                }
                catch (JsonSerializationException)
                {
                    error = new ApiError { ErrorCode = (int)responseMessage.StatusCode, Message = "Unable to deserialize exception: " + value };
                }

                throw new ApiException(error);
            }
        }
    }
}