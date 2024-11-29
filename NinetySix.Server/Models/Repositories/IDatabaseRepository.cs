namespace NinetySix.Server.Models.Repositories;

public interface IDatabaseRepository
{
    Task<string> AddDatabase(string databaseName);
    
    void DeleteDatabase(string databaseName);
    void DeleteDatabaseAsync(string databaseName);
}