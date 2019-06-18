namespace Sinch.ServerSdk.Calling.Models
{
    public sealed class CallTag
    {
        public static CallTag DefaultBillingTag = new CallTag("BillingTag");

        private readonly string _tagName;

        private CallTag(string tagName)
        {
            _tagName = tagName;
        }

        public static implicit operator string(CallTag tag) => tag._tagName;
        public static implicit operator CallTag(string tagName) => new CallTag(tagName);

        public static CallTag Custom(string tagName) => tagName;
    }
}
