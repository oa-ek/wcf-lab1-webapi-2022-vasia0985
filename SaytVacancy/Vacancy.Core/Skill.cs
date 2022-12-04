using System.ComponentModel.DataAnnotations;

namespace Vacancy.Core
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string? SkillName { get; set; }

        public virtual ICollection<Resume>? Resume { get; set; }
    }
}
