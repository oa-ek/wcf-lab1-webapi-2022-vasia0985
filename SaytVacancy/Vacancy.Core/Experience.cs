using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string? ExperienceName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }
    }
}
