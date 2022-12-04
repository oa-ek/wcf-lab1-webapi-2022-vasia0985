using Vacancy.Core;
using Vacancy.Repository.Dto.InformationDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Vacancy.Controllers
{
    public class InformationController : Controller
    {

        private readonly ILogger<InformationController> _logger;
        private readonly InformationRepositories _informationRepositories;
        public InformationController(ILogger<InformationController> logger, InformationRepositories informationRepositories)
         {
            _logger = logger;
            _informationRepositories = informationRepositories;
         }
        public IActionResult Index()
        {
            return View(_informationRepositories.GetInformations());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(InformationDto informationDto)
        {
            if (ModelState.IsValid)
            {
                var information = await _informationRepositories.AddInformationAsync(new Core.Information
                {
                    InformationName=informationDto.InformationName
                });
                return RedirectToAction("Index", "Information", new { id = information.InformationId });
            }
            return View(informationDto);
        }

    }
}
