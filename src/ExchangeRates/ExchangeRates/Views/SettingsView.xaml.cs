using Acr.UserDialogs;
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
            BindingContext = new SettingsViewModel(UserDialogs.Instance, Navigation);
        }
	}
}