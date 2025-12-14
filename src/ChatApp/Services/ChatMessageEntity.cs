using System;
using Microsoft.Extensions.AI;

namespace ChatApp.Services;

internal class ChatMessageEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString("n");
    public string ConversationId { get; set; } = string.Empty;
    public ChatRole Role { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTimeOffset CreatedUtc { get; set; } = DateTimeOffset.UtcNow;
}
