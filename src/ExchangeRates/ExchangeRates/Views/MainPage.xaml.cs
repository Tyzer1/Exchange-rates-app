﻿using System.Collections.ObjectModel;
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
        private ObservableCollection<CurrencyViewModel> _currencyRates;
        private List<DateTime> _currencyDates;
         
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
            IEnumerable<CurrencyViewModel> currenciesViewModel = await RatesController.GetViewModel();
            _currencyRates = new ObservableCollection<CurrencyViewModel>(currenciesViewModel);
            _currencyDates = RatesController.GetDates().ToList();
            UpdateViewModel();
        }

        public async void UpdateViewModel()
        {
            try
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
                        Rate1 = _currencyRates.First(y => x.CharCode == y.CharCode).Rate1,
                        Rate2 = _currencyRates.First(y => x.CharCode == y.CharCode).Rate2
                    });
                lDate1.Text = _currencyDates[0].Date.ToString("dd'/'MM'/'yy");
                lDate2.Text = _currencyDates[1].Date.ToString("dd'/'MM'/'yy");
                _currencyRates = new ObservableCollection<CurrencyViewModel>(filteredCurrencies);
                lvCurrencies.ItemsSource = _currencyRates;
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
