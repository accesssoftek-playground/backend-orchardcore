namespace Backend.Contracts.Persistence;

public interface IPersistenceConnection : IDisposable
{
    object InternalConnection { get; }
}