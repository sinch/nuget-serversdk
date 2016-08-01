using System;

namespace Sinch.ServerSdk.Exceptions
{
    /// <summary>
    /// Exception thrown whena callback contains invalid information. This is usually related to a missing or invalid authorization header and/or
    /// incorrect signing of the callback request
    /// </summary>
    public class InvalidCallbackException : Exception
    {
        internal InvalidCallbackException(string message) : base(message)
        {

        }
    }
}