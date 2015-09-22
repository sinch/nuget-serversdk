using System;

namespace Sinch.ServerSdk.ApiFilters
{
    [Serializable]
    public class ApiException : Exception
    {
        readonly ApiError _apiError;

        public ApiException(ApiError apiError)
            : base(apiError.ErrorCode + ": " + apiError.Message)
        {
            _apiError = apiError;
        }

        public ApiError Error { get { return _apiError; } }
    }
}