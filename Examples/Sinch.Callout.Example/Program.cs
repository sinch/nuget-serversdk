using System;
using System.Threading.Tasks;
using Sinch.ServerSdk;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Callouts;
using Sinch.ServerSdk.IvrMenus;

namespace Sinch.Callout.Example
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

            // TTS callout
            var calloutResponse = await calloutApi.TtsCallout("+15612600684", "How are you doing?", "").Call();
            
            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();

            // Conference callout
            calloutResponse = await calloutApi.ConferenceCallout(To.Username("Buddy"), "ConfId-123", "", "Welcome!").Call();

            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();

            // Menu callout
            var menu = calloutApi.CreateMenuBuilder()
                .BeginMenuDefinition("main", new PromptFile("press1forinput_press2forexit"), null)
                    .AddGotoMenuOption(Dtmf.Digit1, "input")
                    .AddTriggerPieOption(Dtmf.Digit2, "exit")
                .EndMenuDefinition()
                .AddNumberInputMenu("input", new PromptFile("enterprompt"), 4);


            calloutResponse = await calloutApi.MenuCallout("+15612600684", "+15612600684", menu, "main", TimeSpan.FromSeconds(5)).Call();

            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();
        }
    }
}