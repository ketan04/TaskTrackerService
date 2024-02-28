using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Interfaces.Common;

namespace TaskTracker.Interfaces.Repositories
{
    public  interface ITaskRepository
    {
        public Task<List<BaseTask>> GetTaskList();

        public Task<int> CreateTask(BaseTask task);

        public Task<int> UpdateTask(BaseTask task);


    }
}
