using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services;

internal class ChatHistoryDbContext(DbContextOptions<ChatHistoryDbContext> options) : DbContext(options)
{
    public DbSet<ChatMessageEntity> Messages => Set<ChatMessageEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Partition key mapping for Cosmos
        modelBuilder.Entity<ChatMessageEntity>().HasPartitionKey(m => m.ConversationId);
        modelBuilder.Entity<ChatMessageEntity>().HasKey(m => m.Id);

        // ChatRole を文字列に保存
        modelBuilder.Entity<ChatMessageEntity>()
            .Property(m => m.Role)
            .HasConversion(
                v => v.ToString(),            // 保存時: string
                v => new Microsoft.Extensions.AI.ChatRole(v));      // 読込時: ChatRole（適宜パーサー/ファクトリを使用）
    }
}
