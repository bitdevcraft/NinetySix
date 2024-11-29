using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

public class MetadataObject : BaseEntity, IBaseWorkspace
{
    public MetadataObject()
    {
        
    }

    public MetadataObject(bool isStandard) : this()
    {
        IsStandard = isStandard;
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ApiName { get; set; }
    public string? PluralName { get; set; }
    public string? WorkspaceId { get; set; }
    public readonly bool IsStandard;
    
    [BsonIgnore]
    public Collection<MetadataObjectField> Fields { get; set; } = [];
}