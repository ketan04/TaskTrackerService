using Microsoft.AspNetCore.Mvc;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Repositories;
using TaskTracker.Interfaces.Services;
using TaskTracker.Models.Dto.Task;
using TaskTracker.Services.TaskService.Command;
using TaskTracker.Services.TaskService.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskTracker.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        private readonly ITaskService taskService;
      
        public TaskController (ITaskRepository taskRepository, ITaskService taskService)
        {
            this.taskRepository = taskRepository;

            this.taskService = taskService;
           
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, this.taskService.GetTaskList(new GetTaskListQuery(taskRepository)).Result);
            }
            catch (Exception ex)
            {
                // log exception with logger
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTaskRequest createTaskRequest)
        {
            try
            {
                this.taskService.CreateTask(new CreateTaskCommand(taskRepository, createTaskRequest));
                return StatusCode(200, "Saved");
            }
            catch (Exception ex)
            {
                // log exception with logger
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateTaskRequest updateTaskRequest)
        {
            try
            {
                updateTaskRequest.Id = id;
                return StatusCode(200, this.taskService.UpdateTask(new UpdateTaskCommand(taskRepository, updateTaskRequest)));
            }
            catch (Exception ex)
            {
                // log exception with logger
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
