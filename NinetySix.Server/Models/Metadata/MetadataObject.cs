using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

[Collection(nameof(MetadataObject))]
public class MetadataObject : BaseEntity, IBaseWorkspace
{
    public MetadataObject()
    {
        DB.Index<MetadataObject>()
            .Key(b => b.WorkspaceId, KeyType.Ascending)
            .Key(b => b.ApiName, KeyType.Ascending)
            .Option(o =>
            {
                o.Background = false;
                o.Unique = true;
            })
            .CreateAsync();
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