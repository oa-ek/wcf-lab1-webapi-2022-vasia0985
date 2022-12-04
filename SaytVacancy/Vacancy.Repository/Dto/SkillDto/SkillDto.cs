using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;

namespace Vacancy.Repository.Dto.SkillDto
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string? SkillName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }
    }

}
