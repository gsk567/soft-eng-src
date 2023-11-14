namespace DesignPatterns;

public class KebapFactory
{
    public Kebap CreateKebap(bool veganFriendly = false)
    {
        var kebap = new Kebap
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            CreatorName = UserProvider.Instance?.GetUser()?.Name
        };

        if (veganFriendly)
        {
            kebap.WithoutMeat = true;
            kebap.WithVegitables = true;
        }
        
        return kebap;
    }

    public Kebap CreateKebap(KebapRequest request)
    {
        var kebap = new Kebap
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            CreatorName = UserProvider.Instance?.GetUser()?.Name
        };

        kebap.WithVegitables = request.WithVegitables;
        kebap.WithoutMeat = request.WithoutMeat;
        kebap.IsSpicy = request.IsSpicy;
        
        return kebap;
    }
}