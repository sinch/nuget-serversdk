using System;

namespace Sinch.ServerSdk
{
    public class BuilderException : Exception
    {
        internal BuilderException(string message) : base(message)
        {
        }
    }
}
