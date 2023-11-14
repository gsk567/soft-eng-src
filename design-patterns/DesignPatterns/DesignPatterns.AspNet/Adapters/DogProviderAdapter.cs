using DesignPatterns.Adapter;
using DesignPatterns.AspNet.Data;

namespace DesignPatterns.AspNet.Adapters;

public class DogProviderAdapter : IDogsProviderAdapter
{
    private readonly EntityContext context;

    public DogProviderAdapter(EntityContext context)
    {
        this.context = context;
    }
    
    public IEnumerable<DogAdapterModel> GetDogs()
    {
        return this.context
            .Dogs
            .Select(x => new DogAdapterModel
            {
                Id = x.Id,
                Name = x.Name,
                OwnerName = x.OwnerName
            });
    }
}