using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Core;
using Vacancy.Repository.Dto.FieldactivityDto;
using Vacancy.Repository.Repositories;

namespace VacancyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldactivityApiController : ControllerBase
    {
        private readonly FieldactivityRepositories fieldactivityApiRepositories;
        private readonly ILogger<FieldactivityApiController> _logger;
        public FieldactivityApiController(ILogger<FieldactivityApiController> logger, FieldactivityRepositories fieldactivityApiRepositories)
        {
            _logger = logger;
            this.fieldactivityApiRepositories = fieldactivityApiRepositories;
        }
        [HttpGet]
        public FieldactivityRepositories GetFieldactivityRepositories()
        {
            return fieldactivityApiRepositories;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFieldactivityListAsync")]
        public async Task<IEnumerable<FieldactivityDto>> GetListAsync()
        {
            return await fieldactivityApiRepositories.GetListAsync();
        }
        [HttpPost]
        public async Task<Fieldactivity> Create(FieldactivityCreateDto fieldactivityDto)
        {
            var createdFieldactivity = await fieldactivityApiRepositories.AddFieldactivityByDtoAsync(fieldactivityDto);
            return createdFieldactivity;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await fieldactivityApiRepositories.DeleteFieldactivityAsync(id);
        }
        [HttpPut]
        public async Task Edit(FieldactivityCreateDto fiel)
        {
            await fieldactivityApiRepositories.UpdateFieldactivityAsync(fiel);
        }
    }
}

