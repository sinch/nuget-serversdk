using System;
using System.Threading.Tasks;
using Sinch.ServerSdk;
using Sinch.ServerSdk.IvrMenus;

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
            IMenuBuilder menuBuilder = calloutApi.CreateMenuBuilder();
            menuBuilder.AddNumberInputMenu("main", "This is a test call from Azure MFA. Please enter the following digits: 1 7 8 9. Press 'pound' if the digits were unclear.", 4,
                   "This is a test call from Azure MFA. Please enter the following digits: 1 7 8 9. Press 'pound' if the digits were unclear.", 1, TimeSpan.FromSeconds(15));
            //var calloutResponse = await calloutApi.MenuCallout("+15612600684", "how are you doing", menuBuilder,  "main", TimeSpan.FromSeconds(25),"www1545654").Call();
            var calloutResponse = await calloutApi.ConferenceCallout("+17207072699", "asdfsadfsdf", "11111", "hi command", "ww951197111#").Call();

            Console.WriteLine(calloutResponse.callId);
            Console.ReadLine();
        }
    }
}