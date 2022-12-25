using ExchangeRates.BusinessLogic.Infrastructure;
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
        private SettingsViewModel _settingsViewModel = new SettingsViewModel(); 
        public MainPage ParentPage { get; private set; }
		public SettingsView (MainPage parent)
		{
			InitializeComponent();
            ParentPage = parent;
            InitViewModel();
            BindingContext = _settingsViewModel;
        }

        public async void InitViewModel()
        {
            try
            {
                var settings = await ParentPage.SettingsController.GetSettingsAsync();
                int counter = 0;
                foreach (var c in settings)
                {
                    c.Id = counter++;
                }

                _settingsViewModel.Items =
                    new SortableObservableCollection<CurrencyViewModel>(settings) { SortingSelector = i => i.Id };
            }
            catch
            {
                await DisplayAlert("Ошибка", "Не удалось получить курсы валют", "Ok");
            }
        }

        public void Back_click(object sender, EventArgs e)
		{
            Application.Current.MainPage = ParentPage;
        }

        public void Ok_click(object sender, EventArgs e)
        {
            ParentPage.SettingsController.SaveSettings(_settingsViewModel.Items);
            //Implement settings right now
            ParentPage.InitViewModel();
            Application.Current.MainPage = ParentPage;
        }
	}
}