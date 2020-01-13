using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Callouts
{
    /// <summary>
    /// Defines callout destination
    /// </summary>
    public sealed class To
    {
        public string Type { get; }

        public string Domain { get; }

        private string Endpoint { get; }

        private To(string type, string domain, string endpoint)
        {
            Type = type;
            Domain = domain;
            Endpoint = endpoint;
        }

        /// <summary>
        /// Get PSTN callout destination
        /// </summary>
        /// <param name="number">Valid phone number</param>
        /// <returns>PSTN destination</returns>
        public static To Number(string number)
        {
            return new To("number", "pstn", number);
        }

        /// <summary>
        /// Get data endpoint destination
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>MXP destination</returns>
        public static To Username(string username)
        {
            return new To("username", "mxp", username);
        }

        internal IdentityModel ToIdentity()
        {
            return new IdentityModel { Type = Type, Endpoint = Endpoint };
        }
    }
}
