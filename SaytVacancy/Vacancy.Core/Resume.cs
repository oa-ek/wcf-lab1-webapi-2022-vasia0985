using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.Core
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ResumeId { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }

        public int ExperienceId { get; set; }
        public Experience? Experience { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
