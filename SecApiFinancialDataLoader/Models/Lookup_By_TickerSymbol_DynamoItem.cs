namespace SecApiFinancialDataLoader.Models
{
    public class Lookup_By_TickerSymbol_DynamoItem
    {
        public string PartitionKey { get; set; }
        public string SortKey { get; set; }
        public string CikNumber { get; set; }
    }
}
