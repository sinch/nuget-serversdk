using System;
using System.Threading.Tasks;
using Sinch.ServerSdk;
using Sinch.ServerSdk.Verification;

namespace Sinch.Verification.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            try
            {
                var api = SinchFactory.CreateApiFactory("00000000-0000-0000-0000-000000000000", "AAAAAAAAAAAAAAAAAAAAAA==").CreateVerificationApi();

                var number = "+61491570156";
                var reference = Guid.NewGuid().ToString();
                var custom = Guid.NewGuid().ToString();

                // you must supply a number when initiating and reporting a verification
                var initiate = await api.Verification(number).WithReference(reference).WithCustom(custom).Initiate(VerificationMethod.FlashCall);

                Console.WriteLine($"Id: {initiate.Id}, Cli: {initiate.FlashCall.CliFilter}");

                // for a flashCall or callout verification the Cli is required. For sms its optional but the Code is required
                var report = await api.Verification(number).WithCli(initiate.FlashCall.CliFilter).Report(VerificationMethod.FlashCall);

                Console.WriteLine($"Status: {report.Status}, Reason: {report.Reason}");

                // you can get the result of a verification in the following ways:
                await api.Verification().WithId(initiate.Id).Get();
                await api.Verification().WithReference(reference).Get();
                var result = await api.Verification(number).Get();

                Console.WriteLine($"Status: {result.Status}, Reason: {result.Reason}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
