using System;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

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

        protected internal void AddCallTag(CallTag type, string value)
        {
            if (Model.Action.CallTags == null)
            {
                Model.Action.CallTags = new[] { new KeyValueModel { Key = type, Value = value } };

                return;
            }

            var newTags = new KeyValueModel[Model.Action.CallTags.Length + 1];
            Array.Copy(Model.Action.CallTags, newTags, Model.Action.CallTags.Length);
            newTags[newTags.Length - 1] = new KeyValueModel { Key = type, Value = value };

            Model.Action.CallTags = newTags;
        }
    }
}
