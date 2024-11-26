using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.System;

public class PermissionSet : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? AppMenuId { get; set; }
    public string? MetadataEntityId { get; set; }
    public string? MetadataEntityPropertyId { get; set; }
    public bool CanCreate { get; set; }
    public bool CanRead { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
}