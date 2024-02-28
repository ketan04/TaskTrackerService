using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTacker.DataAccess.EntityConfiguration;
using TaskTracker.Domain.Entities;
using TaskTracker.Interfaces.Common;

namespace TaskTacker.DataAccess
{
    public  class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
        /// <summary>
        /// Try to use this to always append entity with base audit fields
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
           return base.SaveChanges(true);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<BaseTask> Task { get; set; }
    }
}
