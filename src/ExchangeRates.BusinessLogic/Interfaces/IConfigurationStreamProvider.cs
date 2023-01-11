using System;
using System.IO;
using System.Threading.Tasks;

namespace ExchangeRates.BusinessLogic.Interfaces
{
    public interface IConfigurationStreamProvider : IDisposable
    {
        Task<Stream> GetStreamAsync();
    }
}
