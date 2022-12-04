using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.AboutvacancieDto;
using Vacancy.Repository.Dto.CompanyDto;

namespace Vacancy.Repository.Repositories
{
    public class CompanyRepositories
    {
        private readonly VacancyDbContext _ctx;

        public CompanyRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            _ctx.Companies.Add(company);
            await _ctx.SaveChangesAsync();
            return _ctx.Companies.FirstOrDefault(x => x.CompanyName == company.CompanyName);
        }

        public Company GetCompany(int id)
        {
            return _ctx.Companies.Include(x => x.Information).Include(x => x.Logotype).Include(x => x.Fieldactivity).FirstOrDefault(x => x.CompanyId == id);
        }

        public Company GetCompanyByName(string name)
        {
            return _ctx.Companies.Include(x => x.Information).Include(x => x.Logotype).Include(x => x.Fieldactivity).FirstOrDefault(x => x.CompanyName == name);
        }

        public List<Company> GetCompanies()
        {
            var modelList = _ctx.Companies.ToList();
            return modelList;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            _ctx.Remove(GetCompany(id));
            await _ctx.SaveChangesAsync();
        }
    }
}



