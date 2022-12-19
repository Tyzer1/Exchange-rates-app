using ExchangeRates.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.BusinessLogic.Interfaces
{
    public interface IExchangeRatesService
    {
        /// <summary>
        /// Get CurrencyDTO with rates for 2 days
        /// </summary>
        Task<IEnumerable<CurrencyDTO>> GetExchangeRatesAsync();
        /// <summary>
        /// Get dates for current exchange rates
        /// </summary>
        Task<IEnumerable<DateTime>> GetDates();
    }
}
