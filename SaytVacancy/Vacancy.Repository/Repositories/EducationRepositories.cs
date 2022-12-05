using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vacancy.Core;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Dto.ResumeDto;

namespace Vacancy.Repository.Repositories
{
    public class EducationRepositories
    {

        private readonly VacancyDbContext _ctx;
        private readonly IMapper _mapper;

        public EducationRepositories(VacancyDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EducationDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _ctx.Educations.ToListAsync());
        }
        public async Task<Education> AddEducationAsync(Education type)
        {
            _ctx.Educations.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Educations.FirstOrDefault(x => x.EducationName == type.EducationName);
        }       
        public List<Education> GetEducations()
        {
            var typeList = _ctx.Educations.ToList();
            return typeList;
        }

        public async Task<Education> AddEducationByDtoAsync(EducationCreateDto educationDto)
        {
            var education = new Education();
            education.EducationName = educationDto.EducationName;            
            _ctx.Educations.Add(education);
            await _ctx.SaveChangesAsync();
            return _ctx.Educations.FirstOrDefault(x => x.EducationName == education.EducationName);
        }
        public Education GetEducation(int id)
        {
            return _ctx.Educations.FirstOrDefault(x => x.EducationId == id);
        }

        public Education GetEducationByName(string name)
        {
            return _ctx.Educations.FirstOrDefault(x => x.EducationName == name);
        }

        public async Task DeleteEducationAsync(int id)
        {
            _ctx.Remove(GetEducation(id));
            await _ctx.SaveChangesAsync();
        }
        public async Task UpdateEducationAsync(EducationCreateDto updatedEducation)
        {
            var education = _ctx.Educations.FirstOrDefault(x => x.EducationId == updatedEducation.EducationId);
            education.EducationName = updatedEducation.EducationName;
            await _ctx.SaveChangesAsync();
        }
    }
}
