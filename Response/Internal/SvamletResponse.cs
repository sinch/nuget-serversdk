using System.IO;
using Newtonsoft.Json;
using Sinch.Callback.Model;

namespace Sinch.Callback.Response.Internal
{
    internal class SvamletResponse : ISvamletResponse
    {
        private readonly Svamlet _model;
        private string _json;

        internal SvamletResponse(Svamlet model)
        {
            _model = model;
        }

        private void Render()
        {
            if (_json == null)
            {
                var sw = new StringWriter();
                new JsonSerializer().Serialize(sw, _model);
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

        public Svamlet Model
        {
            get { return _model; }
        }
    }
}
