using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace TaskTracker.Database.Migrations.Tables
{
    [ExcludeFromCodeCoverage]
    [Migration(202402281059)]
    public class AddTasksTable : Migration
    {
        private const string tasksTableName = "tasks";

        public override void Down()
        {
            if (Schema.Table(tasksTableName).Exists())
            {
                Delete.Table(tasksTableName);
            }
        }

        public override void Up()
        {
            if (!Schema.Table(tasksTableName).Exists())
            {
                  Create.Table(tasksTableName)
                      .AddKeyFields()
                      .WithColumn("title").AsString().NotNullable()
                      .WithColumn("due_date").AsDateTime2()
                      .WithColumn("status").AsString(100).NotNullable()
                      .AddBaseEntityFields();
            }
        }
    }
}
