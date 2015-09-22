using System;

namespace Sinch.ServerSdk.Exceptions
{
    public class InvalidCallbackException : Exception
    {
        public InvalidCallbackException(string message) : base(message)
        {

        }
    }
}