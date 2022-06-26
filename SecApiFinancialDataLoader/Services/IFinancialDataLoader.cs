using System;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public interface IFinancialDataLoader
    {
        public Task Load(string tickerSymbols, Action<string> logger);
    }
}
