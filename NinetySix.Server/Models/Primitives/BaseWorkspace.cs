using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NinetySix.Server.Models.Primitives;

public class BaseWorkspace
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string? WorkspaceId { get; set; }
}