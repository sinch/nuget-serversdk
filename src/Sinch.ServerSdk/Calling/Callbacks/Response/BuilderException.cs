using System;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public class BuilderException : Exception
    {
        internal BuilderException(string message) : base(message)
        {
        }
    }
}
