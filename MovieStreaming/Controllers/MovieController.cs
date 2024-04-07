using System;
using Microsoft.AspNetCore.Mvc;
using MovieStreaming.Services;

namespace MovieStreaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("search")]
        public IActionResult SearchMoviesByTitle(string title)
        {
            var movies = _movieService.SearchMoviesByTitle(title);
            return Ok(movies);
        }
    }
}

