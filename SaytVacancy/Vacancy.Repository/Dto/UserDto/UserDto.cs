using Microsoft.AspNetCore.Identity;
using Vacancy.Core;

namespace Vacancy.Repository.Dto.UserDto
{
  public class UserDto
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool IsConfirmed { get; set; }     
        public List<IdentityRole>? Roles { get; set; }
        public virtual ICollection<Core.Vacancy>? Vacancie { get; set; }
        public virtual ICollection<Resume>? Resume { get; set; }
    }
}
