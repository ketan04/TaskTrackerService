using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using FluentMigrator;
using FluentMigrator.Builders.Alter.Table;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Builders.IfDatabase;
using FluentMigrator.Infrastructure;

namespace TaskTracker.Database.Migrations
{
    [ExcludeFromCodeCoverage]
    public static class FluentMigratorExtensions
    {
        public static ICreateTableWithColumnSyntax AddBaseEntityFields(this ICreateTableWithColumnSyntax table)
        {
            return table
                .WithColumn("created_by").AsGuid().NotNullable()
                .WithColumn("created_on").AsDateTime().NotNullable()
                .WithColumn("updated_by").AsGuid().NotNullable()
                .WithColumn("updated_on").AsDateTime().NotNullable();
        }

        public static ICreateTableWithColumnSyntax AddKeyFields(this ICreateTableWithColumnSyntax table)
        {
            return table
                .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid);
        }
    }
}