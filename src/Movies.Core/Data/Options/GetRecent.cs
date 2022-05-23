namespace Movies.Core.Data.Options;

public class GetRecent<T> where T : Entity
{
    public int Take { get; set; }
    public TimeSpan? MaxAge { get; set; }
}
