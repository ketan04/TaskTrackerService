﻿using System;
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
        public  Task<List<GetTaskListResponse>> GetTaskList(IQueryHandler<List<GetTaskListResponse>> queryHandler);

        public  Task CreateTask(ICommandHandler<CreateTaskRequest> commandHandler);

        public Task UpdateTask(ICommandHandler<UpdateTaskRequest> commandHandler);
    }
}
