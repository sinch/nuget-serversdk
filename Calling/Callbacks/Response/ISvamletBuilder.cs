namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public interface ISvamletBuilder<out T>
    {
        T SetCookie(string name, string value);
        T Say(string text);
        T Play(string file);
        T SaySsml(string ssml);

        ISvamletResponse Hangup();
        ISvamletResponse Hangup(int hangupCause);
        ISvamletResponse Continue();

        ISvamletResponse Build();
    }
}