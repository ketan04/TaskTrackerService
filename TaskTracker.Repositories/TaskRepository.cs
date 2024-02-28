using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace TaskTracker.Respositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDatabaseContext databaseContext;
        public TaskRepository(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<int> CreateTask(BaseTask task)
        {
            try
            {
                this.databaseContext.Task.Add(task);
                return this.databaseContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //Log error message
                // remove sensitive information and throw handled error message, as of now just throw
                throw ex;
            }
        }

        public async Task<List<BaseTask>> GetTaskList()
        {
            try
            {
                return this.databaseContext.Task.ToList();
            }
            catch (Exception ex)
            {
                //Log error message
                // remove sensitive information and throw handled error message, as of now just throw
                throw ex;
            }
        }

        public Task<int> UpdateTask(BaseTask task)
        {
            try
            {
                this.databaseContext.Task.Update(task);
                //Don't like two seperate calls should think about refactoring
                return this.databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Log error message
                // remove sensitive information and throw handled error message, as of now just throw
                throw ex;
            }
        }
    }
}
