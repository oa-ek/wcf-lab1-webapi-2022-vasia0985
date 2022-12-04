using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.SkillDto;

namespace Vacancy.Repository.Repositories
{
    public class SkillRepositories
    {

        private readonly VacancyDbContext _ctx;

        public SkillRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Skill> AddSkillAsync(Skill type)
        {
            _ctx.Skills.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Skills.FirstOrDefault(x => x.SkillName == type.SkillName);
        }

        public List<Skill> GetSkills()
        {
            var typeList = _ctx.Skills.ToList();
            return typeList;
        }

        public Skill GetSkill(int id)
        {
            return _ctx.Skills.FirstOrDefault(x => x.SkillId == id);
        }

        public Skill GetSkillByName(string name)
        {
            return _ctx.Skills.FirstOrDefault(x => x.SkillName == name);
        }

        public async Task DeleteSkillAsync(int id)
        {
            _ctx.Remove(GetSkill(id));
            await _ctx.SaveChangesAsync();
        }

    }
}
