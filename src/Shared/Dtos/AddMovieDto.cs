namespace Movies.Shared.Dtos;

public class AddMovieDto
{
    public string Title { get; set; } = string.Empty;
    public bool Owned { get; set; }
    public string? Format { get; set; }
}
