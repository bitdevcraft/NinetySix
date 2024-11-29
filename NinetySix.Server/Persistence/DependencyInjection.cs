using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using NinetySix.Server.Models.Entities.Common.Identity;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Repositories;
using NinetySix.Server.Persistence.Repositories;
using NinetySix.Server.Persistence.Seed;
using NinetySix.Server.Persistence.Settings;


namespace NinetySix.Server.Persistence;

public static class DependencyInjection
{
    // Dependency Injection
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddIdentityMongoDbProvider<User, ObjectId>(mongo =>
            {
                mongo.ConnectionString = $"{configuration.GetSection("MongoDb")
                    .GetValue<string>("ConnectionString")}/core";
                mongo.UsersCollection = "users";
            });


        services.AddSingleton<IMongoDbSettings>(cfg =>
            new MongoDbSettings(
                configuration.GetSection("MongoDb").GetValue<string>("ConnectionString"),
                configuration.GetSection("MongoDb").GetValue<string>("DatabaseName")
            )
        );

        services.AddSingleton<IDatabaseRepository, DatabaseRepository>();
        
        services.AddScoped<MongoCoreInitialiser>();

        return services;
    }
}