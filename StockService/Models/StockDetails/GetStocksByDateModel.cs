using MediatR;
using System;

namespace StockService.Models.StockDetails
{
    public class GetStocksByDateModel : IRequest<StockResponse>
    {
        public string CompanyCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
