var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ChatApp>("chatapp");

builder.Build().Run();
