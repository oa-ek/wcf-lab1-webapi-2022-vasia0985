using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public FieldactivityRepositories(VacancyDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FieldactivityDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<FieldactivityDto>>(await _ctx.Fieldactivities.ToListAsync());
        }

        public async Task<Fieldactivity> AddFieldactivityByDtoAsync(FieldactivityCreateDto fieldactivitylDto)
        {
            var fieldactivity = new Fieldactivity();
            fieldactivity.FieldactivityName = fieldactivitylDto.FieldactivityName;
            _ctx.Fieldactivities.Add(fieldactivity);
            await _ctx.SaveChangesAsync();
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == fieldactivity.FieldactivityName);
        }
        public async Task<Fieldactivity> AddFieldactivityAsync(Fieldactivity type)
        {
            _ctx.Fieldactivities.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == type.FieldactivityName);
        }

        public List<Fieldactivity> GetFieldactivity()
        {
            var typeList = _ctx.Fieldactivities.ToList();
            return typeList;
        }

        public Fieldactivity GetFieldactivity(int id)
        {
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityId == id);
        }

        public Fieldactivity GetFieldactivitylByName(string name)
        {
            return _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityName == name);
        }

        public async Task DeleteFieldactivityAsync(int id)
        {
            _ctx.Remove(GetFieldactivity(id));
            await _ctx.SaveChangesAsync();
        }
        public async Task UpdateFieldactivityAsync(FieldactivityCreateDto updatedFieldactivity)
        {
            var fieldactivity = _ctx.Fieldactivities.FirstOrDefault(x => x.FieldactivityId == updatedFieldactivity.FieldactivityId);
            fieldactivity.FieldactivityName = updatedFieldactivity.FieldactivityName;
            await _ctx.SaveChangesAsync();
        }
    }
}
