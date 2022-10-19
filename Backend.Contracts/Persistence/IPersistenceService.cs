namespace Backend.Contracts.Persistence;

public interface IPersistenceService
{
    IPersistenceConnection GetConnection();
    
    void ResetPersistence();
    Task ResetPersistenceAsync();
    
    void MigratePersistence();
    
    Task MigratePersistenceAsync();
}