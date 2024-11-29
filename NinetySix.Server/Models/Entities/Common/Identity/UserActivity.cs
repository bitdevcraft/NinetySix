using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.Common.Identity;

public class UserActivity : BaseEntity, IBaseWorkspace
{
    [BsonId] 
    public string? UserId { get; set; }
    
    [BsonIgnore]
    public User? User { get; set; }
    
    public string? WorkspaceId { get; set; }

    public string? Type { get; set; }
    public string? IpAddress { get; set; }
    public string? DeviceInfo { get; set; }
}