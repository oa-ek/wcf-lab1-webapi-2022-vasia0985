using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Vacancy.Core
{
    public static class VacancyDbContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MODER_ROLE_ID,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODER_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@vacancy.com",
                Email = "admin@vacancy.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@vacancy.com".ToUpper(),
                NormalizedUserName = "admin@vacancy.com".ToUpper()
            };

            var moder = new User
            {
                Id = MODER_ID,
                UserName = "moder@vacancy.com",
                Email = "moder@vacancy.com",
                EmailConfirmed = true,
                NormalizedEmail = "moder@vacancy.com".ToUpper(),
                NormalizedUserName = "moder@vacancy.com".ToUpper()
            };

            var user = new User
            {
                Id = USER_ID,
                UserName = "user@vacancy.com",
                Email = "user@vacancy.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@vacancy.com".ToUpper(),
                NormalizedUserName = "user@vacancy.com".ToUpper(),
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin$pass1");
            moder.PasswordHash = hasher.HashPassword(moder, "Moder$pass1");
            user.PasswordHash = hasher.HashPassword(user, "User$pass1");

            builder.Entity<User>().HasData(admin, moder, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });

            builder.Entity<Education>().HasData(
             new Education
             {
                 EducationId = 1,
                 EducationName = "Вища професійна",
             }                      
             );
            builder.Entity<Skill>().HasData(
             new Skill
             {
                 SkillId = 1,
                 SkillName = "Вміння працювати в команді",
             }
             );
            builder.Entity<Experience>().HasData(
             new Experience
             {
                 ExperienceId = 1,
                 ExperienceName = "1 рік",
             });

            builder.Entity<Resume>().HasData(
              new Resume
              {
                  ResumeId = 1,
                  EducationId = 1,
                  SkillId = 1,
                  ExperienceId = 1,
                  UserId = ADMIN_ID
              });              
        }
    }
}
