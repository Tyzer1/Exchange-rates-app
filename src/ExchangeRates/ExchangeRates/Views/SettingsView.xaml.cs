using ExchangeRates.Presentation.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExchangeRates.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsView : ContentPage
	{
        public ObservableCollection<CurrencyViewModel> CurrencySettings { get; private set; }

        public MainPage ParentPage { get; private set; }
		public SettingsView (MainPage parent)
		{
			InitializeComponent();
            ParentPage = parent;
            InitViewModel();
		}

        public async void InitViewModel()
        {
            try
            {
                var settings = await ParentPage.SettingsController.GetSettingsAsync();
                CurrencySettings =
                    new ObservableCollection<CurrencyViewModel>(settings);
            }
            catch
            {
                await DisplayAlert("Ошибка", "Не удалось получить курсы валют", "Ok");
            }
            lvCurrencies.ItemsSource = CurrencySettings;
        }

        public void Back_click(object sender, EventArgs e)
		{
            Application.Current.MainPage = ParentPage;
        }

        public void Ok_click(object sender, EventArgs e)
        {
            ParentPage.SettingsController.SaveSettings(CurrencySettings);
            //Implement settings right now
            ParentPage.InitViewModel();
            Application.Current.MainPage = ParentPage;
        }
	}
}