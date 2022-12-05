using AutoMapper;
using Vacancy.Core;
using Vacancy.Repository.Dto;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Dto.FieldactivityDto;
using Vacancy.Repository.Dto.SkillDto;

namespace Vacancy.Mapper
{   
        public class AppAutoMapper : Profile
        {
            public AppAutoMapper()
            {
                CreateMap<EducationDto, Education>();
                CreateMap<Education, EducationDto>();
                CreateMap<SkillDto,Skill>();
                CreateMap<Skill, SkillDto>();
               CreateMap<FieldactivityDto,Fieldactivity>();
               CreateMap<Fieldactivity, FieldactivityDto>();

        }
        }
    }
