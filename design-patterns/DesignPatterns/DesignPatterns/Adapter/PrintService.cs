namespace DesignPatterns.Adapter;

public class PrintService
{
    private readonly IDogsProviderAdapter dogsProviderAdapter;

    public PrintService(IDogsProviderAdapter dogsProviderAdapter)
    {
        this.dogsProviderAdapter = dogsProviderAdapter;
    }
    
    public void PrintDogs()
    {
        var dogs = this.dogsProviderAdapter.GetDogs();
        foreach (var dog in dogs)
        {
            Console.WriteLine($"dog: {dog.Id}, {dog.Name}");
        }
    }
}