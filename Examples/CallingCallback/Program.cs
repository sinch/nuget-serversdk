using System;
using System.IO;
using Sinch.ServerSdk.Calling;
using Sinch.ServerSdk.Calling.Callbacks.Request;
using Sinch.ServerSdk.Calling.Callbacks.Response;

namespace Sinch.ServerSdk.Examples.CallingCallback
{
    class Program
    {
        static void Main(string[] args)
        {
            var iceRequestText = File.ReadAllText("../../ice.txt");

            var sinch = new SinchFactory(new Locale("en-US"));

            var evt = sinch.CreateEventReader().ReadJson(iceRequestText);

            if (evt is IIceEvent)
            {
                var iceEvent = evt as IIceEvent;
                Console.WriteLine("Ice Event");
                Console.WriteLine("From: " + iceEvent.Cli);
                Console.WriteLine("To: " + iceEvent.To.Endpoint);

                var resoponse = sinch.CreateIceSvamletBuilder();

                var iceResponseText =
                    resoponse
                        .AddNumberInputMenu("ipt", new TtsPrompt("Hello!"), 4)
                        .RunMenu("ipt").Body;
            }
        }
    }
}