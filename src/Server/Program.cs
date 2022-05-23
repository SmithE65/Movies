using Microsoft.EntityFrameworkCore;
using Movies.Core.Data;
using Movies.Core.Data.Options;
using Movies.Server.Data;
using Movies.Server.Data.Entities;
using Movies.Server.Data.Queries;
using Movies.Shared.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MoviesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MoviesContextSQLite")
        ?? throw new Exception("SQLite connection string missing from appsettings: MoviesContextSQLite")));

builder.Services.AddScoped<IQuery<MovieListItem[], GetRecent<Movie>>, GetRecentMoviesQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
