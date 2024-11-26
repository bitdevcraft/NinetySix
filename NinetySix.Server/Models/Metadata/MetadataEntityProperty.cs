using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

public class MetadataEntityProperty : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ApiName { get; set; }
    public string? Type { get; set; }
    public string? RelatedTo { get; set; }
    // public string DefaultValue { get; set; }
}