
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using NinetySix.Server.Models.Primitives;

namespace NinetySix.Server.Models.Entities.Common;

[Collection(nameof(Workspace))]
public class Workspace : BaseEntity
{
    public Workspace()
    {
        DB.Index<Workspace>()
            .Key(b => b.DomainName, KeyType.Ascending )
            .Key(b => b.Schema, KeyType.Ascending)
            .Option(o =>
            {
                o.Background = false;
                o.Unique = true;
            })
            .CreateAsync();
    }
    public string? Name { get; set; }
    public string? ConnectionString { get; set; }
    public string? DomainName { get; set; }
    public string? Schema { get; set; }
}