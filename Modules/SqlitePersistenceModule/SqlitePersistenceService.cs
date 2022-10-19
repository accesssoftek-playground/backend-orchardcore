using Backend.Contracts.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace SqlitePersistenceModule;

internal class SqlitePersistenceService : IPersistenceService
{
    private readonly ILogger<SqlitePersistenceService> _logger;

    public SqlitePersistenceService(ILogger<SqlitePersistenceService> logger)
    {
        _logger = logger;
    }

    public IPersistenceConnection GetConnection()
    {
        var conn = new SqliteConnection(Constants.CONNECTION_STRING);
        conn.Open();
        return new SqlitePersistenceConnection(conn, _logger);
    }

    public void ResetPersistence()
    {
        throw new NotImplementedException();
    }

    public async Task ResetPersistenceAsync()
    {
        throw new NotImplementedException();
    }

    public void MigratePersistence()
    {
        Task.Run(async () => await MigratePersistenceAsync()).Wait();
    }

    public async Task MigratePersistenceAsync()
    {
        await using var connection = new SqliteConnection(Constants.CONNECTION_STRING);
        await connection.OpenAsync();
        _logger.LogInformation("Checking the sqlite persistence database");

        await using var cmd = connection.CreateCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "SELECT version FROM __MigrationsHistory ORDER BY version DESC LIMIT 1";
        try
        {
            _logger.LogDebug("Attempting to get current version");
            var version = await cmd.ExecuteScalarAsync();
            _logger.LogInformation("The persistence database version is {Version}", version);
        }
        catch (SqliteException)
        {
            _logger.LogInformation("The sqlite persistence database needs migration");
            cmd.CommandText = "CREATE TABLE __MigrationsHistory (version INTEGER PRIMARY KEY)";
            await cmd.ExecuteNonQueryAsync();
            cmd.CommandText = "INSERT INTO __MigrationsHistory (version) VALUES (1)";
            await cmd.ExecuteNonQueryAsync();
        }
    }
}