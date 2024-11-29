using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.Common.Identity;


public class User : MongoUser, IBaseWorkspace
{
    public string? WorkspaceId { get; set; }
    
    public readonly bool WorkspaceOwner = false;

    public User() { }
    public User(bool workspaceOwner) : this()
    {
        WorkspaceOwner = workspaceOwner;
    }
}