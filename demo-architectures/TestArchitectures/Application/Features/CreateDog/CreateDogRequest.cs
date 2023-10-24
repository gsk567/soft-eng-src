using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CreateDog
{
    public class CreateDogRequest : IRequest<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public class CreateDogRequestHandler : IRequestHandler<CreateDogRequest, int>
        {
            private readonly IDogRepository dogRepository;

            public CreateDogRequestHandler(IDogRepository dogRepository)
            {
                this.dogRepository = dogRepository;
            }

            public async Task<int> Handle(CreateDogRequest request, CancellationToken cancellationToken)
            {
                return this.dogRepository.CreateDog(new Dog
                {
                    Name = request.Name,
                    Age = request.Age,
                });
            }
        }
    }
}
