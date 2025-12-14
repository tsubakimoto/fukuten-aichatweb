using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services;

internal class ChatHistoryDbContext(DbContextOptions<ChatHistoryDbContext> options) : DbContext(options)
{
    internal const string ContainerName = "ChatMessages";

    public DbSet<ChatMessageEntity> Messages => Set<ChatMessageEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Container and partition key mapping for Cosmos
        modelBuilder.Entity<ChatMessageEntity>().ToContainer(ContainerName);
        modelBuilder.Entity<ChatMessageEntity>().HasPartitionKey(m => m.ConversationId);
        modelBuilder.Entity<ChatMessageEntity>().HasKey(m => m.Id);
    }
}
