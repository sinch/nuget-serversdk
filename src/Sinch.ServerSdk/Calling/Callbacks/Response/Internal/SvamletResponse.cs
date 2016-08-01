using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class SvamletResponse : ISvamletResponse
    {
        private string _json;

        private void Render()
        {
            if (_json == null)
                _json = Model.Serialize();
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
