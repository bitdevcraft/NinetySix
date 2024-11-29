using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Interfaces;

namespace NinetySix.Server.Models.Primitives;

public class BaseEntity : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}