using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.ExperienceDto;

namespace Vacancy.Repository.Repositories
{
    public class ExperienceRepositories
    {
        private readonly VacancyDbContext _ctx;

        public ExperienceRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Experience> AddExperienceAsync(Experience type)
        {
            _ctx.Experiences.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == type.ExperienceName);
        }

        public List<Experience> GetExperiences()
        {
            var typeList = _ctx.Experiences.ToList();
            return typeList;
        }

        public Experience GetExperience(int id)
        {
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceId == id);
        }

        public Experience GetExperienceByName(string name)
        {
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == name);
        }

        public async Task DeleteExperienceAsync(int id)
        {
            _ctx.Remove(GetExperience(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
