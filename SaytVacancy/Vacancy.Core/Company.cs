using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public int LogotypeId { get; set; }
        public Logotype? Logotype { get; set; }

        public int FieldactivityId { get; set; }
        public Fieldactivity? Fieldactivity { get; set; }

        public int InformationId { get; set; }
        public Information? Information { get; set; }
        public virtual ICollection<Vacancy>? Vacancie { get; set; }
    }
}
