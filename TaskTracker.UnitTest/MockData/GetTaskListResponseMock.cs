using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Models.Dto.Task;

namespace TaskTracker.Test.MockData
{
    internal class GetTaskListResponseMock
    {
        
        public List<GetTaskListResponse> GetTaskListResponse()
        {
            return new List<GetTaskListResponse>()
            {
                new GetTaskListResponse()
                {
                    Id = Guid.NewGuid(),
                    Title = "Create Unit Test",
                    DueDate = DateTime.Now,
                    Status = "Completed"
                }
            };
        }
    }
}
