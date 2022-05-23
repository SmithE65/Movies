using Movies.Core.Data;

namespace Movies.Server.Data.Entities;

public class Location : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
