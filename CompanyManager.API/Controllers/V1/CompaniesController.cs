using Asp.Versioning;
using CompanyManager.Application.Repositories;
using CompanyManager.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            if (companies != null)
            {
                return Ok(companies);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Company company)
        {
            await _companyRepository.AddCompany(company);
            return Ok(company);
        }
    }
}
