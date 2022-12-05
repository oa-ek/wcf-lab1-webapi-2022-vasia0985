using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Core;
using Vacancy.Repository.Dto.SkillDto;
using Vacancy.Repository.Repositories;

namespace VacancyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillApiController : ControllerBase
    {
        private readonly SkillRepositories skillApiRepositories;
        private readonly ILogger<SkillApiController> _logger;
        public SkillApiController(ILogger<SkillApiController> logger, SkillRepositories skillApiRepositories)
        {
            _logger = logger;
            this.skillApiRepositories = skillApiRepositories;
        }
        [HttpGet]
        public SkillRepositories GetSkillRepositories()
        {
            return skillApiRepositories;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSkillListAsync")]
        public async Task<IEnumerable<SkillDto>> GetListAsync()
        {
            return await skillApiRepositories.GetListAsync();
        }
        [HttpPost]
        public async Task<Skill> Create(SkillCreateDto skillDto)
        {
            var createdSkill = await skillApiRepositories.AddSkillByDtoAsync(skillDto);
            return createdSkill;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await skillApiRepositories.DeleteSkillAsync(id);
        }
        [HttpPut]
        public async Task Edit(SkillCreateDto skil)
        {
            await skillApiRepositories.UpdateSkillAsync(skil);
        }
    }
}
