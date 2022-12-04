using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.InformationDto;

namespace Vacancy.Repository.Repositories
{
    public class InformationRepositories
    {
        private readonly VacancyDbContext _ctx;

        public InformationRepositories(VacancyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Information> AddInformationAsync(Information type)
        {
            _ctx.Informations.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Informations.FirstOrDefault(x => x.InformationName == type.InformationName);
        }

        public List<Information> GetInformations()
        {
            var typeList = _ctx.Informations.ToList();
            return typeList;
        }

        public Information GetInformation(int id)
        {
            return _ctx.Informations.FirstOrDefault(x => x.InformationId == id);
        }

        public Information GetInformationByName(string name)
        {
            return _ctx.Informations.FirstOrDefault(x => x.InformationName == name);
        }

        public async Task DeleteInformationAsync(int id)
        {
            _ctx.Remove(GetInformation(id));
            await _ctx.SaveChangesAsync();
        }

    }
}
