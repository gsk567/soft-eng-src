namespace DesignPatterns.AspNet.Repository;

public class UnitOfWork
{
    private readonly IEnumerable<IRepository> repositories;

    public UnitOfWork(IEnumerable<IRepository> repositories)
    {
        this.repositories = repositories;
    }
    
    public TRepository? GetRepository<TRepository>()
        where TRepository : class, IRepository
    {
        return (TRepository) this.repositories
            .FirstOrDefault(x => x.GetType() == typeof(TRepository))!;
    }
}