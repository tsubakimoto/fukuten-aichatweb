using System.ClientModel;

using Microsoft.Extensions.AI;

using OpenAI;

string key = Environment.GetEnvironmentVariable("CHAT_KEY")
    ?? throw new InvalidOperationException("Missing configuration: CHAT_KEY.");
ApiKeyCredential credential = new(key);
OpenAIClientOptions openAIOptions = new OpenAIClientOptions()
{
    Endpoint = new Uri(Environment.GetEnvironmentVariable("CHAT_URI"))
};

string deployment = Environment.GetEnvironmentVariable("CHAT_MODEL")
    ?? throw new InvalidOperationException("Missing configuration: CHAT_MODEL.");
IChatClient client = new OpenAIClient(credential, openAIOptions).GetChatClient(deployment).AsIChatClient();

string prompt = "What is the capital of Japan?";
string response = "";
await foreach (ChatResponseUpdate item in client.GetStreamingResponseAsync(prompt))
{
    Console.Write(item.Text);
    response += item.Text;
}
