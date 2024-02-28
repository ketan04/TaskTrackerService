using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Interfaces.Common;
using TaskTracker.Models.Dto.Task;

namespace TaskTracker.Interfaces.Services
{
    public interface ITaskService
    {
        public  Task<IList<GetTaskListResponse>> GetTaskList(IQueryHandler<IList<GetTaskListResponse>> queryHandler);

        public  Task CreateTask(ICommandHandler<CreateTaskRequest> commandHandler);

        public Task UpdateTask(ICommandHandler<UpdateTaskRequest> commandHandler);
    }
}
