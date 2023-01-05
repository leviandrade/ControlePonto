namespace ControlePonto.DAL.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        Task CommitAsync();
    }
}
