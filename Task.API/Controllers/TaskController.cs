using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.API.Controllers;
/*
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [/tasks]
    //get all tasks
    [HttpGet]
    
    [/projects/tasks]
    //get ALL TASKS BY PROJECT ID 
    [HttpGet("{id}")]
    
    [/tasks/{taskid}]
    //get TASK BY TASK ID
    [HttpGet("{id}")]

    [/tasks/{TaskId}/users]
    //get ALL THE USERS THAT'S ASSIGNED TO A TASK
    [HttpGet("{TaskId}")]

    //nested routes
    [/projects/{projectId}/tasks]
    //post tasks by project id
    [HttpPost("{id}")]

    [/tasks/{taskid}/assign] userid bodyden gelecek
    //add users to tasks
    [HttpPost("{UserId and TaskId}")]
    //if user doesnt exist in project, add user to project and assign task to user
    //if user exist in project, assign task to user
    //user taskin projesinde yoksa atanamaz
    //[autheticate] asamasinda eger user projedeyse mid level yapabilir, eger degilse senior yapabilir

    [/tasks/{taskid}]
    //update tasks by id
    [HttpPut("{id}")]

    [/tasks/{taskid}/status]
    //update task status by id,[authenticate]mid level yapabilir, senior yapabilir
    [HttpPut("{id}")]

    [/tasks/{id}]
    //delete tasks by id, [authenticate]mid level yapabilir, senior yapabilir
    [HttpDelete("{id}")]
}
*/