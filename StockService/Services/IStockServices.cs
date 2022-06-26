using StockService.Models.StockDetails;
using System;
using System.Threading.Tasks;

namespace StockService.Services
{
    public interface IStockServices
    {
        Task<StockResponse> Get(string code, DateTime startDate, DateTime endDate);

        Task<StockRequest> Create(StockRequest stock);

        Task Delete(string code);
    }
}
