using Domain;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDogRepository
    {
        IEnumerable<Dog> FetchDogs();

        int CreateDog(Dog dog);
    }
}
