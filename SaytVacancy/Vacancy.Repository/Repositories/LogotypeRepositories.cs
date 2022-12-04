using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.LogotypeDto;

namespace Vacancy.Repository.Repositories
{
    public class LogotypeRepositories
    {
        private readonly VacancyDbContext _ctx;

        public LogotypeRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Logotype> AddLogotypeAsync(Logotype type)
        {
            _ctx.Logotypes.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Logotypes.FirstOrDefault(x => x.LogotypeName == type.LogotypeName);
        }

        public List<Logotype> GetLogotypes()
        {
            var typeList = _ctx.Logotypes.ToList();
            return typeList;
        }

        public Logotype GetLogotype(int id)
        {
            return _ctx.Logotypes.FirstOrDefault(x => x.LogotypeId == id);
        }

        public Logotype GetLogotypeByName(string name)
        {
            return _ctx.Logotypes.FirstOrDefault(x => x.LogotypeName == name);
        }

        public async Task DeleteLogotypeAsync(int id)
        {
            _ctx.Remove(GetLogotype(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
