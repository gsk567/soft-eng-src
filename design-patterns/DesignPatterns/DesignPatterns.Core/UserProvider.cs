namespace DesignPatterns;

public class UserProvider
{
    private static UserProvider instance;

    private User user;
    
    private UserProvider()
    {
    }

    public static UserProvider Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserProvider();
            }
            
            return instance;
        }
    }

    public User GetUser()
    {
        return this.user;
    }

    public void SaveUser(User user) => this.user = user;
}