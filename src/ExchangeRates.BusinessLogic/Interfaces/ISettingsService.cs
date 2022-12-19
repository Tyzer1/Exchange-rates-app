using ExchangeRates.BusinessLogic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.BusinessLogic.Interfaces
{
    public interface ISettingsService
    {
        Task<IEnumerable<CurrencyDTO>> GetSettingsAsync();
        void SaveSettings(IEnumerable<CurrencyDTO> settings);
    }
}
