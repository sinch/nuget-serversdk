namespace Sinch.ServerSdk.Calling
{
    public class NumbersResponse
    {
        public Numbers[] numbers {get;set;}

    }
    public class Numbers
    {
        public string Number { get; set; }
        public Capabilities Capability { get; set; }

        public string ApplicationKey { get; set; }
    }
}