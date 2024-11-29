namespace NinetySix.Server.Persistence.Seed;

public static class InitialiseMongoCoreDb
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        MongoCoreInitialiser initialiser =
            scope.ServiceProvider.GetRequiredService<MongoCoreInitialiser>();

        await initialiser.InitialiseAsync();

        initialiser.SeedAsync();
    }
}