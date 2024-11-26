using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

public class MetadataEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ApiName { get; set; }
    public string? PluralName { get; set; }
}