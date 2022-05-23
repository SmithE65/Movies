using Movies.Core.Data;

namespace Movies.Server.Data.Entities;

public class Copy : Entity
{
    public Movie Movie { get; set; }
    public Format Format { get; set; }
}
