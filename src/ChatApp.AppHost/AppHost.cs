using Aspire.Hosting.GitHub;

var builder = DistributedApplication.CreateBuilder(args);

// GitHub Models
var model = GitHubModel.OpenAI.OpenAIGpt4oMini;
var chat = builder.AddGitHubModel("chat", model);

// Azure Cosmos DB
#pragma warning disable ASPIRECOSMOSDB001
var cosmos = builder.AddAzureCosmosDB("cosmos-db").RunAsPreviewEmulator(emulator =>
{
    emulator.WithDataExplorer();
});
var db = cosmos.AddCosmosDatabase("db");
var container = db.AddContainer("chats", "/id");

// ChatApp Project
var web = builder.AddProject<Projects.ChatApp>("chatapp")
                 .WithReference(chat).WaitFor(chat)
                 .WithReference(container).WaitFor(container);

// Dev tunnels
//   https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/get-started?tabs=windows
var tunnel = builder.AddDevTunnel("my-tunnel")
                    .WithReference(web).WaitFor(web)
                    .WithAnonymousAccess();

// ChatConsole Project
builder.AddProject<Projects.ChatConsole>("chatconsole")
       .WithReference(chat).WaitFor(chat);

// ChatBlazor Project
builder.AddProject<Projects.ChatBlazor>("chatblazor")
       .WithReference(chat).WaitFor(chat);

builder.Build().Run();
