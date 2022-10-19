using Backend.Contracts.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace SqlitePersistenceModule;

internal class SqlitePersistenceConnection : IPersistenceConnection
{
    private SqliteConnection? _connection;
    private readonly ILogger _logger;

    public SqlitePersistenceConnection(SqliteConnection connection, ILogger logger)
    {
        _connection = connection;
        _logger = logger;
    }

    public void Dispose()
    {
        if (_connection != null)
        {
            _connection.Dispose();
            _connection = null;
        }
    }

    public object InternalConnection => _connection ?? throw new ObjectDisposedException(nameof(SqlitePersistenceConnection));
}