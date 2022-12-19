using ExchangeRates.BusinessLogic.Interfaces;
using ExchangeRates.BusinessLogic.Services;
using ExchangeRates.DataAccess.Entities;
using ExchangeRates.DataAccess.Interfaces;
using ExchangeRates.DataAccess.XML;

namespace ExchangeRates.BusinessLogic.Infrastructure
{
    public static class IocRegistrator
    {
        public static IocContainer Container { get; private set; }

        static IocRegistrator()
        {
            Container = new IocContainer();
            Container.Register<IDataProvider<Currency>, XMLProvider>();
            Container.Register<IExchangeRatesService, ExchangeRatesService>();
            Container.Register<ISettingsService, SettingsService>();
        }
    }
}
