using Vacancy.Core;
using Vacancy.Repository.Dto.EmployerDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Vacancy.Controllers
{
    public class EmployerController : Controller
    {

        private readonly ILogger<EmployerController> _logger;
        private readonly EmployerRepositories _employerRepositories;
        public EmployerController(ILogger<EmployerController> logger, EmployerRepositories employerRepositories)
        {
            _logger = logger;
           _employerRepositories = employerRepositories;
        }
        public IActionResult Index()
        {
            return View(_employerRepositories.GetEmployers());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(EmployerDto employerDto)
        {
            if (ModelState.IsValid)
            {
                var employer = await _employerRepositories.AddEmployerAsync(new Core.Employer
                {
                    EmployerName = employerDto.EmployerName
                });
                return RedirectToAction("Index", "Employer", new { id = employer.EmployerId });
            }
            return View(employerDto);
        }

    }
}
