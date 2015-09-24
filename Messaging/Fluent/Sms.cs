using System.Linq;
using System.Threading.Tasks;
using Sinch.ServerSdk.Exceptions;
using Sinch.ServerSdk.Messaging.Models;

namespace Sinch.ServerSdk.Messaging.Fluent
{
    class Sms : ISms
    {
        private readonly ISmsApiEndpoints _smsApiEndpoints;
        private readonly string _to;
        private string _from;
        private readonly string _message;

        public Sms(ISmsApiEndpoints smsApiEndpoints, string to, string message)
        {
            _smsApiEndpoints = smsApiEndpoints;

            if (string.IsNullOrWhiteSpace(to))
                throw new BadRequestException("Cannot specify empty 'to'.");

            if (string.IsNullOrWhiteSpace(message))
                throw new BadRequestException("Cannot specify empty message.");

            if (!to.Trim().StartsWith("+"))
                throw new BadRequestException("'to' must be in international format. Phone number should start with a '+'");

            if (to.Length < 7)
                throw new BadRequestException("Phone number too short");

            if (to.Length > 17)
                throw new BadRequestException("Phone number too long");

            if (to.Substring(1).Any(c => !char.IsDigit(c)))
                throw new BadRequestException("Phone numbers should only have digits after '+'");

            _to = to.Trim();
            _message = message.Trim();
        }

        public ISmsSend WithCli(string from)
        {
            if (string.IsNullOrWhiteSpace(from))
                throw new BadRequestException("Cannot specify empty CLI.");

            if (_from != null)
                throw new BadRequestException("CLI has already been set.");

            _from = from.Trim();
            return this;
        }

        public async Task<ISendSmsResponse> Send()
        {
            return await _smsApiEndpoints.SendSms(_to, new SendSmsRequest { Message = _message, From = _from }).ConfigureAwait(false);
        }
    }
}