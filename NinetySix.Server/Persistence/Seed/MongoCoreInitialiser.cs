using MongoDB.Driver;
using NinetySix.Server.Models.Entities.Common;
using NinetySix.Server.Models.Entities.Common.Identity;
using NinetySix.Server.Models.Entities.System;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Persistence.Seed;

public class MongoCoreInitialiser
{
    private readonly IMongoDbSettings _mongoDbSettings;
    private readonly ILogger<MongoCoreInitialiser> _logger;
    private readonly MongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;
    
    
    public MongoCoreInitialiser(ILogger<MongoCoreInitialiser> logger, IMongoDbSettings mongoDbSettings)
    {
        _logger = logger;
        _mongoDbSettings = mongoDbSettings;
        _mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
        _mongoDatabase = _mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
    }
    public async Task InitialiseAsync()
    {
        try
        {
            var coreCollections = new List<string>
            {
                $"{nameof(Workspace)}s",
                $"{nameof(OutboxMessage)}s",
                $"{nameof(MetadataObject)}s",
                $"{nameof(MetadataObjectField)}s",
                $"{nameof(PermissionSet)}s",
                $"{nameof(UserActivity)}s",
                $"{nameof(AppMenu)}s",
            };

            foreach (var coreCollection in coreCollections)
            {
                await _mongoDatabase.CreateCollectionAsync(coreCollection);
            }

            WorkspaceIndex();
            MetadataObjectIndex();
            MetadataObjectFieldIndex();

        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    private void MetadataObjectIndex()
    {
        var collection = _mongoDatabase.GetCollection<MetadataObject>("MetadataObjects");
            
        var indexKeys = Builders<MetadataObject>.IndexKeys
                .Ascending(x => x.WorkspaceId)
                .Ascending(x => x.ApiName);
        
        var indexOptions = new CreateIndexOptions { Unique = true };
        
        var indexModel = new CreateIndexModel<MetadataObject>(indexKeys, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }
    
    private void MetadataObjectFieldIndex()
    {
        var collection = _mongoDatabase.GetCollection<MetadataObjectField>("MetadataObjectFields");
            
        var indexKeys = Builders<MetadataObjectField>.IndexKeys
                .Ascending(x => x.WorkspaceId)
                .Ascending(x => x.MetadataObjectId)
                .Ascending(x => x.ApiName);
        
        var indexOptions = new CreateIndexOptions { Unique = true };
        
        var indexModel = new CreateIndexModel<MetadataObjectField>(indexKeys, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }
    
    private void WorkspaceIndex()
    {
        var collection = _mongoDatabase.GetCollection<Models.Entities.Common.Workspace>("Workspaces");
            
        var indexKeys = Builders<Models.Entities.Common.Workspace>.IndexKeys
                .Ascending(x => x.Schema);
        
        var indexOptions = new CreateIndexOptions { Unique = true };
        
        var indexModel = new CreateIndexModel<Models.Entities.Common.Workspace>(indexKeys, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }

    public void SeedAsync()
    {
        try
        {
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
}