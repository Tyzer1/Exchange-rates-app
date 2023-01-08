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
		public SettingsView ()
		{
			InitializeComponent();
            try
            {
                BindingContext = new SettingsViewModel(Navigation);
            }
            catch
            {
                DisplayAlert("Ошибка", "Не удалось получить курсы валют", "Ok");
            }
        }
	}
}