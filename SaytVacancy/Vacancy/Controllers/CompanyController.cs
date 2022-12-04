using Vacancy.Core;
using Vacancy.Repository.Dto.CompanyDto;
using Vacancy.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vacancy.Models;

namespace Vacancy.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyRepositories _companyRepositories;
        public CompanyController(ILogger<CompanyController> logger, CompanyRepositories companyRepositories)
        {
            _logger = logger;
            _companyRepositories = companyRepositories;
        }

        public IActionResult Index()
        {
            return View(_companyRepositories.GetCompanies());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    } 
}
