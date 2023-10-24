using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EntityContextNLayer : DbContext
    {
        public EntityContextNLayer(DbContextOptions<EntityContextNLayer> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
