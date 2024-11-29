using MongoDB.Driver;
using MongoDB.Entities;
using NinetySix.Server.Models.Entities.Common;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Metadata;
using NinetySix.Server.Models.Repositories;
using NinetySix.Server.Persistence.Seed.StandardObjects;

namespace NinetySix.Server.Persistence.Repositories;

public class DatabaseRepository(IMongoDbSettings mongoDbSettings) : IDatabaseRepository
{
    private readonly MongoClient _mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

    public async Task<string> AddDatabase(string databaseName)
    {
        
        var workspace = new Workspace
        {
            DomainName = databaseName,
            Name = databaseName,
            Schema = databaseName
        };
        
        await workspace.SaveAsync();
         
         var standardCollections = new List<MetadataObject>
         {
             AccountObject.CreateStandardObject(),
             ContactObject.CreateStandardObject(),
             LeadObject.CreateStandardObject(),
         };
         
         var db = _mongoClient.GetDatabase(databaseName);

         foreach (var stdCollection in standardCollections)
         {
             stdCollection.WorkspaceId = workspace.ID;
             await stdCollection.SaveAsync();

             foreach (var field in stdCollection.Fields)
             {
                 field.WorkspaceId = workspace.ID;
                 field.MetadataObjectId = stdCollection.ID;
                 await field.SaveAsync();
             }
             
             await db.CreateCollectionAsync(stdCollection.ApiName);
         }
         
         return workspace.ID;
    }



    public void DeleteDatabase(string databaseName)
    {
        _mongoClient.DropDatabase(databaseName);
    }

    public async void DeleteDatabaseAsync(string databaseName)
    {
        await _mongoClient.DropDatabaseAsync(databaseName);
    }
}