using System.IO;
using Newtonsoft.Json;
using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks
{
    public static class CallbackExtensions
    {
        public static string Serialize(this SvamletModel model)
        {
            var sw = new StringWriter();
            new JsonSerializer().Serialize(sw, model);
            return sw.ToString();
        }
    }
}
