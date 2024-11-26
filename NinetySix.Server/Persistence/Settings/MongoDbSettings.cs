using NinetySix.Server.Models.Interfaces;

namespace NinetySix.Server.Persistence.Settings;

public class MongoDbSettings(string? connectionString, string? databaseName) : IMongoDbSettings
{
    public string? ConnectionString { get; set; } = connectionString;
    public string? DatabaseName { get; set; } = databaseName;
}