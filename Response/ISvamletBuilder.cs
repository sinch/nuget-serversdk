namespace Sinch.Callback.Response
{
    public interface ISvamletBuilder<out T>
    {
        T SetCookie(string name, string value);
        T Say(string text);
        T Play(string file);

        ISvamletResponse Hangup();
        ISvamletResponse Continue();

        ISvamletResponse Build();
    }
}