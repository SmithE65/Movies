using Microsoft.EntityFrameworkCore;
using Movies.Server.Data.Entities;

namespace Movies.Server.Data;

public class MoviesDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Copy> Copies { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Format> Formats { get; set; } = null!;

    public MoviesDbContext() { }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> opts) : base(opts) { }
}
