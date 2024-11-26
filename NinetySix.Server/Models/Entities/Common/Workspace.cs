
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NinetySix.Server.Models.Entities.Common;

public class Workspace
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 
    public string? Name { get; set; }
    public string? ConnectionString { get; set; }
    public string? DomainName { get; set; }
    public string? Schema { get; set; }
}