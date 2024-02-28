using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Interfaces.Common
{
    public interface IDatabaseContext
    {
        public DbSet<BaseTask> Task { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
