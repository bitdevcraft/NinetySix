namespace NinetySix.Server.Persistence.Seed;

public static class InitialiseMongoCoreDb
{
    public static void InitialiseDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        MongoCoreInitialiser initialiser =
            scope.ServiceProvider.GetRequiredService<MongoCoreInitialiser>();

        initialiser.InitialiseAsync();

        initialiser.SeedAsync();
    }
}