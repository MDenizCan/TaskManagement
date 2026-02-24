using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //get all users
        [HttpGet]

        //get users by id
        [HttpGet("{id}")]

        //get ALL THE USERS THAT'S ASSIGNED TO A PROJECT
        [HttpGet("{id}")]

        //get ALL THE USERS THAT'S ASSIGNED TO A TASK
        [HttpGet("{id}")]

        //create users
        [HttpPost]

        //add users to projects
        [HttpPost("{id}")]

        //add users to tasks
        [HttpPost("{id}")]
        //if user doesnt exist in project, add user to project and assign task to user
        //if user exist in project, assign task to user

        //update users by id
        [HttpPut("{id}")]

        //delete users by id
        [HttpDelete("{id}")]

    }
}
