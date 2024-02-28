using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;

namespace TaskTacker.DataAccess.EntityConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<BaseTask>
    {
        public void Configure(EntityTypeBuilder<BaseTask> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(t => t.Id).HasName("id");
            builder.Property(t => t.Title).HasColumnName("title");
            builder.Property(t => t.DueDate).HasColumnName("due_date");
            builder.Property(t => t.Status).HasColumnName("status");
            builder.Property(t => t.CreatedBy).HasColumnName("created_by");
            builder.Property(t => t.CreatedOn).HasColumnName("created_on");
            builder.Property(t => t.UpdatedBy).HasColumnName("updated_by");
            builder.Property(t => t.UpdatedOn).HasColumnName("updated_on");
        }
    }
}
