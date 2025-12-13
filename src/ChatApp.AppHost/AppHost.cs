using Aspire.Hosting.GitHub;

var builder = DistributedApplication.CreateBuilder(args);

// GitHub Models
var model = GitHubModel.OpenAI.OpenAIGpt4oMini;
var chat = builder.AddGitHubModel("chat", model);

builder.AddProject<Projects.ChatApp>("chatapp")
       .WithReference(chat);

builder.Build().Run();
