using DesignPatterns.Adapter;
using DesignPatterns.AspNet.Repository;
using DesignPatterns.Requests.Commands.CommitTestData;
using DesignPatterns.Requests.Queries.GetTestData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.AspNet.Controllers;

[Route("test")]
public class TestController : ControllerBase
{
    private readonly UnitOfWork unitOfWork;
    private readonly PrintService printService;
    private readonly OrderService orderService;
    private readonly IMediator mediator;

    public TestController(
        UnitOfWork unitOfWork,
        PrintService printService,
        OrderService orderService,
        IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.printService = printService;
        this.orderService = orderService;
        this.mediator = mediator;
    }
    
    [HttpGet("repository")]
    public IActionResult TestRepository()
    {
        var dogsRepository = this.unitOfWork.GetRepository<DogRepository>();
        return this.Ok(dogsRepository?.GetDogs());
    }
    
    [HttpGet("adapter")]
    public IActionResult TestAdapter()
    {
        this.printService.PrintDogs();
        return this.Ok();
    }

    [HttpGet("strategy")]
    public IActionResult TestStrategy(
        [FromQuery]string deliveryProviderId,
        [FromQuery]double weight)
    {
        var request = new OrderRequest
        {
            DeliveryProviderId = deliveryProviderId,
            Weight = weight,
        };
        return this.Ok(this.orderService.Process(request));
    }

    [HttpGet("mediator/query")]
    public async Task<IActionResult> TestMediatorQuery()
    {
        return Ok(await this.mediator.Send(new GetTestDataQuery()));
    }
    
    [HttpGet("mediator/command/{data}")]
    public async Task<IActionResult> TestMediatorCommand(string data)
    {
        return Ok(await this.mediator.Send(new CommitTestDataCommand { Data = data }));
    }
}