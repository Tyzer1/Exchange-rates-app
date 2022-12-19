using ExchangeRates.BusinessLogic.DTO;
using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.BusinessLogic.Interfaces;
using ExchangeRates.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Presentation.Controllers
{
    public class SettingsController
    {
        private ISettingsService _settingsService;
        public SettingsController()
        {
            _settingsService = IocRegistrator.Container.Create<ISettingsService>();
        }

        public async Task<IEnumerable<CurrencyViewModel>> GetSettingsAsync()
        {
            try
            {
                var settings = await _settingsService.GetSettingsAsync();
                var settingsViewModel = settings.Select(x =>
                new CurrencyViewModel
                {
                    CharCode = x.CharCode,
                    Scale = x.Scale,
                    Name = x.Name,
                    IsActive = x.IsActive,
                }).ToList();
                return settingsViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSettings(IEnumerable<CurrencyViewModel> settings)
        {
            var settingsDTO = settings.Select(x =>
            new CurrencyDTO
            {
                CharCode = x.CharCode,
                Scale = x.Scale,
                Name = x.Name,
                IsActive = x.IsActive,
            }).ToList();
            _settingsService.SaveSettings(settingsDTO);
        }
    }
}
