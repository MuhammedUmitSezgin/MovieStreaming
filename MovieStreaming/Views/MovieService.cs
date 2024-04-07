using System;
using MovieStreaming.Context;
using MovieStreaming.Models;
using MovieStreaming.Services;

namespace MovieStreaming.Views
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movie> SearchMoviesByTitle(string title)
        {
            var movies = _context.Movies.Where(m => m.Title.ToLower().Contains(title.ToLower())).ToList();
            return movies;
        }
    }
}

