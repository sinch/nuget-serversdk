using System;
using System.Linq;
using System.Threading.Tasks;
using Sinch.ServerSdk.Exceptions;
using Sinch.ServerSdk.Models;
using Sinch.ServerSdk.Verification.Adapters;
using Sinch.ServerSdk.Verification.Models;

namespace Sinch.ServerSdk.Verification.Fluent
{
    public class Verification : IVerification
    {
        private readonly IVerificationApiEndpoints _api;
        private readonly IdentityModel _identity;

        private string _id;
        private string _reference;
        private string _custom;
        private string _cli;
        private string _code;

        internal Verification(IVerificationApiEndpoints api) : this(api, null)
        {
        }
        internal Verification(IVerificationApiEndpoints api, IdentityModel identity)
        {
            _api = api;
            _identity = identity;
        }

        public async Task<IInitiateVerificationResponse> Initiate(VerificationMethod method)
        {
            ValidateIdentity();

            var request = new InitiateVerificationRequest
            {
                Identity = _identity,
                Method = ToString(method),
                Reference = _reference,
                Custom = _custom,
            };

            return new InitiateVerificationResponseAdapter(await _api.InitiateVerification(request).ConfigureAwait(false));
        }
        public async Task<IReportVerificationResponse> Report(VerificationMethod method)
        {
            ValidateIdentity();

            var request = new ReportVerificationRequest { Method = ToString(method) };

            switch( method )
            {
                case VerificationMethod.FlashCall:
                case VerificationMethod.Callout:
                    if (string.IsNullOrWhiteSpace(_cli))
                        throw new BadRequestException("Cli cannot be empty");

                    request.FlashCall = new FlashCallVerificationReportData { Cli = _cli };
                    break;
                case VerificationMethod.Sms:
                    if (string.IsNullOrWhiteSpace(_code))
                        throw new BadRequestException("Code cannot be empty");

                    request.Sms = new SmsVerificationReportData { Code = _code, Cli = _cli };
                    break;
            }

            return await _api.ReportVerification(_identity, request).ConfigureAwait(false);
        }
        public async Task<IVerificationResultResponse> Get()
        {
            if (!string.IsNullOrWhiteSpace(_id))
                return await _api.GetVerificationById(_id).ConfigureAwait(false);

            if (!string.IsNullOrWhiteSpace(_reference))
                return await _api.GetVerificationByReference(_reference).ConfigureAwait(false);

            ValidateIdentity();

            return await _api.GetVerification(_identity).ConfigureAwait(false);
        }


        public IVerification WithReference(string reference)
        {
            _reference = reference?.Trim();
            return this;
        }
        public IVerification WithCustom(string custom)
        {
            _custom = custom?.Trim();
            return this;
        }
        public IVerification WithCli(string cli)
        {
            if (string.IsNullOrWhiteSpace(cli))
                throw new BadRequestException("Cli cannot be empty");

            _cli = cli.Trim();
            return this;
        }
        public IVerification WithCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new BadRequestException("Code cannot be empty");

            _code = code.Trim();
            return this;
        }
        public IVerification WithId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new BadRequestException("Id cannot be empty");

            _id = id.Trim();
            return this;
        }


        private void ValidateIdentity()
        {
            if (_identity == null)
                throw new BadRequestException("Invalid identity. Cannot be null");

            if (string.IsNullOrWhiteSpace(_identity.Endpoint))
                throw new BadRequestException("Invalid identity. Number cannot be empty");

            if (!_identity.Endpoint.Trim().StartsWith("+"))
                throw new BadRequestException("Invalid identity. Number must be in international format (should start with a '+')");

            if (_identity.Endpoint.Length < 7)
                throw new BadRequestException("Invalid identity. Number too short");

            if (_identity.Endpoint.Length > 17)
                throw new BadRequestException("Invalid identity. Number too long");

            if (_identity.Endpoint.Substring(1).Any(c => !char.IsDigit(c)))
                throw new BadRequestException("Invalid identity. Phone numbers should only have digits after '+'");
        }

        private string ToString(VerificationMethod method)
        {
            switch( method )
            {
                case VerificationMethod.FlashCall:
                    return "flashCall";
                case VerificationMethod.Sms:
                    return "sms";
                case VerificationMethod.Callout:
                    return "callout";
            }

            throw new ArgumentException("Unsupported verification method: " + method);
        }
    }
}
