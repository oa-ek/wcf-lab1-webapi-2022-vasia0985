
using Vacancy.Core;

namespace Vacancy.Repository.Dto.FieldactivityDto
{
    public class FieldactivityDto
    {
        public int FieldactivityId { get; set; }
        public string? FieldactivityName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
