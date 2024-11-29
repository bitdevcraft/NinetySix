using MongoDB.Driver;
using NinetySix.Server.Models.Entities.Common;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Metadata;
using NinetySix.Server.Models.Repositories;
using NinetySix.Server.Persistence.Seed.StandardObjects;

namespace NinetySix.Server.Persistence.Repositories;

public class DatabaseRepository(IMongoDbSettings mongoDbSettings) : IDatabaseRepository
{
    private readonly MongoClient _mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

    public void AddDatabase(string databaseName)
    {

        
        var coreDb = _mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
        var workspaceCollection =  coreDb.GetCollection<Workspace>("Workspaces");
        var metadataObjColletion =  coreDb.GetCollection<MetadataObject>("Metadataobjects");
        var metadataObjFieldCollection =  coreDb.GetCollection<MetadataObjectField>("MetadataObjectFields");

        var workspace = new Workspace
        {
            DomainName = databaseName,
            Name = databaseName,
            Schema = databaseName
        };
        
         workspaceCollection.InsertOne(workspace);
         
         var standardCollections = new List<MetadataObject>
         {
             AccountObject.CreateStandardObject(),
             ContactObject.CreateStandardObject(),
             LeadObject.CreateStandardObject(),
         };
         
         var db = _mongoClient.GetDatabase(databaseName);

         foreach (var stdCollection in standardCollections)
         {
             stdCollection.WorkspaceId = workspace.Id;
             metadataObjColletion.InsertOne(stdCollection);

             foreach (var field in stdCollection.Fields)
             {
                 field.WorkspaceId = workspace.Id;
                 field.MetadataObjectId = stdCollection.Id;
                 metadataObjFieldCollection.InsertOne(field);
             }
             
             db.CreateCollection(stdCollection.ApiName);
         }
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