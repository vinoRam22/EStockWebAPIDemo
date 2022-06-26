namespace StockService.Models.DatabaseConfig
{
    public class StockDatabaseSettings: IStockDatabaseSettings
    {
        public string StockCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
