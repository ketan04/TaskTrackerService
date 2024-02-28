using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models.Dto.Task
{
    public class UpdateTaskRequest : CreateTaskRequest
    {
        public Guid Id { get; set; }
    }
}
