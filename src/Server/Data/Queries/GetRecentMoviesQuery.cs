using Microsoft.EntityFrameworkCore;
using Movies.Core.Data;
using Movies.Core.Data.Options;
using Movies.Server.Data.Entities;
using Movies.Shared.Dtos;
using Movies.Shared.Mapping.Extensions;

namespace Movies.Server.Data.Queries;

public class GetRecentMoviesQuery : IQuery<MovieListItem[], GetRecent<Movie>>
{
    private readonly MoviesDbContext _context;

    public GetRecentMoviesQuery(MoviesDbContext context)
    {
        _context = context;
    }

    public async Task<MovieListItem[]> ExecuteAsync(GetRecent<Movie> query)
    {
        var queryExpression = _context.Movies.AsQueryable();
        
        if (query.MaxAge is not null)
        {
            queryExpression = queryExpression.Where(x => x.UpdateDate > DateTimeOffset.Now.Subtract(query.MaxAge.Value));
        }

        var result = await queryExpression
            .OrderByDescending(x => x.UpdateDate)
            .Take(query.Take)
            .Select(x => x.ToMovieListItem())
            .ToListAsync();

        return result.ToArray();
    }
}
