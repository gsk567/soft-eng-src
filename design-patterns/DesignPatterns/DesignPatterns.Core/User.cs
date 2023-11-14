namespace DesignPatterns;

public class User
{
    public User()
    {
        this.Id = Guid.NewGuid().ToString();
    }
    
    public string Id { get; }

    public string Name { get; set; }
}