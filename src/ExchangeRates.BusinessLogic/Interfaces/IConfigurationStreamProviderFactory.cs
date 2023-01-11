using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates.BusinessLogic.Interfaces
{
    public interface IConfigurationStreamProviderFactory
    {
        IConfigurationStreamProvider Create();
    }
}
