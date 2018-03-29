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
            var calloutApi = SinchFactory.CreateApiFactory("f429b49c-4ca8-4b9a-9376-3c22428c5309", "ui8/g2EMaEieaPA5/1L+fQ==").CreateCalloutApi();
            var calloutResponse = await calloutApi.TtsCallout("+15612600684", "how are you doing", "").Call();
            
            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();
        }
    }
}