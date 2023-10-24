using Data;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class DogService : IDogService
    {
        private readonly EntityContextNLayer context;

        public DogService(EntityContextNLayer context)
        {
            this.context = context;
        }

        public int CreateDog(DogModel dog)
        {
            var dogEntity = new Dog
            {
                Name = dog.Name,
                Age = dog.Age,
            };

            this.context.Add(dogEntity);
            this.context.SaveChanges();

            return dogEntity.Id;
        }

        public IEnumerable<DogModel> FetchDogs()
        {
            return this.context
                .Dogs
                .Select(x => new DogModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                })
                .ToList();
        }
    }
}
