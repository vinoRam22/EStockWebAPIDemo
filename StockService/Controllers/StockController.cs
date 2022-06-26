using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockService.Models.StockDetails;
using StockService.Services;
using System;
using System.Threading.Tasks;

namespace StockService.Controllers
{
    [Route("api/v1.0/market/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockServices _stockService;
        private readonly ISender _mediator;

        public StockController(IStockServices stockService, ISender mediator)
        {
            _stockService = stockService;
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> AddStock([FromBody] StockRequest request)
        {
            try
            {
                await _stockService.Create(request);

                return Ok(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex?.Message);
            }
        }

        [Route("get/{companyCode}/{startDate}/{endDate}")]
        [HttpGet]
        public async Task<ActionResult<StockResponse>> Get(string companyCode, DateTime startDate, DateTime endDate)
        {
            try
            {
                var request = new GetStocksByDateModel()
                {
                    CompanyCode = companyCode,
                    StartDate = startDate,
                    EndDate = endDate
                };

                var stockResponse = await _mediator.Send(request);

                return Ok(stockResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex?.Message);
            }
        }
    }
}
