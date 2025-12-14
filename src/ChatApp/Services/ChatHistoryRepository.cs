using Microsoft.EntityFrameworkCore;

namespace ChatApp.Services;

internal interface IChatHistoryRepository
{
    Task SaveAsync(ChatMessageEntity entity, CancellationToken cancellationToken = default);
}

internal class ChatHistoryRepository(ChatHistoryDbContext db) : IChatHistoryRepository
{
    public async Task SaveAsync(ChatMessageEntity entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await db.Messages.AddAsync(entity, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }
}
