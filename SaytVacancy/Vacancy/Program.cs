using Vacancy.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Vacancy.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("VacancyConnection");
builder.Services.AddDbContext<VacancyDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VacancyDbContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<UsersRepositories>();
builder.Services.AddTransient<AboutvacancieRepositories>();
builder.Services.AddTransient<EducationRepositories>();
builder.Services.AddTransient<CompanyRepositories>();
builder.Services.AddTransient<EmployerRepositories>();
builder.Services.AddTransient<ExperienceRepositories>();
builder.Services.AddTransient<FieldactivityRepositories>();
builder.Services.AddTransient<InformationRepositories>();
builder.Services.AddTransient<LogotypeRepositories>();
builder.Services.AddTransient<RequirementRepositories>();
builder.Services.AddTransient<ResumeRepositories>();
builder.Services.AddTransient<SkillRepositories>();
builder.Services.AddTransient<VacancyRepositories>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
