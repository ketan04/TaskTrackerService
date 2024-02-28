using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Interfaces.Common
{
    public interface IDatabaseConnectionHelper
    {
        /// <summary>
        /// Query.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="param">param.</param>
        /// <param name="commandType">commandType.</param>
        void QueryAync(string sqlQuery, object param, CommandType commandType);

        /// <summary>
        /// Query.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="param">param.</param>
        /// <returns>rows.</returns>
        IEnumerable<TReturn> Query<TReturn>(string sqlQuery, object param = null);

        /// <summary>
        /// Query.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="param">param.</param>
        /// <param name="commandType">commandType.</param>
        /// <returns>rows.</returns>
        IEnumerable<TReturn> Query<TReturn>(string sqlQuery, object param, CommandType commandType);

        /// <summary>
        /// QueryAsync.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="param">param.</param>
        /// <param name="commandType">commandType.</param>
        /// <returns>rows.</returns>
        Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sqlQuery, object param, CommandType commandType);

        /// <summary>
        /// Execute.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="param">param.</param>
        /// <returns>rows affected.</returns>
        int Execute(string sqlQuery, object param = null);

        /// <summary>
        /// Execute.
        /// </summary>
        /// <typeparam name="TReturn">TReturn.</typeparam>
        /// <param name="sqlQuery">sqlQuery.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="param">param.</param>
        /// <returns>rows of result.</returns>
        Task<int> ExecuteAync(string sqlQuery, CommandType commandType, object param = null);
    }
}
