using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.Common.Identity;

public class Role :  IBaseWorkspace
{
    public Role() { }
    public Role(string name, string workspaceId) : this()
    {
        Name = name;
        WorkspaceId = workspaceId;
        NormalizedName = name.ToUpperInvariant();
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? NormalizedName { get; set; }
    
    [BsonId]
    public string? WorkspaceId { get; set; }
}