namespace DesignPatterns.Adapter;

public interface IDogsProviderAdapter
{
    IEnumerable<DogAdapterModel> GetDogs();
}