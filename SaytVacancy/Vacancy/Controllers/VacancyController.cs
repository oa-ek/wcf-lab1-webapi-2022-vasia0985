using Microsoft.AspNetCore.Mvc;
using Vacancy.Models;
using System.Diagnostics;
using Vacancy.Repository.Repositories;
using Vacancy.Repository.Dto.VacancyDto;
using Vacancy.Core;
using Microsoft.AspNetCore.Identity;
using System;
using Vacancy.Repository.Dto.UserDto;

namespace Vacancy.Controllers
{
    public class VacancyController : Controller
    {
        private readonly ILogger<VacancyController> _logger;

        private readonly VacancyRepositories _vacancieRepositories;
        private readonly RequirementRepositories _requirementRepositories;
        private readonly AboutvacancieRepositories _aboutvacancieRepositories;
        private readonly EmployerRepositories _employerRepositories;
        private readonly CompanyRepositories _companyRepositories;
        private readonly LogotypeRepositories _logotypeRepositories;
        private readonly FieldactivityRepositories _fieldactivityRepositories;
        private readonly InformationRepositories _informationRepositories;  
        private readonly UsersRepositories _usersRepository;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public VacancyController(ILogger<VacancyController> logger,
            VacancyRepositories vacancieRepositories,
            RequirementRepositories requirementRepositories,
            AboutvacancieRepositories aboutvacancieRepositories,
            EmployerRepositories employerRepositories,
            CompanyRepositories companyRepositories,
            LogotypeRepositories logotypeRepositories,
            FieldactivityRepositories fieldactivityRepositories,
            InformationRepositories informationRepositories,
            UsersRepositories usersRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _vacancieRepositories = vacancieRepositories;
            _aboutvacancieRepositories = aboutvacancieRepositories;
            _requirementRepositories = requirementRepositories;
            _employerRepositories = employerRepositories;
            _companyRepositories = companyRepositories; 
            _logotypeRepositories = logotypeRepositories;   
            _fieldactivityRepositories = fieldactivityRepositories;
            _informationRepositories = informationRepositories;       
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(_vacancieRepositories.GetVacancies());
        }

