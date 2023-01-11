using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.DataAccess.Interfaces
{
    public interface IDataUrlProvider<T> where T : class
    {
        /// <summary>
        /// Get all data for 1 day from url
        /// </summary>
        Task<IEnumerable<T>> GetByDateAsync(DateTime date, string url);
    }
}
