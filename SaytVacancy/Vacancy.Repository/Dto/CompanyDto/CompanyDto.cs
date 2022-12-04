
using Vacancy.Core;

namespace Vacancy.Repository.Dto.CompanyDto
{
   public  class CompanyDto
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public int LogotypeId { get; set; }
        public Logotype? Logotype { get; set; }

        public int FieldactivityId { get; set; }
        public Fieldactivity? Fieldactivity { get; set; }

        public int InformationId { get; set; }
        public Information? Information { get; set; }
        public virtual ICollection<Core.Vacancy>? Vacancie { get; set; }
    }
}
