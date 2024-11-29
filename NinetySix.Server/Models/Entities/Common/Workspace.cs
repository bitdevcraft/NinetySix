
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.Common;

public class Workspace : BaseEntity
{
    public string? Name { get; set; }
    public string? ConnectionString { get; set; }
    public string? DomainName { get; set; }
    public string? Schema { get; set; }
}