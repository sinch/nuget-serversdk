using Sinch.ServerSdk.Models;
public class TTSCalloutRequest : ITTSCalloutRequest
{
    public string cli { get; set; }
    public IdentityModel destination { get; set; }
    public string domain { get; set; }
    public string custom { get; set; }
    public string locale { get; set; }
    public string text { get; set; }
    public string prompts { get; set; }
    public bool enableDice { get; set; }
    public bool enableAce { get; set; }
    public bool enablePie { get; set; }
    public ITTSCalloutRequest Addropmpt(string promptName)
    {
        this.prompts += ";" + promptName;
        return this;

    }
    public ITTSCalloutRequest AddText(string text)
    {
        this.prompts += ";" + text;
        return this;

    }
}
