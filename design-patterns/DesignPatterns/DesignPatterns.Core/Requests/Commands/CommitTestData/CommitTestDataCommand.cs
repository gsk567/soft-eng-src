using MediatR;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Requests.Commands.CommitTestData;

public class CommitTestDataCommand : IRequest<bool>
{
    public string Data { get; set; }
    
    public class CommitTestDataCommandHandler : IRequestHandler<CommitTestDataCommand, bool>
    {
        private readonly ILogger<CommitTestDataCommandHandler> logger;

        public CommitTestDataCommandHandler(ILogger<CommitTestDataCommandHandler> logger)
        {
            this.logger = logger;
        }
        
        public async Task<bool> Handle(CommitTestDataCommand request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation(request.Data);
            
            return await Task.FromResult(true);
        }
    }
}