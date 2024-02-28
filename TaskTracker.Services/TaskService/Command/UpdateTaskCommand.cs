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
    public class UpdateTaskCommand : ICommandHandler<UpdateTaskRequest>
    {
        private readonly ITaskRepository taskRepository;
        private readonly UpdateTaskRequest updateTaskRequest;

        public UpdateTaskCommand(ITaskRepository taskRepository, UpdateTaskRequest updateTaskRequest)
        {
            this.taskRepository = taskRepository;
            this.updateTaskRequest = updateTaskRequest;
        }

        public Task ExecuteAsync()
        {
            this.taskRepository.CreateTask(this.TransformUpdateTaskRequestToBaseTask(this.updateTaskRequest));
            return Task.CompletedTask;
        }

        private BaseTask TransformUpdateTaskRequestToBaseTask(UpdateTaskRequest updateTaskRequest)
        {
            return new BaseTask()
            {
                Id = updateTaskRequest.Id,
                Title = updateTaskRequest.Title,
                DueDate = updateTaskRequest.DueDate,
                Status = updateTaskRequest.Status,
                //Ideally should be extracted from Requesting user, for time sake stamping empty
                UpdatedBy = Guid.Empty,
                UpdatedOn = DateTime.UtcNow,
            };
        }
    }
}
