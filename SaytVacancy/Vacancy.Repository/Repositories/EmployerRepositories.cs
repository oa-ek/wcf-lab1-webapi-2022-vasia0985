using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Dto.EmployerDto;

namespace Vacancy.Repository.Repositories
{
    public class EmployerRepositories
    {
        private readonly VacancyDbContext _ctx;

        public EmployerRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Employer> AddEmployerAsync(Employer type)
        {
            _ctx.Employers.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Employers.FirstOrDefault(x => x.EmployerName == type.EmployerName);
        }

        public List<Employer> GetEmployers()
        {
            var typeList = _ctx.Employers.ToList();
            return typeList;
        }

        public Employer GetEmployer(int id)
        {
            return _ctx.Employers.FirstOrDefault(x => x.EmployerId == id);
        }

        public Employer GetEmployerByName(string name)
        {
            return _ctx.Employers.FirstOrDefault(x => x.EmployerName == name);
        }

        public async Task DeleteEmployerAsync(int id)
        {
            _ctx.Remove(GetEmployer(id));
            await _ctx.SaveChangesAsync();
        }


    }
}
