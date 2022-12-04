using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.Core
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VacancieId { get; set; }

        public int AboutvacancieId { get; set; }
        public Aboutvacancie? Aboutvacancie { get; set; } // про вакансії

        public int RequirementId { get; set; }
        public Requirement? Requirement { get; set; } // Вимоги

        public int EmployerId { get; set; }
        public Employer? Employer { get; set; } // роботодавець

        public int CompanyId { get; set; }
        public Company? Company { get; set; } // компанія

        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
