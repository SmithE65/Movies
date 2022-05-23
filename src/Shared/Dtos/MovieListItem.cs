namespace Movies.Shared.Dtos;

public class MovieListItem
{
    public int MovieId { get; set; }
    public string MovieTitle { get; set; } = string.Empty;
    public bool Owned { get; set; } = false;
}
