using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiDependencyController : ControllerBase
    {
        private readonly IEnumerable<IPeople> peoples;

        public MultiDependencyController(IEnumerable<IPeople> peoples)
        {
            this.peoples = peoples;
        }

        [HttpGet("People")]
        public IActionResult People()
        {
            return Ok(new
            {
                PeopleOne = peoples.FirstOrDefault(c => c is PeopleOne)?.Id,
                PeopleTwo = peoples.FirstOrDefault(c => c is PeopleTwo)?.Id,
                PeopleThree = peoples.FirstOrDefault(c => c is PeopleThree)?.Id
            });
        }
    }

    public abstract class People : IPeople
    {
        public People()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }

    public class PeopleOne : People { }
    public class PeopleTwo : People { }
    public class PeopleThree : People { }

    public interface IPeople
    {
        Guid Id { get; set; }
    }
}
