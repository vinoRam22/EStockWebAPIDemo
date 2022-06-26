using CompanyService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService service, ILogger<CompanyController> logger)
        {
            _logger = logger;
            _companyService = service;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<CompanyResponseModel>> Get()
        {
            try
            {
                var companies = _companyService.GetAll();
                if (companies == null)
                {
                    return Ok(StatusCodes.Status404NotFound);
                }
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("info/{companycode}")]
        public ActionResult<CompanyResponseModel> GetByCode(string companycode)
        {
            try
            {
                var company = _companyService.GetByCode(companycode);

                if (company == null)
                {
                    return Ok(null);
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Post([FromBody] CompanyRequestModel request)
        {
            try
            {
                _companyService.Register(request);
                return Ok(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{companyCode}")]
        //public async Task<IActionResult> Delete(string companycode)
        public ActionResult Delete(string companyCode)
        {
            try
            {
                var company = _companyService.GetByCode(companyCode);

                if (company == null)
                {
                    return Ok(StatusCodes.Status404NotFound);
                }

                //await _publishEndpoint.Publish(new CompanyDetailsQueue() { CompanyCode = companycode });

                _companyService.Delete(companyCode);

                return Ok(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
