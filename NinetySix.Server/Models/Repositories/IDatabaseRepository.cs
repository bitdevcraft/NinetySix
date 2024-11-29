namespace NinetySix.Server.Models.Repositories;

public interface IDatabaseRepository
{
    void AddDatabase(string databaseName);
    
    void DeleteDatabase(string databaseName);
    void DeleteDatabaseAsync(string databaseName);
}