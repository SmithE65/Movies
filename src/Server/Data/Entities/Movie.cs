using Movies.Core.Data;

namespace Movies.Server.Data.Entities;

public class Movie : Entity
{
    public string Title { get; set; }
    public IList<Copy> Copies { get; set; }
}
