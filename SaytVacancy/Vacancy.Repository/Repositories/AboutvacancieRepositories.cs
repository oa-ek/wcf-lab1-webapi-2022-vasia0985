using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.AboutvacancieDto;

namespace Vacancy.Repository.Repositories
{
    public class AboutvacancieRepositories
    {
        private readonly VacancyDbContext _ctx;

        public AboutvacancieRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Aboutvacancie> AddAboutvacancieAsync(Aboutvacancie type)
        {
            _ctx.Aboutvacancies.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Aboutvacancies.FirstOrDefault(x => x.AboutvacancieName == type.AboutvacancieName);
        }

        public List<Aboutvacancie> GetAboutvacancies()
        {
            var typeList = _ctx.Aboutvacancies.ToList();
            return typeList;
        }

        public Aboutvacancie GetAboutvacancie(int id)
        {
            return _ctx.Aboutvacancies.FirstOrDefault(x => x.AboutvacancieId == id);
        }

        public Aboutvacancie GetAboutvacancieByName(string name)
        {
            return _ctx.Aboutvacancies.FirstOrDefault(x => x.AboutvacancieName == name);
        }

        public async Task DeleteAboutvacancieAsync(int id)
        {
            _ctx.Remove(GetAboutvacancie(id));
            await _ctx.SaveChangesAsync();
        }
    }
}

