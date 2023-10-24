using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EntityContextClean : DbContext
    {
        public EntityContextClean(DbContextOptions<EntityContextClean> options)
            : base(options)
        {
        }

        public DbSet<DogEntity> Dogs { get; set; }
    }
}
