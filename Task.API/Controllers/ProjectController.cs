using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]

        // POST api/<ValuesController>
        [HttpPost]

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]

    }
}
