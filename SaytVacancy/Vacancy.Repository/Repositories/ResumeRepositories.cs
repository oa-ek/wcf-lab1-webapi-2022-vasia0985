using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.ResumeDto;
using Microsoft.EntityFrameworkCore;

namespace Vacancy.Repository.Repositories
{
    public class ResumeRepositories
    {
        private readonly VacancyDbContext _ctx;

        private readonly UsersRepositories _userRepositories;

        public ResumeRepositories(VacancyDbContext ctx, UsersRepositories userRepositories)
        {
            _ctx = ctx;
            _userRepositories = userRepositories;
        }
        public async Task<Resume> AddResumeAsync(Resume resume)
        {
            _ctx.Resumes.Add(resume);
            await _ctx.SaveChangesAsync();
            return _ctx.Resumes.Include(x => x.Education).Include(x => x.Skill).Include(x => x.Experience).
               Include(x => x.User).
        
               FirstOrDefault();
        }
        public Resume GetResume(int id)
        {
           return _ctx.Resumes.Include(x => x.Education).Include(x => x.Skill).Include(x => x.Experience).
           Include(x => x.User).

           FirstOrDefault();
        }
        public List<Resume> GetResumes()
        {
            var resumeList = _ctx.Resumes.Include(x => x.Education).Include(x => x.Skill).Include(x => x.Experience).
               Include(x => x.User).ToList();

            return resumeList;
        }
        public async Task<ResumeDto> GetResumeDto(int id)
        {
            var v = await _ctx.Resumes.Include(x => x.Education).Include(x => x.Skill).Include(x => x.Experience).
               Include(x => x.User).FirstAsync(x => x.ResumeId == id);

            var resumeDto = new ResumeDto
            {
                ResumeId = v.ResumeId,
                EducationName = v.Education.EducationName,
                SkillName = v.Skill.SkillName,
                ExperienceName = v.Experience.ExperienceName,
                UserId = v.UserId
            };
            return resumeDto;
        }
        public async Task UpdateAsync(ResumeDto resumeDto, string educationName, string skillName,
          string experienceName)
        {
            var resume = _ctx.Resumes.Include(x => x.Education).Include(x => x.Skill).Include(x => x.Experience).
              Include(x => x.User).FirstOrDefault(x => x.ResumeId == resumeDto.ResumeId);

            if (resume.Education.EducationName != educationName)
               resume.Education = _ctx.Educations.FirstOrDefault(x => x.EducationName == educationName);

            if (resume.Skill.SkillName != skillName)
                resume.Skill = _ctx.Skills.FirstOrDefault(x => x.SkillName == skillName);

            if (resume.Experience.ExperienceName != experienceName)
                resume.Experience = _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == experienceName);

            _ctx.SaveChanges();
        }
        public async Task DeleteResumeAsync(int id)
        {
            _ctx.Remove(GetResume(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
