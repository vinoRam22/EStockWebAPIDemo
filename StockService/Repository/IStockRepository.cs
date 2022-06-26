using StockService.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockService.Repository
{
    public interface IStockRepository
    {
        Task<List<Stock>> Get(string code, DateTime startDate, DateTime endDate);

       Task<Stock> Create(Stock stock);

        Task Delete(string code);
    }
}
