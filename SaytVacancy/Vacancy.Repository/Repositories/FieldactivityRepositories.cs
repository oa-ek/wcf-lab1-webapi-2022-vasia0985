using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.FieldactivityDto;

namespace Vacancy.Repository.Repositories
{
    public class FieldactivityRepositories
    {
        private readonly VacancyDbContext _ctx;

        public FieldactivityRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Fieldactivity> AddFieldactivityAsync(Fieldactivity type)
        {
            _ctx.Fieldactivities.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == type.FieldactivityName);
        }

        public List<Fieldactivity> GetFieldactivities()
        {
            var typeList = _ctx.Fieldactivities.ToList();
            return typeList;
        }

        public Fieldactivity GetFieldactivity(int id)
        {
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityId == id);
        }

        public Fieldactivity GetFieldactivityByName(string name)
        {
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == name);
        }

        public async Task DeleteFieldactivityAsync(int id)
        {
            _ctx.Remove(GetFieldactivity(id));
            await _ctx.SaveChangesAsync();
        }

    }
}
