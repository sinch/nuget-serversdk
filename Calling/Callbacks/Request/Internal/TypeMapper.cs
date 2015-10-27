using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class TypeMapper
    {
        internal static TypeMapper Singleton = new TypeMapper();
        private static readonly Regex CliParser = new Regex("\\A(?<fp>\\+?)(?<f1>[^<]+)(<\\+?(?<f2>[0-9]+)>)?");

        #region string mappers

        public bool TryParse(string s, out MenuResultType result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = MenuResultType.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "error":
                    result = MenuResultType.Error;
                    break;
                case "return":
                    result = MenuResultType.Return;
                    break;
                case "timeout":
                    result = MenuResultType.Timeout;
                    break;
                case "hangup":
                    result = MenuResultType.Hangup;
                    break;
                case "invalidinput":
                    result = MenuResultType.InvalidInput;
                    break;
                case "sequence":
                    result = MenuResultType.Sequence;
                    break;
                default:
                    result = MenuResultType.Unknown;
                    break;
            }

            return true;
        }

        public bool TryParse(string s, out DateTime result)
        {
            return DateTime.TryParse(s, out result);
        }

        public bool TryParse(string s, out ICli result)
        {
            if(!string.IsNullOrEmpty(s))
            { 
                // Format: "name <number>"
                // f1 = name and f2 = number

                // Format: "number"
                // f1 = number, f2 not matched
                var fields = CliParser.Match(s);

                var f1 = fields.Groups["f1"].Success ? fields.Groups["f1"].Value.TrimEnd() : string.Empty;
                var f2 = fields.Groups["f2"].Success ? fields.Groups["f2"].Value : string.Empty;
                var fp = fields.Groups["fp"].Success ? fields.Groups["fp"].Value : string.Empty;

                if (f2.Length > 0)
                {
                    result = new Cli
                    {
                        AlphaNumeric = fp + f1,
                        Numeric = "+" + f2,
                        Full = fp + f1 + " <+" + f2 + ">",
                        Mode = CliMode.Full
                    };

                    return true;
                }

                if (f1.Length > 0)
                {
                    if (f1.Any(c => !char.IsDigit(c)))
                    {
                        result = new Cli
                        {
                            AlphaNumeric = fp + f1,
                            Numeric = string.Empty,
                            Full = fp + f1,
                            Mode = CliMode.AlphaNumeric
                        };

                        return true;
                    }

                    result = new Cli
                    {
                        AlphaNumeric = string.Empty,
                        Numeric = "+" + f1,
                        Full = "+" + f1,
                        Mode = CliMode.Numeric
                    };

                    return true;
                }
            }

            result = new Cli { Mode = CliMode.Hidden };
            return true;
        }

        public bool TryParse(string s, out OriginationType result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = OriginationType.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "mxp":
                    result = OriginationType.Mxp;
                    break;
                case "pstn":
                    result = OriginationType.Pstn;
                    break;
                case "server":
                    result = OriginationType.Server;
                    break;
                default:
                    result = OriginationType.Unknown;
                    break;
            }

            return true;
        }

        public bool TryParse(string s, out EndpointType result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = EndpointType.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "number":
                    result = EndpointType.PstnNumber;
                    break;
                case "username":
                    result = EndpointType.Username;
                    break;
                case "email":
                    result = EndpointType.Email;
                    break;
                default:
                    result = EndpointType.Unknown;
                    break;
            }

            return true;
        }

        public bool TryParse(string s, out Event result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = Event.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "ice":
                    result = Event.IncomingCall;
                    break;
                case "dice":
                    result = Event.DisconnectedCall;
                    break;
                case "ace":
                    result = Event.AnsweredCall;
                    break;
                case "pie":
                    result = Event.PromptInput;
                    break;
                case "notify":
                    result = Event.Notification;
                    break;
                default:
                    result = Event.Unknown;
                    break;
            }

            return true;
        }


        public bool TryParse(string s, out Reason result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = Reason.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "callerhangup":
                    result = Reason.CallerHangup;
                    break;
                case "calleehangup":
                    result = Reason.CalleeHangup;
                    break;
                case "managerhangup":
                    result = Reason.ManagerHangup;
                    break;
                case "timeout":
                    result = Reason.Timeout;
                    break;
                case "generalerror":
                    result = Reason.Error;
                    break;
                case "n/a":
                    result = Reason.NotApplicable;
                    break;
                default:
                    result = Reason.Unknown;
                    break;
            }

            return true;
        }

        public bool TryParse(string s, out Result result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = Result.Unspecified;
                return true;
            }

            switch (s.ToLower())
            {
                case "answered":
                    result = Result.Answered;
                    break;
                case "denied":
                case "busy":
                    result = Result.Busy;
                    break;
                case "cancel":
                    result = Result.Canceled;
                    break;
                case "noanswer":
                    result = Result.NoAnswer;
                    break;
                case "failed":
                    result = Result.Failed;
                    break;
                case "n/a":
                    result = Result.NotApplicable;
                    break;
                default:
                    result = Result.Unknown;
                    break;
            }

            return true;
        }

        #endregion

        #region int mappers

        public bool TryConvert(int i, out TimeSpan result)
        {
            result = TimeSpan.FromSeconds(i);
            return true;
        }

        #endregion

        #region model mappers

        public bool TryConvert(IdentityModel o, out IIdentity result)
        {
            result = null;

            if (o == null)
                return false;

            EndpointType type;

            if (TryParse(o.Type, out type))
            {
                result = new Identity
                {
                    Endpoint = o.Endpoint,
                    Type = type
                };

                return true;
            }

            return false;
        }

        public bool TryConvert(MoneyModel o, out IMoney result)
        {
            result = null;

            if (o == null)
                return false;

            result = new Money
            {
                Amount = o.Amount,
                CurrencyId = o.CurrencyId
            };

            return true;
        }

        public bool TryConvert(KeyValueModel[] o, out IDictionary<string, string> result)
        {
            result = null;

            if (o == null)
                return false;

            result =o.ToDictionary(c => c.Key, c => c.Value);
            return true;
        }

        public bool TryConvert(MenuResultModel o, out IMenuResult result)
        {
            result = null;

            if (o == null)
                return false;

            MenuResultType type;

            if (TryParse(o.Type, out type))
            {
                result = new MenuResult
                {
                    Type = type,
                    Value = o.Value
                };

                return true;
            }

            return false;
        }

        public bool TryConvert(IIdentity o, out IdentityModel result)
        {
            result = new IdentityModel
            {
                Endpoint = o.Endpoint,
                Type = AsString(o.Type)
            };

            return true;
        }

        public string AsString(Dtmf digit)
        {
            var intValue = (int) digit;

            switch (digit)
            {
                case Dtmf.Asterisk:
                    return "*";
                case Dtmf.Hash:
                    return "#";
                default:
                    return intValue.ToString(CultureInfo.InvariantCulture);
            }
        }

        private static string AsString(EndpointType type)
        {
            switch (type)
            {
                case EndpointType.Email:
                    return "email";
                    case EndpointType.PstnNumber:
                    return "number";
                    case EndpointType.Username:
                    return "username";
                default:
                    return "username";
            }
        }

        #endregion
    }
}