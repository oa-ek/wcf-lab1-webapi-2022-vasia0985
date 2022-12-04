using Vacancy.Core;

namespace Vacancy.Repository.Dto.EducationDto
{
    public class EducationDto
    {
       
        public int EducationId { get; set; }
        public string? EducationName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }
    }
}
