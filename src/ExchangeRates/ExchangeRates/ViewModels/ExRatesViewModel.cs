using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using ExchangeRates.Presentation.Controllers;
using System.Linq;
using System.Windows.Input;
using ExchangeRates.Presentation.Views;

namespace ExchangeRates.Presentation.ViewModels
{
    public class ExRatesViewModel : ObservableObject
    {
        private ObservableCollection<CurrencyViewModel> _currencyRates =
            new ObservableCollection<CurrencyViewModel>();
        public ObservableCollection<CurrencyViewModel> CurrencyRates 
        {
            get { return _currencyRates; }
            set { SetProperty(ref _currencyRates, value); }
        }
        public List<DateTime> CurrencyDates { get; private set; }
        public IEnumerable<CurrencyViewModel> Currencies { get; private set; }
        public RatesController RatesController { get; private set; }
        public SettingsController SettingsController { get; private set; }

        public INavigation Navigation { get; private set; }

        public ICommand OpenSettings { get; }

        public ExRatesViewModel(INavigation pageNav)
        {
            Navigation = pageNav;
            RatesController = new RatesController();
            SettingsController = new SettingsController();

            OpenSettings = new Command(OnOpenSettings);
        }

        public async void InitViewModel()
        {
            if (Currencies == null)
            {
                Currencies = await RatesController.GetViewModelAsync();
                CurrencyDates = RatesController.GetDates().ToList();
            }
            UpdateViewModel();
        }

        private void OnOpenSettings()
        {
            Navigation.PushAsync(new SettingsView());
        }

        public async void UpdateViewModel()
        {
            var currenciesSettings = await SettingsController.GetSettingsAsync();
            var filteredCurrencies = currenciesSettings
                .Where(x => x.IsActive == true)
                .Select(x =>
                new CurrencyViewModel
                {
                    CharCode = x.CharCode,
                    Scale = x.Scale,
                    Name = x.Name,
                    Rate1 = Currencies.First(y => x.CharCode == y.CharCode).Rate1,
                    Rate2 = Currencies.First(y => x.CharCode == y.CharCode).Rate2
                });
            Date1 = CurrencyDates[0].Date.ToString("dd'/'MM'/'yy");
            Date2 = CurrencyDates[1].Date.ToString("dd'/'MM'/'yy");
            CurrencyRates = new ObservableCollection<CurrencyViewModel>(filteredCurrencies);
        }

        private string _date1;
        public string Date1
        {
            get { return _date1; }
            set { SetProperty(ref _date1, value); }
        }

        private string _date2;
        public string Date2
        {
            get { return _date2; }
            set { SetProperty(ref _date2, value); }
        }
    }
}
