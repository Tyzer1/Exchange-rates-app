using ExchangeRates.BusinessLogic.Infrastructure;
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
            MainPage = new NavigationPage(new ExRatesView());
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
