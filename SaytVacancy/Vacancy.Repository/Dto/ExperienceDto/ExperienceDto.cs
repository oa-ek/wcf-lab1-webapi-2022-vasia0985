using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;

namespace Vacancy.Repository.Dto.ExperienceDto
{
    public class ExperienceDto
    {
        public int ExperienceId { get; set; }
        public string? ExperienceName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }

    }
}
