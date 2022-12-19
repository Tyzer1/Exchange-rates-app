﻿using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.BusinessLogic.Interfaces;
using ExchangeRates.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Presentation.Controllers
{
    public class RatesController
    {
        private IExchangeRatesService _exchangeRatesService;
        public RatesController()
        {
            _exchangeRatesService = IocRegistrator.Container.Create<IExchangeRatesService>();
        }

        public async Task<IEnumerable<CurrencyViewModel>> GetViewModel()
        {
            var rates = await _exchangeRatesService.GetExchangeRatesAsync();
            var currenciesViewModel = rates.Select(x =>
            new CurrencyViewModel
            {
                CharCode = x.CharCode,
                Scale = x.Scale,
                Name = x.Name,
                Rate1 = x.Rate1,
                Rate2 = x.Rate2
            }).ToList();
            return currenciesViewModel;
        }

        public async Task<IEnumerable<DateTime>> GetDates()
        {
            return await _exchangeRatesService.GetDates();
        }
    }
}