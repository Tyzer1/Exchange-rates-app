﻿using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.Presentation.Views;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace ExchangeRates.Presentation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitResources();
            MainPage = new MainPage();
        }

        private void InitResources()
        {
            string url = $"https://www.nbrb.by/services/xmlexrates.aspx?ondate=";
            Preferences.Set("GetRatesUrl", url);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
