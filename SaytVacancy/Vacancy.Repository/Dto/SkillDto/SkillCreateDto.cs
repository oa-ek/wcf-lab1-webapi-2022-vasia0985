using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Repository.Dto.SkillDto
{
    public class SkillCreateDto
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
    }
}
