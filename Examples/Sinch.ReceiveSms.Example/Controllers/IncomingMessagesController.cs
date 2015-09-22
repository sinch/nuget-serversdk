using System.Web.Http;
using Sinch.ServerSdk.Messaging.Models;

namespace Sinch.ReceiveSms.Example.Controllers
{
    public class IncomingMessagesController : ApiController
    {
        // POST: api/IncomingMessages
        public void Post([FromBody]IncomingMessageEvent value)
        {
            // Do something with the SMS here, eg:
            //LogToFile($"{value.From} wrote: {value.Message}");
        }
    }
}