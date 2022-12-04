using Microsoft.AspNetCore.Mvc;
using Vacancy.Repository.Dto.SkillDto;
using Vacancy.Repository.Repositories;

namespace Vacancy.Controllers
{
    public class SkillController : Controller
    {
        private readonly ILogger<SkillController> _logger;
        private readonly SkillRepositories _skillRepositories;
        public SkillController(ILogger<SkillController> logger, SkillRepositories skillRepositories)
        {
            _logger = logger;
            _skillRepositories = skillRepositories;
        }
        public IActionResult Index()
        {
            return View(_skillRepositories.GetSkills());
        }

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(SkillDto skillDto)
        {
            if (ModelState.IsValid)
            {
                var skill = await _skillRepositories.AddSkillAsync(new Core.Skill
                {
                    SkillName = skillDto.SkillName
                });
                return RedirectToAction("Index", "Skill", new { id = skill.SkillId });
            }
            return View(skillDto);
        }*/
    }
}
