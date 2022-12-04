using Microsoft.AspNetCore.Mvc;
using Vacancy.Repository.Dto.InformationDto;
using Vacancy.Repository.Dto.LogotypeDto;
using Vacancy.Repository.Repositories;

namespace Vacancy.Controllers
{
    public class LogotypeController : Controller
    {
        private readonly ILogger<LogotypeController> _logger;
        private readonly LogotypeRepositories _logotypeRepositories;
        public LogotypeController(ILogger<LogotypeController> logger, LogotypeRepositories logotypeRepositories)
        {
            _logger = logger;
            _logotypeRepositories =logotypeRepositories;
        }
        public IActionResult Index()
        {
            return View(_logotypeRepositories.GetLogotypes());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(LogotypeDto logotypeDto)
        {
            if (ModelState.IsValid)
            {
                var logotype = await _logotypeRepositories.AddLogotypeAsync(new Core.Logotype
                {
                   LogotypeName = logotypeDto.LogotypeName
                });
                return RedirectToAction("Index", "Logotype", new { id = logotype.LogotypeId });
            }
            return View(logotypeDto);
        }
    }
}
