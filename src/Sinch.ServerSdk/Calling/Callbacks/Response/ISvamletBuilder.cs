namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public enum HangupCause
    {
        Normal        = 0,
        Busy        = 1,
        Congestion  = 2,
    }

    public interface ISvamletBuilder<out T>
    {
        T SetCookie(string name, string value);
        T Say(string text);
        T Play(string file);
        T SaySsml(string ssml);

        ISvamletResponse Hangup();
        ISvamletResponse Hangup(HangupCause cause);
        ISvamletResponse Continue();

        ISvamletResponse Build();
    }
}