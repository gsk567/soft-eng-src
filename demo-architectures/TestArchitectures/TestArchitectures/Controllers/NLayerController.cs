using Business;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class NLayerController : ControllerBase
    {
        private readonly IDogService dogService;

        public NLayerController(IDogService dogService)
        {
            this.dogService = dogService;
        }

        [HttpGet("dogs")]
        public IActionResult GetDogs()
        {
            return Ok(this.dogService.FetchDogs());
        }

        [HttpPost("dogs")]
        public IActionResult CreateDog([FromBody]DogModel model)
        {
            return Ok(this.dogService.CreateDog(model));
        }
    }
}
