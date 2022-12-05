using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;
        public SkillRepositories(VacancyDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SkillDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<SkillDto>>(await _ctx.Skills.ToListAsync());
        }

        public async Task<Skill> AddSkillByDtoAsync(SkillCreateDto skillDto)
        {
            var skill = new Skill();
            skill.SkillName = skillDto.SkillName;
            _ctx.Skills.Add(skill);
            await _ctx.SaveChangesAsync();
            return _ctx.Skills.FirstOrDefault(x => x.SkillName == skill.SkillName);
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
        public async Task UpdateSkillAsync(SkillCreateDto updatedSkill)
        {
            var skill = _ctx.Skills.FirstOrDefault(x => x.SkillId == updatedSkill.SkillId);
            skill.SkillName = updatedSkill.SkillName;
            await _ctx.SaveChangesAsync();
        }
    }
}

