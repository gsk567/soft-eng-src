using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.FetchDogs
{
    public class FetchDogsRequest : IRequest<IEnumerable<FetchDogsModel>>
    {
        public class FetchDogsRequestHandler : IRequestHandler<FetchDogsRequest, IEnumerable<FetchDogsModel>>
        {
            private readonly IDogRepository dogRepository;

            public FetchDogsRequestHandler(IDogRepository dogRepository)
            {
                this.dogRepository = dogRepository;
            }

            public async Task<IEnumerable<FetchDogsModel>> Handle(FetchDogsRequest request, CancellationToken cancellationToken)
            {
                return this.dogRepository.FetchDogs().Select(x => new FetchDogsModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                });
            }
        }
    }
}
