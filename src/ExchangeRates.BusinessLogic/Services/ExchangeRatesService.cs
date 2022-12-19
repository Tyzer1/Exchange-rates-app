using ExchangeRates.BusinessLogic.DTO;
using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.BusinessLogic.Interfaces;
using ExchangeRates.DataAccess.Entities;
using ExchangeRates.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.BusinessLogic.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private IDataProvider<Currency> _provider;
        public IEnumerable<DateTime> Dates { get; private set; }
        public ExchangeRatesService()
        {
            _provider = IocRegistrator.Container.Create<IDataProvider<Currency>>();
        }

        public async Task<IEnumerable<CurrencyDTO>> GetExchangeRatesAsync()
        {
            var rates1 = await _provider.GetByDateAsync(DateTime.Today);
            var rates2 = await _provider.GetByDateAsync(DateTime.Today.AddDays(1));
            Dates = new List<DateTime> { DateTime.Today, DateTime.Today.AddDays(1) };
            if (rates2.Count() == 0)
            {
                rates2 = rates1;
                rates1 = await _provider.GetByDateAsync(DateTime.Today.AddDays(-1));
                Dates = new List<DateTime> { DateTime.Today.AddDays(-1), DateTime.Today };
            }
            var currenciesDTO = rates1.Select(x =>
            new CurrencyDTO
            {
                CharCode = x.CharCode,
                Scale = x.Scale,
                Name = x.Name,
                Rate1 = x.Rate,
                Rate2 = rates2.First(y => x.Name == y.Name).Rate
            }).ToList();
            return currenciesDTO;
        }

        public IEnumerable<DateTime> GetDates()
        {
            return Dates;
        }
    }
}