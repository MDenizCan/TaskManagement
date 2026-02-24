using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    //get all projects
    [HttpGet]

    //get project by id
    [HttpGet("{id}")]

    //post project
    [HttpPost]

    //update project by id
    [HttpPut("{id}")]

    //delete project by id
    [HttpDelete("{id}")]


}
