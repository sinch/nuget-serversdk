using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Sinch.ServerSdk.Exceptions;

namespace Sinch.ServerSdk.Callback
{
    public interface ICallbackValidator
    {
        void Validate(string absolutePath, Dictionary<string, string> headers, byte[] body);
    }

    class CallbackValidator : ICallbackValidator
    {
        private readonly string _key;
        private readonly byte[] _secret;

        public CallbackValidator(string key, byte[] secret)
        {
            _key = key;
            _secret = secret;
        }

        public void Validate(string absolutePath, Dictionary<string, string> headers, byte[] body)
        {
            if (!headers.ContainsKey("authorization") || !headers.ContainsKey("x-timestamp") || !headers.ContainsKey("content-type"))
                throw new InvalidCallbackException("Header missing.");

            string[] authorizationSplit = headers["authorization"].Split(' ', ':');
            if (authorizationSplit.Length != 3)
                throw new InvalidCallbackException("Invalid authorization.  Missing or too many authorization header values.");

            if(!authorizationSplit[0].Equals("application", StringComparison.OrdinalIgnoreCase))
                throw new InvalidCallbackException("Invalid authorization type.  Not 'application'");

            Guid appKeyGuid = ParseAppKey(_key);
            Guid headerAppKeyGuid = ParseAppKey(authorizationSplit[1]);

            if(!appKeyGuid.Equals(headerAppKeyGuid))
                throw new InvalidCallbackException("Invalid authorization.  Application key in request header is not recognised.");

            var callbackSignature = authorizationSplit[1];
            var signature = Convert.ToBase64String(new HMACSHA256(_secret).ComputeHash(Encoding.UTF8.GetBytes(BuildStringToSign(absolutePath, headers, body))));

            if (!signature.Equals(callbackSignature, StringComparison.Ordinal))
                throw new InvalidCallbackException("Invalid authorization.  Invalid signing.");
        }

        private static Guid ParseAppKey(string appKeyString)
        {
            Guid appKeyGuid;
            if(!Guid.TryParse(appKeyString, out appKeyGuid))
                throw new InvalidCallbackException("Invalid application key.");
            return appKeyGuid;
        }

        private static string BuildStringToSign(string absolutePath, IReadOnlyDictionary<string, string> headers, byte[] body)
        {
            var sb = new StringBuilder();

            AppendMethod(sb);
            AppendBody(sb, body);
            AppendContentType(sb, headers);
            AppendSinchHeaders(sb, headers);
            AppendPath(sb, absolutePath);

            return sb.ToString();
        }

        private static void AppendPath(StringBuilder sb, string absolutePath)
        {
            sb.Append(absolutePath);
        }

        private static void AppendSinchHeaders(StringBuilder sb, IReadOnlyDictionary<string, string> headers)
        {
            sb.Append("x-timestamp:");
            sb.Append(headers["x-timestamp"]);
            sb.Append("\n");
        }

        private static void AppendContentType(StringBuilder sb, IReadOnlyDictionary<string, string> headers)
        {
            sb.Append(headers["content-type"]);
            sb.Append("\n");
        }

        private static void AppendBody(StringBuilder sb, byte[] body)
        {
            if (body != null)
                sb.Append(Convert.ToBase64String(MD5.Create().ComputeHash(body)));

            sb.Append("\n");
        }

        private static void AppendMethod(StringBuilder sb)
        {
            sb.Append("POST");
            sb.Append("\n");
        }
    }
}