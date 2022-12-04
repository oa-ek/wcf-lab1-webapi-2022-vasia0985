using Microsoft.AspNetCore.Mvc;
using Vacancy.Models;
using System.Diagnostics;
using Vacancy.Repository.Repositories;
using Vacancy.Core;
using Microsoft.AspNetCore.Identity;
using System; 
using Vacancy.Repository.Dto.UserDto;
using Vacancy.Repository.Dto.ResumeDto;

namespace Vacancy.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;

        private readonly ResumeRepositories _resumeRepositories;
        private readonly EducationRepositories _educationRepositories;
        private readonly SkillRepositories _skillRepositories;
        private readonly ExperienceRepositories _experienceRepositories;
        private readonly UsersRepositories _usersRepository;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ResumeController(ILogger<ResumeController> logger, ResumeRepositories resumeRepositories,
            EducationRepositories educationRepositories,SkillRepositories skillRepositories,ExperienceRepositories experienceRepositories,
            UsersRepositories usersRepository, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _resumeRepositories = resumeRepositories;
            _educationRepositories = educationRepositories;
            _skillRepositories = skillRepositories; 
            _experienceRepositories = experienceRepositories;
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(_resumeRepositories.GetResumes());
        }       

        
        public IActionResult AddResume()
        {
            ViewBag.Educations = _educationRepositories.GetEducations();
            ViewBag.Skills = _skillRepositories.GetSkills();
            ViewBag.Experiences = _experienceRepositories.GetExperiences();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddResume(ResumeCreateDto resumeDto, string educationName, string skillName,
            string experienceName)
        {
            ViewBag.Educations = _educationRepositories.GetEducations();
            ViewBag.Skills = _skillRepositories.GetSkills();
            ViewBag.Experiences = _experienceRepositories.GetExperiences();

            //if (ModelState.IsValid)
            //{

                var education = _educationRepositories.GetEducationByName(educationName);
                if (education == null)
                {
                    education = new Education() { EducationName = educationName };
                    education = await _educationRepositories.AddEducationAsync(education);
                }
                var skill = _skillRepositories.GetSkillByName(skillName);
                if (skill == null)
                {
                    skill = new Skill() { SkillName = skillName };
                    skill = await _skillRepositories.AddSkillAsync(skill);
                }
                var experience = _experienceRepositories.GetExperienceByName(experienceName);
                if (experience == null)
                {
                    experience = new Experience() { ExperienceName = experienceName };
                    experience = await _experienceRepositories.AddExperienceAsync(experience);
                }

                var user = _usersRepository.GetUserByEmail(User.Identity.Name);
                if (user == null)
                {
                    user = new User() { Email = User.Identity.Name };
                }

                var resume = await _resumeRepositories.AddResumeAsync(new Resume
                {
                    Education = education,
                    Skill = skill,
                    Experience = experience,

                    User = user
                });
                return RedirectToAction("Index", "Home", new { id = resume.ResumeId });
           // }
            return View(resumeDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Educations = _educationRepositories.GetEducations();
            ViewBag.Skills = _skillRepositories.GetSkills();
            ViewBag.Experiences = _experienceRepositories.GetExperiences();
            return View(await _resumeRepositories.GetResumeDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(ResumeDto resumeDto, string educationName, string skillName,
            string experienceName)
        {
            if (ModelState.IsValid)
            {
            await _resumeRepositories.UpdateAsync(resumeDto, educationName, skillName, experienceName);
                return RedirectToAction("Resums", "Resumes", new { id = resumeDto.UserId });
            }
            ViewBag.Educations = _educationRepositories.GetEducations();
            ViewBag.Skills = _skillRepositories.GetSkills();
            ViewBag.Experiences = _experienceRepositories.GetExperiences();
            return View(resumeDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _resumeRepositories.GetResumeDto(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _resumeRepositories.DeleteResumeAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
