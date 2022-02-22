using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependencyInjectionController : ControllerBase
    {
        private readonly IOperation _operation;
        private readonly IServiceProvider _serviceProvider;

        public DependencyInjectionController(
            IOperation operation, 
            IServiceProvider serviceProvider)
        {
            _operation = operation;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("Construtor")]
        public IActionResult Construtor()
        {
            return Ok(_operation.Id);
        }

        [HttpGet("Anotacao")]
        public IActionResult Anotacao([FromServices] IOperation operation)
        {
            return Ok(operation.Id);
        }

        [HttpGet("Provider")]
        public IActionResult Provider()
        {
            return Ok(_serviceProvider.GetRequiredService<IOperation>().Id);
        }
    }
}
