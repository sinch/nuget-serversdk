namespace Sinch.ServerSdk.Calling
{
    public interface IConferenceApi
    {
        IConference Conference(string conferenceid);
    }

    class ConferenceApi : IConferenceApi
    {
        private readonly IConferenceApiEndpoints _api;

        public ConferenceApi(IConferenceApiEndpoints api)
        {
            _api = api;
        }

        public IConference Conference(string conferenceid)
        {
            return new Conference(_api, conferenceid);
        }
    }
}