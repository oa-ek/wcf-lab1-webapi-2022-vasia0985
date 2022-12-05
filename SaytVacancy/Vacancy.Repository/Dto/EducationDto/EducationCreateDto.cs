using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Repository.Dto.EducationDto
{
    public class EducationCreateDto
    {
        public int EducationId { get; set; }
        public string? EducationName { get; set; }
    }
}
