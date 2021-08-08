
namespace companyservice.DbSetting
{
    public class EStockMarketDatabaseSetting : IEStockMarketDatabaseSetting
    {
        public string CompanyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }



    public interface IEStockMarketDatabaseSetting
    {
        string CompanyCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
