using Microsoft.AspNetCore.Mvc;
using Movies.Core.Data;
using Movies.Core.Data.Options;
using Movies.Server.Data.Entities;
using Movies.Shared.Dtos;

namespace Movies.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetRecent([FromServices] IQuery<MovieListItem[], GetRecent<Movie>> query)
    {
        var recent = await query.ExecuteAsync(new GetRecent<Movie> { Take = 10 });
        return Ok(recent);
    }
}
