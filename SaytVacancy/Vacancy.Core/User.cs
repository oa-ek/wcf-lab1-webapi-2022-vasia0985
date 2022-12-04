using Microsoft.AspNetCore.Identity;

namespace Vacancy.Core
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Vacancy>? Vacancie { get; set; }
        public virtual ICollection<Resume>? Resume { get; set; }
    }
}
