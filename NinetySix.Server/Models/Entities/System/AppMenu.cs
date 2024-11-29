using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.System;

public class AppMenu : BaseEntity, IBaseWorkspace
{
    public string? WorkspaceId { get; set; }
}