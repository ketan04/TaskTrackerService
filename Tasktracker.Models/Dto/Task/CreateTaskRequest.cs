using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models.Dto.Task
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }
    }
}
