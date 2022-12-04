using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public string? EducationName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }
        
    }
}