        [HttpGet]
        public IActionResult Vacansion()
        {
            ViewBag.Reguirement = _requirementRepositories.GetRequirements();
            ViewBag.Aboutvacancie = _aboutvacancieRepositories.GetAboutvacancies();
            ViewBag.Employer = _employerRepositories.GetEmployers();
            ViewBag.Company = _companyRepositories.GetCompanies();
            ViewBag.Logotype = _logotypeRepositories.GetLogotypes();
            ViewBag.Fieldactivity = _fieldactivityRepositories.GetFieldactivities();
            ViewBag.Information = _informationRepositories.GetInformations();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Vacansion(VacancyCreateDto vacansieDto, string requirementName, string aboutvacancieName,
            string employerName, string companyName, string logotypeName, string fieldactivityName, string informationName)
        {
            ViewBag.Reguirement = _requirementRepositories.GetRequirements();
            ViewBag.Aboutvacancie = _aboutvacancieRepositories.GetAboutvacancies();
            ViewBag.Employer = _employerRepositories.GetEmployers();
            ViewBag.Company = _companyRepositories.GetCompanies();
            ViewBag.Logotype = _logotypeRepositories.GetLogotypes();
            ViewBag.Fieldactivity = _fieldactivityRepositories.GetFieldactivities();
            ViewBag.Information = _informationRepositories.GetInformations();
            if (ModelState.IsValid)
            {
                var requirement = _requirementRepositories.GetRequirementByName(requirementName);
                if (requirement != null)
                {
                    requirement = new Requirement() { RequirementName = requirementName };
                    requirement = await _requirementRepositories.AddRequirementAsync(requirement);
                }

                var aboutvacancie = _aboutvacancieRepositories.GetAboutvacancieByName(aboutvacancieName);
                if (aboutvacancie != null)
                {
                    aboutvacancie = new Aboutvacancie() { AboutvacancieName = aboutvacancieName };
                    aboutvacancie = await _aboutvacancieRepositories.AddAboutvacancieAsync(aboutvacancie);
                }

                var employer = _employerRepositories.GetEmployerByName(employerName);
                if (employer != null)
                {
                    employer = new Employer() { EmployerName = employerName };
                    employer = await _employerRepositories.AddEmployerAsync(employer);
                }

                var logotype = _logotypeRepositories.GetLogotypeByName(logotypeName);
                if (logotype != null)
                {
                    logotype = new Logotype() { LogotypeName = logotypeName, };
                    logotype = await _logotypeRepositories.AddLogotypeAsync(logotype);
                }

                var fieldactivity = _fieldactivityRepositories.GetFieldactivityByName(fieldactivityName);
                if (fieldactivity != null)
                {
                    fieldactivity = new Fieldactivity() { FieldactivityName = fieldactivityName };
                    fieldactivity = await _fieldactivityRepositories.AddFieldactivityAsync(fieldactivity);
                }

                var information = _informationRepositories.GetInformationByName(informationName);
                if (information != null)
                {
                    information = new Information() { InformationName = informationName };
                    information = await _informationRepositories.AddInformationAsync(information);
                }

                var company = _companyRepositories.GetCompanyByName(companyName);
                if (company != null)
                {
                    company = new Company() { CompanyName = companyName, Logotype = logotype, Fieldactivity = fieldactivity, Information = information }; 
                    company = await _companyRepositories.AddCompanyAsync(company);
                }
                                              
                var user = _usersRepository.GetUserByEmail(User.Identity.Name);
                if (user == null)
                {
                    user = new User() { Email = User.Identity.Name };
                }

                var vacancy = await _vacancieRepositories.AddVacancieAsync(new Core.Vacancy
                {
                    Requirement = requirement,
                    Aboutvacancie = aboutvacancie,
                    Employer = employer,
                    Company = company,                
                    User = user
                });
                return RedirectToAction("Index", "Home", new { id = vacancy.VacancieId });
            }
            return View(vacansieDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Reguirement = _requirementRepositories.GetRequirements();
            ViewBag.Aboutvacancie = _aboutvacancieRepositories.GetAboutvacancies();
            ViewBag.Employer = _employerRepositories.GetEmployers();
            ViewBag.Company = _companyRepositories.GetCompanies();
            ViewBag.Logotype = _logotypeRepositories.GetLogotypes();
            ViewBag.Fieldactivity = _fieldactivityRepositories.GetFieldactivities();
            ViewBag.Information = _informationRepositories.GetInformations();
            return View(await _vacancieRepositories.GetVacancyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(VacancyReadDto vacansieDto, string requirementName, string aboutvacancieName,
            string employerName, string companyName, string logotypeName, string fieldactivityName, string informationName)
        {
            if (ModelState.IsValid)
            {
                await _vacancieRepositories.UpdateAsync(vacansieDto, requirementName, aboutvacancieName,
            employerName, companyName, logotypeName, fieldactivityName, informationName);
                return RedirectToAction("Vacn", "Vacancys", new { id = vacansieDto.VacancieId });
            }
            ViewBag.Reguirement = _requirementRepositories.GetRequirements();
            ViewBag.Aboutvacancie = _aboutvacancieRepositories.GetAboutvacancies();
            ViewBag.Employer = _employerRepositories.GetEmployers();
            ViewBag.Company = _companyRepositories.GetCompanies();
            ViewBag.Logotype = _logotypeRepositories.GetLogotypes();
            ViewBag.Fieldactivity = _fieldactivityRepositories.GetFieldactivities();
            ViewBag.Information = _informationRepositories.GetInformations();
            return View(vacansieDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _vacancieRepositories.GetVacancyDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _vacancieRepositories.DeleteVacancyAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
