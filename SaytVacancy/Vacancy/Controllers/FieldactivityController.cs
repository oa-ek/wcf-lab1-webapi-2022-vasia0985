using Vacancy.Core;
using Vacancy.Repository.Dto.FieldactivityDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Vacancy.Controllers
{
    public class FieldactivityController : Controller
    {
        private readonly ILogger<FieldactivityController> _logger;
        private readonly FieldactivityRepositories _fieldactivityRepositories;
        public FieldactivityController(ILogger<FieldactivityController> logger, FieldactivityRepositories fieldactivityRepositories)
        {
            _logger = logger;
            _fieldactivityRepositories =fieldactivityRepositories;
        }
        public IActionResult Index()
        {
            return View(_fieldactivityRepositories.GetFieldactivities());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(FieldactivityDto fieldactivityDto)
        {
            if (ModelState.IsValid)
            {
                var fieldactivity = await _fieldactivityRepositories.AddFieldactivityAsync(new Core.Fieldactivity
                {
                    FieldactivityName = fieldactivityDto.FieldactivityName
                });
                return RedirectToAction("Index", "Fieldactivity", new { id = fieldactivity.FieldactivityId });
            }
            return View(fieldactivityDto);
        }

    }
}

