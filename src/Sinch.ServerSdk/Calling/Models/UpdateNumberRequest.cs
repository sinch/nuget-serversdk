namespace Sinch.ServerSdk.Calling
{
    public partial class UpdateNumberRequest
    {
        public string[] Numbers { get; set; }
        public string ApplicationKey { get; set; }
        public Capabilities Capability { get; set; }
    }
}