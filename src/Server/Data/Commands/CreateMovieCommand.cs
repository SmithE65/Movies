using Microsoft.EntityFrameworkCore;
using Movies.Core.Data;
using Movies.Server.Data.Entities;
using Movies.Shared.Dtos;

namespace Movies.Server.Data.Commands;

public class CreateMovieCommand : ICommand<AddMovieDto>
{
    private readonly MoviesDbContext _context;

    public CreateMovieCommand(MoviesDbContext context)
    {
        _context = context;
    }

    public async Task ExecuteAsync(AddMovieDto query)
    {
        query.Format ??= "Unspecified";
        var format = await _context.Formats.FirstOrDefaultAsync(x => x.Name == query.Format);

        var entity = new Movie
        {
            Title = query.Title,
            Copies = query.Owned
                ? new List<Copy>
                {
                    new() { Format = format ?? new Format{ Name = query.Format, UpdateDate = DateTime.UtcNow } }
                }
                : new()
        };

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
