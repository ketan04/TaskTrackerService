using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Interfaces.Common
{
    public interface ICommandHandler<TResult>
    {
        /// <summary>
        /// Executes command async.
        /// </summary>
        /// <returns>Tresult.</returns>
        Task ExecuteAsync();

    }
}
