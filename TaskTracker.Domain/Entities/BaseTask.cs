using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Common;

namespace TaskTracker.Domain.Entities
{
    /// <summary>
    /// Class is named as BaseTask to avoid conflicts with Threading.Task
    /// </summary>
    public class BaseTask : BaseEntity
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
