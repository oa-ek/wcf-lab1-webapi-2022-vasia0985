using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacancy.Core;
using Vacancy.Repository.Dto.UserDto;

namespace Vacancy.Repository.Repositories
{
    public class UsersRepositories
    {
            
        private readonly VacancyDbContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersRepositories(VacancyDbContext ctx,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<User> CreateUserAsync(string? firstName, string? lastName, string? password, string? email)
        {
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = email.ToUpper(),
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(newUser, password);

            return await _ctx.Users.FirstAsync(x => x.Email == email);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = _ctx.Users.Find(id);

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var u = await _ctx.Users.FirstAsync(x => x.Id == id);

            var userDto = new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsConfirmed = u.EmailConfirmed,
                Roles = new List<IdentityRole>()
            };

            foreach (var role in await _userManager.GetRolesAsync(u))
            {
                userDto.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
            }

            return userDto;
        }

        public User GetUserByEmail(string email)
        {
            return _ctx.Users.FirstOrDefault(x => x.Email == email);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = new List<UserDto>();

            foreach (var u in _ctx.Users.ToList())
            {
                var userDto = new UserDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsConfirmed = u.EmailConfirmed,
                    Roles = new List<IdentityRole>()
                };

                foreach (var role in await _userManager.GetRolesAsync(u))
                {
                    userDto.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
                }

                users.Add(userDto);
            }

            return users;
        }

        public async Task UpdateAsync(UserDto model, string[] roles)
        {
            var user = _ctx.Users.Find(model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.FirstName != model.FirstName)
                user.FirstName = model.FirstName;

            if (user.LastName != model.LastName)
                user.LastName = model.LastName;

            if (user.EmailConfirmed != model.IsConfirmed)
                user.EmailConfirmed = model.IsConfirmed;

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await _userManager.AddToRolesAsync(user, roles.ToList());
            }
        }
    }
}


    

