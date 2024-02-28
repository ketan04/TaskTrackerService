using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Interfaces.Common;
using TaskTracker.Interfaces.Repositories;
using TaskTracker.Models.Dto.Task;

namespace TaskTracker.Services.TaskService.Query
{
    public class GetTaskListQuery : IQueryHandler<IList<GetTaskListResponse>>
    {
        private readonly ITaskRepository taskRepository;

        public GetTaskListQuery(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<IList<GetTaskListResponse>> ExecuteAsync()
        {
            return TransformEntityToQueryResponseModel(await this.taskRepository.GetTaskList());
        }

        private IList<GetTaskListResponse> TransformEntityToQueryResponseModel(IList<BaseTask> tasks)
        {
            IList<GetTaskListResponse> responseTaskList = new List<GetTaskListResponse>();
            foreach (BaseTask task in tasks)
            {
                responseTaskList.Add(new GetTaskListResponse()
                {
                    Id = task.Id,
                    DueDate = task.DueDate,
                    Status = task.Status,
                    Title = task.Title
                });
            }
            return responseTaskList;
        }
    }
}
