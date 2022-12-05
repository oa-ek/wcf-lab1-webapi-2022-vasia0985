using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Core;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Repositories;

namespace VacancyApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class EducationApiController : ControllerBase
    {        
        private readonly EducationRepositories educationApiRepositories;
        private readonly ILogger<EducationApiController> _logger;
        public EducationApiController(ILogger<EducationApiController> logger, EducationRepositories educationApiRepositories)
        {
            _logger = logger;
            this.educationApiRepositories = educationApiRepositories;
        }
        [HttpGet]
        public EducationRepositories GetEducationRepositories()
        {
            return educationApiRepositories;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEducationListAsync")] 
        public async Task<IEnumerable<EducationDto>> GetListAsync()
        {
            return await educationApiRepositories.GetListAsync();
        }
        [HttpPost]
        public async Task<Education> Create(EducationCreateDto educationDto)
        {
            var createdEducation = await educationApiRepositories.AddEducationByDtoAsync(educationDto);
            return createdEducation;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await educationApiRepositories.DeleteEducationAsync(id);
        }

        [HttpPut]
        public async Task Edit(EducationCreateDto educ)
        {
            await educationApiRepositories.UpdateEducationAsync(educ);
        }
    }
}
