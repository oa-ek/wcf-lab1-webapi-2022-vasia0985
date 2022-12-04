using Vacancy.Core;
using Vacancy.Repository.Dto.AboutvacancieDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Vacancy.Controllers
{
    public class AboutvacancieController : Controller
    {

        private readonly ILogger<AboutvacancieController> _logger;
        private readonly AboutvacancieRepositories _aboutvacancieRepositories;
        public AboutvacancieController(ILogger<AboutvacancieController> logger, AboutvacancieRepositories aboutvacancieRepositories)
        {
            _logger = logger;
            _aboutvacancieRepositories = aboutvacancieRepositories;
        }
        public IActionResult Index()
        {
            return View(_aboutvacancieRepositories.GetAboutvacancies());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(AboutvacancieDto aboutvacancieDto)
        {
            if (ModelState.IsValid)
            {
                var aboutvacancie = await _aboutvacancieRepositories.AddAboutvacancieAsync(new Core.Aboutvacancie
                {
                    AboutvacancieName = aboutvacancieDto.AboutvacancieName
                });
                return RedirectToAction("Index", "Aboutvacancie", new { id = aboutvacancie.AboutvacancieId });
            }
            return View(aboutvacancieDto);
        }

    }
  
}
