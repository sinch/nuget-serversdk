using System.Threading.Tasks;
using System.Web.Http;
using Sinch.ServerSdk.Callback.WebApi;
using Sinch.ServerSdk.Verification.Models;

namespace Sinch.Verification.Callback.Example.Controllers
{
    [SinchCallback]
    public class VerificationController : ApiController
    {
        // POST: api/verification/request
        [Route("request")]
        public async Task<VerificationRequestEventResponse> Post([FromBody] VerificationRequestEvent request)
        {
            // Let us know what to do with this verification request. Possible actions are "allow" or "deny".

            return new VerificationRequestEventResponse { Action = "deny" };
        }

        // POST: api/verification/result
        [Route("result")]
        public async Task Post([FromBody] VerificationResultEvent result)
        {
            // The verification has been processed and here's the result...
        }
    }
}