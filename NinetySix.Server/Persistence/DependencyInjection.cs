using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using NinetySix.Server.Models.Entities.Common.Identity;


namespace NinetySix.Server.Persistence;

public static class DependencyInjection
{
    // Dependency Injection
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // services.AddScoped<IMongoDbSettings>(cfg =>
        //      new MongoDbSettings(configuration.GetConnectionString("MongoDbSettings"), 
        //         configuration.GetSection("MongoDb").GetValue<string>("DatabaseName"))
        // );

        services
            .AddIdentityMongoDbProvider<User, Role, ObjectId>(mongo =>
            {
                mongo.ConnectionString = $"{configuration.GetConnectionString("MongoDbConnection")}/core" ;
                mongo.UsersCollection = "users";
            });
            // .AddDefaultTokenProviders();
    
        return services;
    }
}