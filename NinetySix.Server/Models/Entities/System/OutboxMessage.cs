using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.System;

public class OutboxMessage : BaseEntity, IBaseWorkspace
{
    public string? WorkspaceId { get; set; }
}