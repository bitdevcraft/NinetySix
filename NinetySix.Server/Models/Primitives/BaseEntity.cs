using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;


namespace NinetySix.Server.Models.Primitives;

public class BaseEntity : Entity
{
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? UpdatedAt { get; set; }
}