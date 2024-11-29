using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NinetySix.Server.Models.Primitives;

public interface IBaseWorkspace
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string? WorkspaceId { get; set; }
}