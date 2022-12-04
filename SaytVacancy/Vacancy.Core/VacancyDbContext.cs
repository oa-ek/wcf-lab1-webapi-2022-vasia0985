using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vacancy.Core
{
    public class VacancyDbContext : IdentityDbContext<User>
    {
        public VacancyDbContext(DbContextOptions<VacancyDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Company> Companies  { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Aboutvacancie> Aboutvacancies { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Fieldactivity> Fieldactivities { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Logotype> Logotypes { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Skill> Skills { get; set; }
     
    }
}
