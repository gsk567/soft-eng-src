using System.Collections.Generic;

namespace Business
{
    public interface IDogService
    {
        IEnumerable<DogModel> FetchDogs();

        int CreateDog(DogModel dog);
    }
}
