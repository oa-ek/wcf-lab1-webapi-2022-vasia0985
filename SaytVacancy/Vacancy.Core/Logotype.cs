using System.ComponentModel.DataAnnotations;
namespace Vacancy.Core
{
    public class Logotype
    {
        [Key]
        public int LogotypeId { get; set; }
        public string? LogotypeName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
