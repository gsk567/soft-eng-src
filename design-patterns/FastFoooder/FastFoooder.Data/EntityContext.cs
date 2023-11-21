using Microsoft.EntityFrameworkCore;

namespace FastFoooder.Data;

public class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Burger> Burgers { get; set; }
    
    public DbSet<Cake> Cakes { get; set; }
    
    public DbSet<Kebap> Kebaps { get; set; }
    
    public DbSet<Pizza> Pizzas { get; set; }
    
    public DbSet<Shkembe> Shkembes { get; set; }
}