using System.ClientModel;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

using OpenAI;

IConfigurationRoot config = new ConfigurationBuilder()
    //.AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

ChatConfig chatConfig = new(
    config["CHAT_KEY"] ?? throw new InvalidOperationException("Missing configuration: CHAT_KEY."),
    config["CHAT_URI"] ?? throw new InvalidOperationException("Missing configuration: CHAT_URI."),
    config["CHAT_MODEL"] ?? throw new InvalidOperationException("Missing configuration: CHAT_MODEL.")
);

ApiKeyCredential credential = new(chatConfig.Key);
OpenAIClientOptions openAIOptions = new()
{
    Endpoint = new Uri(chatConfig.Uri)
};
IChatClient client = new OpenAIClient(credential, openAIOptions).GetChatClient(chatConfig.Model).AsIChatClient();

string prompt = "What is the capital of Japan?";
string response = "";
await foreach (ChatResponseUpdate item in client.GetStreamingResponseAsync(prompt))
{
    Console.Write(item.Text);
    response += item.Text;
}
