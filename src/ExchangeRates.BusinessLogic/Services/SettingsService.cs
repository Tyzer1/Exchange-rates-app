using ExchangeRates.BusinessLogic.DTO;
using ExchangeRates.BusinessLogic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace ExchangeRates.BusinessLogic.Services
{
    public class SettingsService : ISettingsService
    {
        private IExchangeRatesService _exchangeRatesService;
        public SettingsService()
        {
            _exchangeRatesService = new ExchangeRatesService();
        }

        public async Task<IEnumerable<CurrencyDTO>> GetSettingsAsync()
        {
            string json = Preferences.Get("Currencies", "");
            if (json.Count() == 0)
            {
                var fullCurrencies = await _exchangeRatesService.GetExchangeRatesAsync();
                fullCurrencies
                    .Where(x => x.CharCode == "USD" || x.CharCode == "EUR" || x.CharCode == "RUB")
                    .ForEach(y => y.IsActive = true);
                return fullCurrencies;
            }
            var currencies = JsonConvert.DeserializeObject<IEnumerable<CurrencyDTO>>(json);
            return currencies;
        }

        public void SaveSettings(IEnumerable<CurrencyDTO> settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            Preferences.Set("Currencies", json);
        }
    }
}
