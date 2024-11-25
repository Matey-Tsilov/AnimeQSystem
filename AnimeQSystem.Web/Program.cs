using AnimeQSystem.Data;
using AnimeQSystem.Data.Models;
using AnimeQSystem.Services.AutoMapper;
using AnimeQSystem.Web.Infrastructure;
using AnimeQSystem.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// This configures the application's DbContext (ApplicationDbContext) to use SQL Server and the connection string retrieved above.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// This enables detailed database error pages (e.g., for migrations or database issues) during development.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// This sets up the default identity system to handle user authentication.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

// This configures the MVC pipeline, enabling support for controllers and views in the application.
builder.Services.AddControllersWithViews();

// Automatically register all repositories on run
builder.Services.RegisterRepositories(typeof(User).Assembly);

// Build the whole application
var app = builder.Build();

// Go around application and collect all mappings into a AutoMapper config (runtime)
AutoMapperConfig.RegisterMappings(typeof(index).Assembly);

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

app.UseAuthorization();

// Automatic migration and seeding of data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();  // Apply any pending migrations
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
