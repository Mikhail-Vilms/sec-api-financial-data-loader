using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using SecApiFinancialDataLoader.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecApiFinancialDataLoader.Persistence
{
    public class DynamoRepo : IDynamoRepo
    {
        private readonly string _tableName = "Sec-Api-Financial-Data";

        public async Task<string> GetCikNumber_By_TickerSymbol(string tickerSymbol)
        {
            using var ddbClient = new AmazonDynamoDBClient(RegionEndpoint.USWest2);
            var dynamoTable = Table.LoadTable(ddbClient, _tableName, true);

            Document doc = await dynamoTable.GetItemAsync(tickerSymbol, "CIK_NUMBER_LOOKUP");
            if (doc == null)
            {
                return "";
            }

            Lookup_By_TickerSymbol_DynamoItem item = JsonSerializer
                .Deserialize<Lookup_By_TickerSymbol_DynamoItem>(doc.ToJson());

            return item.CikNumber;
        }
    }
}
