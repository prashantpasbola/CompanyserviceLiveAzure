using Microsoft.AspNetCore.Http;
using companyservice.Model;
using companyservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace companyservice.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1.0/market/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Company>> Get() =>
            _companyService.Get();

        /// [HttpGet]
        // [HttpGet("{companycode:length(24)}", Name = "GetCompany")]
        [HttpGet]
        [Route("info/companycode")]
        public ActionResult<Company> Info(string companycode)
        {
            var emp = _companyService.Get(companycode);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }
        [HttpPost]

        [Route("register")]
        public object Register([FromBody] Company company)
        {
            _companyService.Register(company);

            return new Status
            { Result = "Success", Message = "Employee Details register  Successfully" };

            //   return CreatedAtRoute("GetCompany", new { companycode = company.CompanyCode.ToString() }, company);
        }

        [HttpDelete]
        [Route("delete/companycode")]
        public object Delete(string companyCode)
        {

            var company = _companyService.Get(companyCode);

            if (company == null)
            {
                return NotFound();
            }
            try
            {

                _companyService.Remove(company.CompanyCode);
                return new Status
                { Result = "Success", Message = "Employee Details Delete  Successfully" };
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return NoContent();
            }


        }
    }
}
