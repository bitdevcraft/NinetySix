using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using NinetySix.Server.Models.Enums;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Metadata;

[Collection(nameof(MetadataObjectField))]
public class MetadataObjectField : BaseEntity, IBaseWorkspace
{
    public MetadataObjectField()
    {
        DB.Index<MetadataObjectField>()
            .Key(b => b.WorkspaceId, KeyType.Ascending)
            .Key(b => b.ApiName, KeyType.Ascending)
            .Key(b => b.MetadataObjectId, KeyType.Ascending)
            .Option(o =>
            {
                o.Background = false;
                o.Unique = true;
            })
            .CreateAsync();
    }

    public MetadataObjectField(bool isStandard): this()
    {
        IsStandard = isStandard;
    }
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ApiName { get; set; }
    
    [BsonRepresentation(BsonType.String)]
    public FieldDataType Type { get; set; }
    
    public string? RelatedTo { get; set; }
    public string? WorkspaceId { get; set; }
    public string? MetadataObjectId { get; set; }
    public bool IsRequired { get; set; }
    public bool IsUnique { get; set; }
    public readonly bool IsStandard;
    // public string DefaultValue { get; set; }
}