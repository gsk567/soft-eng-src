using Application.Interfaces;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class DogRepository : IDogRepository
    {
        private readonly EntityContextClean context;

        public DogRepository(EntityContextClean context)
        {
            this.context = context;
        }

        public int CreateDog(Dog dog)
        {
            var dogEntity = new DogEntity
            {
                Name = dog.Name,
                Age = dog.Age,
            };

            this.context.Add(dogEntity);
            this.context.SaveChanges();

            return dogEntity.Id;
        }

        public IEnumerable<Dog> FetchDogs()
        {
            return this.context
                .Dogs
                .Select(x => new Dog
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                })
                .ToList();
        }
    }
}
