using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NinetySix.Server.Models.Primitives;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}