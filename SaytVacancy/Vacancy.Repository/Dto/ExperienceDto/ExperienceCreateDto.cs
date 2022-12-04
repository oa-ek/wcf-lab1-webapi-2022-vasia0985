using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Repository.Dto.ExperienceDto
{
    public class ExperienceCreateDto
    {
        [Required(ErrorMessage = "Введіть назву")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 2)]
        [RegularExpression("[a-zA-Z] +-[a-zA-Z]", ErrorMessage = "Невірні символи")]
        public string? ExperienceName { get; set; }
    }
}
