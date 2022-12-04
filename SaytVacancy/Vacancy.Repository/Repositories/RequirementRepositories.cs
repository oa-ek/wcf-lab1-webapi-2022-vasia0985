using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.RequirementDto;

namespace Vacancy.Repository.Repositories
{
    public class RequirementRepositories
    {
        private readonly VacancyDbContext _ctx;

        public RequirementRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Requirement> AddRequirementAsync(Requirement type)
        {
            _ctx.Requirements.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Requirements.FirstOrDefault(x => x.RequirementName == type.RequirementName);
        }

        public List<Requirement> GetRequirements()
        {
            var typeList = _ctx.Requirements.ToList();
            return typeList;
        }

        public Requirement GetRequirement(int id)
        {
            return _ctx.Requirements.FirstOrDefault(x => x.RequirementId == id);
        }

        public Requirement GetRequirementByName(string name)
        {
            return _ctx.Requirements.FirstOrDefault(x => x.RequirementName == name);
        }

        public async Task DeleteRequirementAsync(int id)
        {
            _ctx.Remove(GetRequirement(id));
            await _ctx.SaveChangesAsync();
        }

    }
}
