using System.ComponentModel.DataAnnotations;


namespace Vacancy.Repository.Dto.ResumeDto
{
   public class ResumeCreateDto
        {
        [Required]
        public string? EducationName { get; set; }
        [Required]
        public string? SkillName { get; set; }
        [Required]
        public string? ExperienceName { get; set; }

        }
    
}
