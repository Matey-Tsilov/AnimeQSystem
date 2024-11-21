using AnimeQSystem.Data;
using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Models;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Data.Repository;
using AnimeQSystem.Services.AutoMapper;
using AnimeQSystem.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

#region All repositories
builder.Services.AddScoped<IRepository<Anime, Guid>, BaseRepository<Anime, Guid>>();
builder.Services.AddScoped<IRepository<User, Guid>, BaseRepository<User, Guid>>();
builder.Services.AddScoped<IRepository<Studio, Guid>, BaseRepository<Studio, Guid>>();
builder.Services.AddScoped<IRepository<Character, Guid>, BaseRepository<Character, Guid>>();
builder.Services.AddScoped<IRepository<Genre, Guid>, BaseRepository<Genre, Guid>>();
builder.Services.AddScoped<IRepository<Writer, Guid>, BaseRepository<Writer, Guid>>();
builder.Services.AddScoped<IRepository<Quiz, Guid>, BaseRepository<Quiz, Guid>>();
builder.Services.AddScoped<IRepository<QuizQuestion, Guid>, BaseRepository<QuizQuestion, Guid>>();
builder.Services.AddScoped<IRepository<QuizOption, Guid>, BaseRepository<QuizOption, Guid>>();
builder.Services.AddScoped<IRepository<QuizzesUsers, object>, BaseRepository<QuizzesUsers, object>>();
#endregion

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
