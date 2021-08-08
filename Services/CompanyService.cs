using companyservice.DbSetting;
using companyservice.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace companyservice.Services
{
    public class CompanyService
    {
        private readonly IMongoCollection<Company> _company;
        public CompanyService(IEStockMarketDatabaseSetting config)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
                       new MongoUrl(config.ConnectionString));

            settings.SslSettings =
                                 new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            var client = new MongoClient(settings);
            var database = client.GetDatabase(config.DatabaseName);
            _company = database.GetCollection<Company>(config.CompanyCollectionName);
        }


        public List<Company> Get()
        {
            List<Company> company;
            company = _company.Find(com => true).ToList();
            return company;
        }

        public Company Get(string companyCode) =>
            _company.Find<Company>(com => com.CompanyCode == companyCode).FirstOrDefault();

        public Company Register(Company company)
        {
            _company.InsertOne(company);
            return company;
        }

        public void Remove(string companyCode) =>
            _company.DeleteOne(Company => Company.CompanyCode == companyCode);

    }
}
