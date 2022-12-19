using ExchangeRates.BusinessLogic.Infrastructure;
using ExchangeRates.Presentation.Views;
using Xamarin.Forms;


namespace ExchangeRates.Presentation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
