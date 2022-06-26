using CompanyService.Entities;
using CompanyService.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CompanyService
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IMongoCollection<Company> _companies;
        public CompanyRepository(ICompanyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _companies = database.GetCollection<Company>(settings.CompanyCollectionName);
        }

        public List<Company> Get()
        {
            return this._companies.Find(comp => true).ToList();
        }

        public Company GetByCode(string companyCode)
        {
            return this._companies.Find(comp => comp.Code == companyCode).FirstOrDefault();
        }

        public Company Create(Company company)
        {
            _companies.InsertOne(company);
            return company;
        }

        public void Delete(string code)
        {
            _companies.DeleteOne(comp => comp.Code == code);
        }
    }
}
