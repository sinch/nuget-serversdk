using System;

namespace Sinch.Callback.Response
{
    public class BuilderException : Exception
    {
        internal BuilderException(string message) : base(message)
        {
        }
    }
}
