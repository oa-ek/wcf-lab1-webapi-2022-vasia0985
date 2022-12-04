using Vacancy.Core;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Vacancy.Controllers
{
    public class EducationController : Controller
    {

        private readonly ILogger<EducationController> _logger;
        private readonly EducationRepositories _educationRepositories;
        public EducationController (ILogger<EducationController> logger, EducationRepositories educationRepositories)
        {
            _logger = logger;
            _educationRepositories = educationRepositories;
        }
        public IActionResult Index()
        {
            return View(_educationRepositories.GetEducations());
        }

       /* [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(EducationDto educationDto)
        {
            if (ModelState.IsValid)
            {
                var education = await _educationRepositories.AddEducationAsync(new Core.Education
                {
                    EducationName = educationDto.EducationName
                });
                return RedirectToAction("Index", "Education", new { id = education.EducationId });
            }
            return View(educationDto);
        }*/
    }
}
