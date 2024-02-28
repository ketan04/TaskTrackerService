using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Interfaces;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Services;
using TaskTracker.Models.Dto.Task;


namespace TaskTracker.Services.TaskService
{
    public class TaskService : ITaskService
    {

        public async Task<IList<GetTaskListResponse>> GetTaskList(IQueryHandler<IList<GetTaskListResponse>> queryHandler)
        {
            return await queryHandler.ExecuteAsync();
        }

        public async Task CreateTask (ICommandHandler<CreateTaskRequest> commandHandler)
        {
            await commandHandler.ExecuteAsync();
        }

        public async Task UpdateTask(ICommandHandler<UpdateTaskRequest> commandHandler)
        {
            await commandHandler.ExecuteAsync();
        }
    }
}
