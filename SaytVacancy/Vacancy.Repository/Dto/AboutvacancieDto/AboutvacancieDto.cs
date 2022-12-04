using Vacancy.Core;

namespace Vacancy.Repository.Dto.AboutvacancieDto
{
     public class AboutvacancieDto
    {
        public int AboutvacancieId { get; set; }
        public string? AboutvacancieName { get; set; }

        public virtual ICollection<Core.Vacancy>? Vacancie { get; set; }
    }
}
