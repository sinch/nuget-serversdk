using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sinch.ServerSdk.ApiFilters
{
    internal class ApplicationSigningFilter : SinchSigningFilterBase
    {
        readonly string _key;
        readonly byte[] _secret;

        public ApplicationSigningFilter(string key, byte[] secret)
        {
            _key = key;
            _secret = secret;
        }

        public override async Task OnActionExecuting(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Add("x-timestamp", DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));

            var stringToSign = await BuildStringToSign(requestMessage);

            using (var sha = new HMACSHA256(_secret))
            {
                var signature = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                requestMessage.Headers.TryAddWithoutValidation("authorization", "application " + _key + ":" + signature);
            }
        }

        static async Task<string> BuildStringToSign(HttpRequestMessage request)
        {
            var sb = new StringBuilder();

            AppendMethod(request, sb);
            await AppendBody(request, sb).ConfigureAwait(false);
            AppendContentType(request, sb);
            AppendSinchHeaders(request, sb);
            AppendPath(request, sb);

            return sb.ToString();
        }

        static void AppendPath(HttpRequestMessage request, StringBuilder sb)
        {
            sb.Append(request.RequestUri.AbsolutePath);
        }

        static void AppendSinchHeaders(HttpRequestMessage request, StringBuilder sb)
        {
            sb.Append("x-timestamp:");
            sb.Append(request.Headers.GetValues("x-timestamp").First());
            sb.Append("\n");
        }

        static void AppendContentType(HttpRequestMessage request, StringBuilder sb)
        {
            if (request.Content != null)
                sb.Append(request.Content.Headers.ContentType);
            sb.Append("\n");
        }

        static async Task AppendBody(HttpRequestMessage request, StringBuilder sb)
        {
            if (request.Content != null)
            {
                using (var md5 = MD5.Create())
                {
                    sb.Append(Convert.ToBase64String(md5.ComputeHash(await request.Content.ReadAsByteArrayAsync().ConfigureAwait(false))));
                }
            }

            sb.Append("\n");
        }

        static void AppendMethod(HttpRequestMessage request, StringBuilder sb)
        {
            sb.Append(request.Method.Method);
            sb.Append("\n");
        }
    }

    public class ApiError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string Reference { get; set; }
    }
}