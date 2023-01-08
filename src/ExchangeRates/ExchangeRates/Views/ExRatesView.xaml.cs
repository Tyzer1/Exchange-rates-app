using ExchangeRates.Presentation.Controllers;
using ExchangeRates.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace ExchangeRates.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExRatesView : ContentPage
    {
        private ExRatesViewModel _exRatesViewModel;
        public ExRatesView()
        {
            InitializeComponent();
            _exRatesViewModel = new ExRatesViewModel(UserDialogs.Instance, Navigation);
            BindingContext = _exRatesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _exRatesViewModel.InitViewModel();
        }
    }
}