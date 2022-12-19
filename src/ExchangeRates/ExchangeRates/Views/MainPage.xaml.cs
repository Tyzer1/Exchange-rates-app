using System.Collections.ObjectModel;
using Xamarin.Forms;
using ExchangeRates.Presentation.ViewModels;
using ExchangeRates.Presentation.Controllers;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ExchangeRates.Presentation.Views
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CurrencyViewModel> CurrenciesRates { get; private set; }
        public RatesController RatesController { get; private set; }
        public SettingsController SettingsController { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            RatesController = new RatesController();
            SettingsController = new SettingsController();
            InitViewModel();
        }

        public async void InitViewModel()
        {
            IEnumerable<CurrencyViewModel> currenciesViewModel;
            try
            {
                currenciesViewModel = await RatesController.GetViewModel();
                var currenciesSettings = await SettingsController.GetSettingsAsync();
                var filteredCurrencies = currenciesSettings
                    .Where(x => x.IsActive == true)
                    .Select(x =>
                    new CurrencyViewModel
                    {
                        CharCode = x.CharCode,
                        Scale = x.Scale,
                        Name = x.Name,
                        Rate1 = currenciesViewModel.First(y => x.CharCode == y.CharCode).Rate1,
                        Rate2 = currenciesViewModel.First(y => x.CharCode == y.CharCode).Rate2
                    });
                var dates = RatesController.GetDates();
                List<DateTime> datesList = dates.ToList();
                lDate1.Text = datesList[0].Date.ToString("dd'/'MM'/'yy");
                lDate2.Text = datesList[1].Date.ToString("dd'/'MM'/'yy");
                CurrenciesRates = new ObservableCollection<CurrencyViewModel>(filteredCurrencies);
                lvCurrencies.ItemsSource = CurrenciesRates;
            }
            catch
            {
                await DisplayAlert("Ошибка", "Не удалось получить курсы валют", "Ok");
            }
        }

        public void Settings_click(object sender, EventArgs e)
        {
            SettingsView newView = new SettingsView(this);
            Application.Current.MainPage = newView;
        }
    }
}
