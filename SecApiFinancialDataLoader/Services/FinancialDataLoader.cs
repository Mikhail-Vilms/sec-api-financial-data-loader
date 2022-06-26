using SecApiFinancialDataLoader.Persistence;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Services
{
    public class FinancialDataLoader : IFinancialDataLoader
    {
        private readonly ISnsService _snsService;
        private readonly IDynamoRepo _dynamoRepo;

        public FinancialDataLoader(
            ISnsService snsService,
            IDynamoRepo dynamoRepo)
        {
            _snsService = snsService;
            _dynamoRepo = dynamoRepo;
        }

        public async Task Load(string tickerSymbolsStr, Action<string> logger)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', ';' };
            string[] tickerSymbols = tickerSymbolsStr.Split(delimiterChars);

            IList<string> snsMsgsToPublish = new List<string>();
            foreach (string tickerSymbol in tickerSymbols)
            {
                if (string.IsNullOrWhiteSpace(tickerSymbol))
                {
                    continue;
                }

                logger($"Trying to fetch cik number for next ticker symbol: {tickerSymbol}");

                string cikNumber = await _dynamoRepo.GetCikNumber_By_TickerSymbol(tickerSymbol);

                if (string.IsNullOrWhiteSpace(cikNumber))
                {
                    logger($"Nothing found for the next ticker symbol: {tickerSymbol}");
                    continue;
                }

                logger($"Publishing message to the sns topic: {tickerSymbol}/{cikNumber}");

                snsMsgsToPublish.Add(JsonSerializer.Serialize(new
                {
                    CikNumber = cikNumber,
                    TickerSymbol = tickerSymbol
                }));
            }

            await _snsService.PublishFinancialStatementsToLoadAsync(snsMsgsToPublish);
        }
    }
}
