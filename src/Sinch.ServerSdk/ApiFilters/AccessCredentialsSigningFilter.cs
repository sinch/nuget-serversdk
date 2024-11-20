using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sinch.ServerSdk.ApiFilters
{
    internal class AccessCredentialsSigningFilter : SinchSigningFilterBase
    {
        private readonly AuthenticationHeaderValue _authHeader;
        private readonly string _applicationKey;

        public AccessCredentialsSigningFilter(SinchAccessCredentials credentials)
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            _applicationKey = credentials.ApplicationKey;

            _authHeader = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{credentials.AccessKeyId}:{credentials.KeySecret}")));
        }

        public override Task OnActionExecuting(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization = _authHeader;
            requestMessage.Headers.Add("X-Sinch-AuthType", "zap");
            requestMessage.Headers.Add("X-Sinch-ApplicationKey", _applicationKey);

            // net45 does not have Task.CompletedTask
            return Task.FromResult(false);
        }
    }
}