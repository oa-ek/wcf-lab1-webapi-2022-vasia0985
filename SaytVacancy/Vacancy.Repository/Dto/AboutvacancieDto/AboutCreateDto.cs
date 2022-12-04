using System.ComponentModel.DataAnnotations;

namespace Vacancy.Repository.Dto.AboutvacancieDto
{   
        public class AboutCreateDto
        {
            [Required(ErrorMessage = "Введіть назву")]
            [StringLength(32, ErrorMessage = "Must be between 1 and 32 characters", MinimumLength = 1)]
            public string? AboutvacancieName { get; set; }
        } 
}
