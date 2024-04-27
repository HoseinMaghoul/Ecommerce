namespace Domain.IServices;

public interface IDatabaseTransaction : IDisposable
{
    void Commit();
    void Rollback();
    Task CommitAsync();

    Task RollbackAsync();
}