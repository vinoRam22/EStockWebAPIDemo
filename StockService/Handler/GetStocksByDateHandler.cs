using MediatR;
using StockService.Models.StockDetails;
using StockService.Services;
using System.Threading;
using System.Threading.Tasks;

namespace StockService.Handler
{
    public class GetStocksByDateHandler : IRequestHandler<GetStocksByDateModel, StockResponse>
    {
        private readonly IStockServices _stockService;

        public GetStocksByDateHandler(IStockServices stockService)
        {
            _stockService = stockService;
        }

        public async Task<StockResponse> Handle(GetStocksByDateModel request, CancellationToken cancellationToken)
        {
            var products =  await _stockService.Get(request.CompanyCode, request.StartDate, request.EndDate);
            return products;
        }
    }
}
