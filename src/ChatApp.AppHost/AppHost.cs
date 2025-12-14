using Aspire.Hosting.GitHub;

var builder = DistributedApplication.CreateBuilder(args);

// GitHub Models
var model = GitHubModel.OpenAI.OpenAIGpt4oMini;
var chat = builder.AddGitHubModel("chat", model);

var web = builder.AddProject<Projects.ChatApp>("chatapp")
                 .WithReference(chat);

// Dev tunnels
//   https://learn.microsoft.com/en-us/azure/developer/dev-tunnels/get-started?tabs=windows
var tunnel = builder.AddDevTunnel("my-tunnel")
                    .WithReference(web)
                    .WithAnonymousAccess();

builder.Build().Run();
