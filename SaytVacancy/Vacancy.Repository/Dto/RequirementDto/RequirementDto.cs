using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;

namespace Vacancy.Repository.Dto.RequirementDto
{
    public class RequirementDto
    {
        public int RequirementId { get; set; }
        public string? RequirementName { get; set; }

        public virtual ICollection<Core.Vacancy>? Vacancie { get; set; }
    }
}
