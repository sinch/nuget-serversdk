using System;

namespace Sinch.ServerSdk.ApiFilters
{
    public class ApiException : Exception
    {
        public ApiException(ApiError apiError)
            : base(apiError.ErrorCode + ": " + apiError.Message)
        {
            Error = apiError;
        }

        public ApiError Error { get; }
    }
}