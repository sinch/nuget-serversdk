using System;
using System.Threading.Tasks;
using Sinch.ServerSdk;

namespace CalloutSample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var calloutApi = SinchFactory.CreateApiFactory("00000000-0000-0000-0000-000000000000", "AAAAAAAAAAAAAAAAAAAAAA==").CreateCalloutApi();
            var calloutResponse = await calloutApi.TTSCallout("+15612600684", "How are you doing?", "").Call();
            
            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();
        }
    }
}