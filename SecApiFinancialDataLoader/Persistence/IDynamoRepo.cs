using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Persistence
{
    public interface IDynamoRepo
    {
        public Task<string> GetCikNumber_By_TickerSymbol(string tickerSymbol);
    }
}
