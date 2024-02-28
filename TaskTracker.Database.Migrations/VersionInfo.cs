using FluentMigrator.Runner.VersionTableInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Database.Migrations
{
    [VersionTableMetaData]
    public class VersionInfo : IVersionTableMetaData
    {
        public string ColumnName
        {
            get { return "version"; }
        }

        public object ApplicationContext { get; set; }

        public bool OwnsSchema { get; }

        public string SchemaName
        {
            get { return ""; }
        }

        public string TableName
        {
            get { return "version_info"; }
        }

        public string UniqueIndexName
        {
            get { return "uc_version"; }
        }

        public virtual string AppliedOnColumnName
        {
            get { return "applied_on"; }
        }

        public virtual string DescriptionColumnName
        {
            get { return "description"; }
        }
    }
}
