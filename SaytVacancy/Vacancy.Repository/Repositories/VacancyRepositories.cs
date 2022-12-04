using Vacancy.Core;
using Vacancy.Repository.Dto.VacancyDto;
using Microsoft.EntityFrameworkCore;

namespace Vacancy.Repository.Repositories
{
    public class VacancyRepositories
    {
        private readonly VacancyDbContext _ctx;

        private readonly UsersRepositories _userRepositories;

        public VacancyRepositories(VacancyDbContext ctx, UsersRepositories userRepositories)
        {
            _ctx = ctx;
            _userRepositories = userRepositories;
        }
        public async Task<Core.Vacancy> AddVacancieAsync(Core.Vacancy vacancie)
        {
            _ctx.Vacancies.Add(vacancie);
            await _ctx.SaveChangesAsync();
            return _ctx.Vacancies.Include(x => x.Company).ThenInclude(x => x.Information).Include(x => x.Company).ThenInclude(x => x.Fieldactivity).Include(x => x.Company).ThenInclude(x => x.Logotype).
               Include(x => x.Requirement).Include(x => x.Aboutvacancie).Include(x => x.Employer).
               Include(x => x.User).

               FirstOrDefault(x => x.Company.CompanyName == vacancie.Company.CompanyName);
        }

        public Core.Vacancy GetVacancie(int id)
        {
            return _ctx.Vacancies.Include(x => x.Company).ThenInclude(x => x.Information).Include(x => x.Company).ThenInclude(x => x.Fieldactivity).Include(x => x.Company).ThenInclude(x => x.Logotype).
              Include(x => x.Requirement).Include(x => x.Aboutvacancie).Include(x => x.Employer).
               Include(x => x.User).

                 FirstOrDefault();
        }

        public List<Core.Vacancy> GetVacancies()
        {
            var vacancyList = _ctx.Vacancies.Include(x => x.Company).ThenInclude(x => x.Information).Include(x => x.Company).ThenInclude(x => x.Fieldactivity).Include(x => x.Company).ThenInclude(x => x.Logotype).
              Include(x => x.Requirement).Include(x => x.Aboutvacancie).Include(x => x.Employer).
               Include(x => x.User).ToList();

            return vacancyList;
        }

        public async Task<VacancyReadDto> GetVacancyDto(int id)
        {
            var v = await _ctx.Vacancies.Include(x => x.Company).ThenInclude(x => x.Information).Include(x => x.Company).ThenInclude(x => x.Fieldactivity).Include(x => x.Company).ThenInclude(x => x.Logotype).
              Include(x => x.Requirement).Include(x => x.Aboutvacancie).Include(x => x.Employer).
               Include(x => x.User).FirstAsync(x => x.VacancieId == id);

            var vacancyDto = new VacancyReadDto
            {
                VacancieId = v.VacancieId,
                RequirementName = v.Requirement?.RequirementName,
                EmployerName = v.Employer?.EmployerName,
                AboutvacancieName = v.Aboutvacancie?.AboutvacancieName,
                CompanyName = v.Company?.CompanyName,               
                InformationName = v.Company?.Information?.InformationName,
                FieldactivityName = v.Company?.Fieldactivity?.FieldactivityName,
                LogotypeName = v.Company?.Logotype?.LogotypeName,
                UserId = v.UserId
            };
            return vacancyDto;
        }
        public async Task UpdateAsync(VacancyReadDto vacancyDto, string requirementName, string employerName,
          string aboutvacancieName, string companyName, string informationName, string fieldactivityName, string logotypeName)
        {
            var vacancy = _ctx.Vacancies.Include(x => x.Company).ThenInclude(x => x.Information).Include(x => x.Company).ThenInclude(x => x.Fieldactivity).Include(x => x.Company).ThenInclude(x => x.Logotype).
              Include(x => x.Requirement).Include(x => x.Aboutvacancie).Include(x => x.Employer).
              Include(x => x.User).FirstOrDefault(x => x.VacancieId == vacancyDto.VacancieId);

            if (vacancy.Requirement.RequirementName != requirementName)
                vacancy.Requirement = _ctx.Requirements.FirstOrDefault(x => x.RequirementName == requirementName);

            if (vacancy.Employer.EmployerName != employerName)
                vacancy.Employer = _ctx.Employers.FirstOrDefault(x => x.EmployerName == employerName);

            if (vacancy.Aboutvacancie.AboutvacancieName != aboutvacancieName)
                vacancy.Aboutvacancie = _ctx.Aboutvacancies.FirstOrDefault(x => x.AboutvacancieName == aboutvacancieName);

            if (vacancy.Company.CompanyName != companyName)
                vacancy.Company = _ctx.Companies.FirstOrDefault(x => x.CompanyName == companyName);

            if (vacancy.Company.Information.InformationName != informationName)
                vacancy.Company.Information = _ctx.Informations.FirstOrDefault(x => x.InformationName == informationName);

            if (vacancy.Company.Fieldactivity.FieldactivityName != fieldactivityName)
                vacancy.Company.Fieldactivity = _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == fieldactivityName);

            if (vacancy.Company.Logotype.LogotypeName != logotypeName)
                vacancy.Company.Logotype = _ctx.Logotypes.FirstOrDefault(x => x.LogotypeName == logotypeName);

            _ctx.SaveChanges();
        }
        public async Task DeleteVacancyAsync(int id)
        {
            _ctx.Remove(GetVacancie(id));
            await _ctx.SaveChangesAsync();
        }
    }
    

}

