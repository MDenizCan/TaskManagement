using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //get users
        [HttpGet]

        //get users by id
        [HttpGet("{id}")]

        //get ALL THE USERS THAT'S ASSIGNED TO A PROJECT
        [HttpGet("{id}")]

        //post users
        [HttpPost]
 
        //update users by id
        [HttpPut("{id}")]

        //delete users by id
        [HttpDelete("{id}")]

    }
}
