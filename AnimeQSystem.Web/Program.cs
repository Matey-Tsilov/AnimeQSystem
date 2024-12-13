using AnimeQSystem.Data;
using AnimeQSystem.Data.Models;
using AnimeQSystem.Services;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Infrastructure;
using AnimeQSystem.Web.Middlewares;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// First tr to get it from the Azure environmental variables
var connectionString = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING_AZURE");

// Get connection string from local appsettings
if (string.IsNullOrEmpty(connectionString))
{
    // Fallback to a default value from appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

// This configures the application's DbContext (ApplicationDbContext) to use SQL Server and the connection string retrieved above.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// This enables detailed database error pages (e.g., for migrations or database issues) during development.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// This sets up the default identity system to handle user authentication.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// This configures the MVC pipeline, enabling support for controllers and views in the application.
builder.Services.AddControllersWithViews();

// Go around application and collect all mappings into a AutoMapper config (runtime).
AutoMapperConfig.RegisterMappings(typeof(QuizCardViewModel).Assembly);

// Automatically register all repositories on run.
builder.Services.RegisterRepositories(typeof(User).Assembly);

// Automatically register all services on run.
builder.Services.RegisterServices(typeof(QuizService).Assembly);

// Build the whole application
var app = builder.Build();

// Use a custom error handler for unhandled exceptions
app.UseExceptionHandler("/Home/Error");

// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Redirect middleware for admins
app.Use((context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true && context.Request.Path == "/")
    {
        if (context.User.IsInRole("Admin"))
        {
            context.Response.Redirect("/Admin/Home/Index");
            return Task.CompletedTask;
        }
    }
    return next();
});

app.UseAuthorization();

app.UseMiddleware<UserMiddleware>();

// Automatic migration and seeding of data if needed
await DatabaseSeeder.MigrateAndSeed(app.Services);

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
