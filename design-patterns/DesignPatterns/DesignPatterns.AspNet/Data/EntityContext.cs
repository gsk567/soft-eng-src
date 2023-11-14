using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.AspNet.Data;

public class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options)
        : base(options)
    {
    }
    
    public DbSet<Dog> Dogs { get; set; }
}