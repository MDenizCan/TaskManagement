using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //get all tasks
        [HttpGet]

        //get ALL TASKS BY PROJECT ID 
        [HttpGet("{id}")]

        //get TASK BY TASK ID
        [HttpGet("{id}")]

        //post tasks
        [HttpPost]

        //update tasks by id
        [HttpPut("{id}")]

        //delete tasks by id
        [HttpDelete("{id}")]
    }
}
