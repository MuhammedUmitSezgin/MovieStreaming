using System;
using Microsoft.AspNetCore.Mvc;
using MovieStreaming.Services;
using MovieStreaming.Views;

namespace MovieStreaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteMovieController : ControllerBase
    {
        private readonly IFavoriteMovieService _favoriteMovieService;

        public FavoriteMovieController(IFavoriteMovieService favoriteMovieService)
        {
            _favoriteMovieService = favoriteMovieService;
        }

        [HttpPost("mark-favorite")]
        public IActionResult MarkFavorite(int userId, List<int> movieIds)
        {
            var result = _favoriteMovieService.MarkFavoriteMovies(userId, movieIds);
            if (result)
                return Ok("Favorite movies marked successfully");
            else
                return BadRequest("Failed to mark favorite movies");
        }

        [HttpGet("favorite-movies")]
        public IActionResult GetFavoriteMovies(int userId)
        {
            var favoriteMovies = _favoriteMovieService.SelectedFavoriteUser(userId);
            return Ok(favoriteMovies);
        }
    }
}

