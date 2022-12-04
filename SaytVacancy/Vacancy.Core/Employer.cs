using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Employer
    {
        [Key]
        public int EmployerId { get; set; }
        public string? EmployerName { get; set; }

        public virtual ICollection<Vacancy>? Vacancie { get; set; }
    }
}
