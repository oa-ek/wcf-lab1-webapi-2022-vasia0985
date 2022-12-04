using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Fieldactivity
    {
        [Key]
        public int FieldactivityId { get; set; }
        public string? FieldactivityName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
