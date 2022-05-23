using Movies.Server.Data.Entities;
using Movies.Shared.Dtos;

namespace Movies.Shared.Mapping.Extensions;

public static class MovieExtensions
{
    public static MovieListItem ToMovieListItem(this Movie movie) => new()
    {
        MovieId = movie.Id,
        MovieTitle = movie.Title,
        Owned = movie.Copies.Any()
    };
}
