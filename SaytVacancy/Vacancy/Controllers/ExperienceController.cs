using Vacancy.Core;
using Vacancy.Repository.Dto.ExperienceDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Repository.Dto.EmployerDto;

namespace Vacancy.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ILogger<ExperienceController> _logger;
        private readonly ExperienceRepositories _experienceRepositories;
        public ExperienceController(ILogger<ExperienceController> logger, ExperienceRepositories experienceRepositories)
        {
            _logger = logger;
            _experienceRepositories = experienceRepositories;
        }
        public IActionResult Index()
        {
            return View(_experienceRepositories.GetExperiences());
        }

        /*[HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(ExperienceDto experienceDto)
        {
            if (ModelState.IsValid)
            {
                var experience = await _experienceRepositories.AddExperienceAsync(new Core.Experience
                {
                   ExperienceName=experienceDto.ExperienceName
                });
                return RedirectToAction("Index", "Experience", new { id = experience.ExperienceId });
            }
            return View(experienceDto);
        }*/

    }
}
