
public class ChatConfig
{
    public ChatConfig(string key, string uri, string model)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Uri = uri ?? throw new ArgumentNullException(nameof(uri));
        Model = model ?? throw new ArgumentNullException(nameof(model));
    }

    public string Key { get; set; }
    public string Uri { get; set; }
    public string Model { get; set; }
}
