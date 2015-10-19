using System;

namespace Sinch.ServerSdk.Exceptions
{
    /// <summary>
    /// Exception thrown when a request contains invalid or missing arguments. Check the <see cref="Exception.Message"/> for more details
    /// of what was wrong with the request
    /// </summary>
    public class BadRequestException : Exception
    {
        internal BadRequestException(string message) : base(message)
        {
        }
    }
}