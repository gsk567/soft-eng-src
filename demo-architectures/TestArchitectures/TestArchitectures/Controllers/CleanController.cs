using Application.Features.CreateDog;
using Application.Features.FetchDogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class CleanController : ControllerBase
    {
        private readonly IMediator mediator;

        public CleanController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("dogs")]
        public async Task<IActionResult> GetDogs()
        {
            return Ok(await this.mediator.Send(new FetchDogsRequest()));
        }

        [HttpPost("dogs")]
        public async Task<IActionResult> CreateDog([FromBody]CreateDogRequest request)
        {
            return Ok(await this.mediator.Send(request));
        }
    }
}
