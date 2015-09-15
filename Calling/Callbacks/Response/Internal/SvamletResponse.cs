using System.IO;
using Newtonsoft.Json;
using Sinch.ServerSdk.Calling.Callbacks.Response;
using Sinch.ServerSdk.Calling.Model;

namespace Sinch.Callback.Response.Internal
{
    internal class SvamletResponse : ISvamletResponse
    {
        private string _json;

        private void Render()
        {
            if (_json == null)
            {
                var sw = new StringWriter();
                new JsonSerializer().Serialize(sw, Model);
                _json = sw.ToString();
            }
        }

        public string ContentType
        {
            get
            {
                Render();
                return "application/json";
            }
        }

        public int ContentLength
        {
            get
            {
                Render();
                return _json.Length;
            }
        }

        public string Body
        {
            get
            {
                Render();
                return _json;
            }
        }

        public SvamletModel Model
        {
            get; set;
        }
    }
}
