using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Requirement
    {
        [Key]
        public int RequirementId { get; set; }
        public string? RequirementName { get; set; }

        public virtual ICollection<Vacancy>? Vacancie { get; set; }
    }
}
