using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Information
    {
        [Key]
        public int InformationId { get; set; }
        public string? InformationName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
