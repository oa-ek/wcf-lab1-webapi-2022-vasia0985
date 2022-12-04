using AutoMapper;
using Vacancy.Core;
using Vacancy.Repository.Dto;
using Vacancy.Repository.Dto.EducationDto;

namespace Vacancy.Mapper
{   
        public class AppAutoMapper : Profile
        {
            public AppAutoMapper()
            {
                CreateMap<EducationDto, Education>();
                CreateMap<Education, EducationDto>();
            }
        }
    }
