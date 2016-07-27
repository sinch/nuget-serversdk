using System.Threading.Tasks;
using System.Web.Http;
using Sinch.ServerSdk.Callback.WebApi;
using Sinch.ServerSdk.Verification.Models;
using System;
using Newtonsoft.Json;

#pragma warning disable 1998

namespace Sinch.Verification.Callback.Example.Controllers
{
    [SinchCallback]
    public class VerificationController : ApiController
    {
        [Route]
        public async Task<VerificationRequestEventResponse> Post()
        {
            //based on this example, the value for your application callback url should be {server address}/api/verification

            string jsonContent = await Request.Content.ReadAsStringAsync();

            if (jsonContent.Contains("VerificationRequestEvent"))
            {
                VerificationRequestEvent request = JsonConvert.DeserializeObject<VerificationRequestEvent>(jsonContent);

                bool isValid = true;

                //do w/e do decide if the request is allowed

                return new VerificationRequestEventResponse { Action = isValid ? "allow" : "deny" };
            }
            else if (jsonContent.Contains("VerificationResultEvent"))
            {
                VerificationResultEvent result = JsonConvert.DeserializeObject<VerificationResultEvent>(jsonContent);

                //code for dealing with result of Verification

                return null;
            }
            else
            {
                throw new NotImplementedException("Unknown event type!");
            }
        }
    }
}