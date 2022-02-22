using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloController : ControllerBase
    {
        private readonly ICicloScoped _cicloScoped;
        private readonly ICicloTransient _cicloTransient;
        private readonly ICicloSingleton _cicloSingleton;

        public CicloController(
            ICicloScoped cicloScoped, 
            ICicloTransient cicloTransient, 
            ICicloSingleton cicloSingleton)
        {
            this._cicloScoped = cicloScoped;
            this._cicloTransient = cicloTransient;
            this._cicloSingleton = cicloSingleton;
        }

        [HttpGet("Ciclo")]
        public IActionResult Ciclo(
            [FromServices] ICicloScoped cicloScoped,
            [FromServices] ICicloTransient cicloTransient,
            [FromServices] ICicloSingleton cicloSingleton)
        {

            return Ok(new
            {
                Scoped01 = _cicloScoped.Id,
                Transient01 = _cicloTransient.Id,
                Singleton01 = _cicloSingleton.Id,
                Scoped02 = cicloScoped.Id,
                Transient02 = cicloTransient.Id,
                Singleton02 = cicloSingleton.Id
            });
        }
    }

    public class Ciclo : ICicloTransient, ICicloScoped, ICicloSingleton
    {
        public Guid Id { get; set; }

        public Ciclo()
        {
            Id = Guid.NewGuid();
        }
    }

    public interface ICiclo
    {
        Guid Id { get; set; }
    }

    public interface ICicloTransient : ICiclo { };

    public interface ICicloSingleton : ICiclo { };

    public interface ICicloScoped : ICiclo { };

}
