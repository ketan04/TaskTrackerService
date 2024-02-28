using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Repositories;
using TaskTracker.Models.Dto.Task;

namespace TaskTracker.Services.TaskService.Command
{
    public class CreateTaskCommand : ICommandHandler<CreateTaskRequest>
    {
        private readonly ITaskRepository taskRepository;
        private readonly CreateTaskRequest createTaskRequest;

        public CreateTaskCommand (ITaskRepository taskRepository, CreateTaskRequest createTaskRequest)
        {
            this.taskRepository = taskRepository;
            this.createTaskRequest = createTaskRequest;
        }

        public Task ExecuteAsync()
        {
            return  this.taskRepository.CreateTask(this.TransCreateTaskRequestToBaseTask(this.createTaskRequest));
           
        }

        private BaseTask TransCreateTaskRequestToBaseTask(CreateTaskRequest createTaskRequest)
        {
            return new BaseTask()
            {
                Title = createTaskRequest.Title,
                DueDate = createTaskRequest.DueDate,
                Status =   createTaskRequest.Status,
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedBy = Guid.NewGuid(),
                UpdatedOn = DateTime.Now,
            };
        }
    }
}
