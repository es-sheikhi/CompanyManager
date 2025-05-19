using CompanyManager.Application.Repositories;
using CompanyManager.Domain.Entities;
using CompanyManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDbContext _companyDbContext;

        public CompanyRepository(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }

        public async Task<Company> AddCompany(Company company)
        {
            company.Id = Guid.NewGuid();
            await _companyDbContext.Companies.AddAsync(company);
            await _companyDbContext.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            Company? company = await _companyDbContext.Companies.FindAsync(id);
            if (company != null)
            {
                _companyDbContext.Remove(company);
                await _companyDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyDbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyById(Guid id)
        {
            Company company = await _companyDbContext.Companies.FindAsync(id);
            return company;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _companyDbContext.Companies.Update(company);
            await _companyDbContext.SaveChangesAsync();
            return company;
        }
    }
}
