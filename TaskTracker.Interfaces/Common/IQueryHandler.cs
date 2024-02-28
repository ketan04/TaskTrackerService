using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Interfaces.Common
{
    public interface IQueryHandler<TResult>
    {
        /// <summary>
        /// Execute Query async.
        /// </summary>
        /// <returns>TResult.</returns>
        Task<TResult> ExecuteAsync();
    }
}
