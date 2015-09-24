namespace Sinch.ServerSdk.Calling.Fluent
{
    class ConferenceApi : IConferenceApi
    {
        private readonly IConferenceApiEndpoints _api;

        public ConferenceApi(IConferenceApiEndpoints api)
        {
            _api = api;
        }

        public IConference Conference(string conferenceId)
        {
            return new Conference(_api, conferenceId);
        }
    }
}