using DesignPatterns.AspNet.Data;

namespace DesignPatterns.AspNet.Repository;

public class DogRepository : IRepository
{
    private readonly EntityContext context;

    public DogRepository(EntityContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<Dog> GetDogs()
    {
        var dogs = this.context.Dogs.ToList();
        return dogs;
    }
}