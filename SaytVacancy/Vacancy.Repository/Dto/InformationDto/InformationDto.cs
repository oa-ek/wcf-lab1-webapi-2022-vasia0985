
using Vacancy.Core;

namespace Vacancy.Repository.Dto.InformationDto
{
    public class InformationDto
    {
        public int InformationId { get; set; }
        public string? InformationName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }

}
