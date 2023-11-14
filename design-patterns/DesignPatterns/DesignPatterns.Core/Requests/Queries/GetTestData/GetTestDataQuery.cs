using MediatR;

namespace DesignPatterns.Requests.Queries.GetTestData;

public class GetTestDataQuery : IRequest<IEnumerable<string>>
{
    public class GetTestDataQueryHandler : IRequestHandler<GetTestDataQuery, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(GetTestDataQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<string>
            {
                "Pesho",
                "Ivan",
                "Gosho",
                "Gabriela",
                "Tanya",
                "Petya"
            });
        }
    }
}