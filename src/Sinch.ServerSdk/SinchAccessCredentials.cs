using System;

namespace Sinch.ServerSdk
{
    /// <summary>
    /// Sinch project credentials
    /// </summary>
    public class SinchAccessCredentials
    {
        /// <summary>
        /// Project access key ID
        /// </summary>
        public readonly string AccessKeyId;

        /// <summary>
        /// Project key secret
        /// </summary>
        public readonly string KeySecret;

        /// <summary>
        /// Application identifier to be associated with the requests
        /// </summary>
        public readonly string ApplicationKey;

        public SinchAccessCredentials(string accessKeyId, string keySecret, string applicationKey)
        {
            if (accessKeyId == null)
                throw new ArgumentNullException(nameof(accessKeyId));

            if (string.Empty.Equals(accessKeyId))
                throw new ArgumentException($"{nameof(accessKeyId)} must be a non-empty string", nameof(accessKeyId));

            if (keySecret == null)
                throw new ArgumentNullException(nameof(keySecret));

            if (string.Empty.Equals(keySecret))
                throw new ArgumentException($"{nameof(keySecret)} must be a non-empty string", nameof(keySecret));

            if (applicationKey == null)
                throw new ArgumentNullException(nameof(applicationKey));

            if (string.Empty.Equals(applicationKey))
                throw new ArgumentException($"{nameof(applicationKey)} must be a non-empty string", nameof(applicationKey));

            AccessKeyId = accessKeyId;
            KeySecret = keySecret;
            ApplicationKey = applicationKey;
        }

        public static SinchAccessCredentials Create(string accessKeyId, string keySecret, string applicationKey) =>
            new SinchAccessCredentials(accessKeyId, keySecret, applicationKey);
    }
}