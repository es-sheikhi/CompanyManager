using Asp.Versioning;
using CompanyManager.Application.Repositories;
using CompanyManager.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.API.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompaniesController> _logger;

        public CompaniesController(ICompanyRepository companyRepository, ILogger<CompaniesController> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            _logger.LogInformation("Fetching all companies...");
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
