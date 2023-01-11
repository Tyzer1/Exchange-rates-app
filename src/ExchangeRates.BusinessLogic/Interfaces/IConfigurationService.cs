using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ExchangeRates.BusinessLogic.Models;

namespace ExchangeRates.BusinessLogic.Interfaces
{
    public interface IConfigurationService
    {
        Task<Configuration> GetAsync(CancellationToken cancellationToken);
    }
}
