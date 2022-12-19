using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.DataAccess.Interfaces
{
    public interface IDataProvider<T> where T : class
    {
        /// <summary>
        /// Get all data for 1 day
        /// </summary>
        Task<IEnumerable<T>> GetByDateAsync(DateTime date);
    }
}
