using Vacancy.Core;
using Vacancy.Repository.Dto.RequirementDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Repository.Dto.LogotypeDto;

namespace Vacancy.Controllers
{
    public class RequirementController : Controller
    {
        private readonly ILogger<RequirementController> _logger;
        private readonly RequirementRepositories _requirementRepositories;
        public RequirementController(ILogger<RequirementController> logger, RequirementRepositories requirementRepositories)
        {
            _logger = logger;
            _requirementRepositories = requirementRepositories;
        }
        public IActionResult Index()
        {
            return View(_requirementRepositories.GetRequirements());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(RequirementDto requirementDto)
        {
            if (ModelState.IsValid)
            {
                var requirement = await _requirementRepositories.AddRequirementAsync(new Core.Requirement
                {
                    RequirementName=requirementDto.RequirementName
                });
                return RedirectToAction("Index", "Requirement", new { id = requirement.RequirementId });
            }
            return View(requirementDto);
        }
    }
}
