using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

public class PermissionSet : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? MetadataObjectId { get; set; }
    public string? MetadataObjectFieldId { get; set; }
    public string? RoleId { get; set; }
    public bool CanCreate { get; set; }
    public bool CanRead { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
}