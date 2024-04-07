using System;
using MovieStreaming.Context;
using MovieStreaming.Models;
using MovieStreaming.Services;

namespace MovieStreaming.Views
{
    public class FavoriteMovieService : IFavoriteMovieService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool MarkFavoriteMovies(int userId, List<int> movieIds)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return false; // Kullanıcı bulunamadı
            }

            foreach (var movieId in movieIds)
            {
                var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
                var userFavoriteMovie = _context.FavoriteMovies.FirstOrDefault(m=> m.MovieId == movie.MovieId && m.UserId == userId);

                if (movie != null && userFavoriteMovie == null)
                {
                    var favoriteMovie = new FavoriteMovie
                    {
                        UserId = userId,
                        MovieId = movieId,
                    };

                    _context.FavoriteMovies.Add(favoriteMovie);
                }
            }

            _context.SaveChanges();
            return true;
        }

        public List<Movie> SelectedFavoriteUser(int userId)
        {
            var favoriteMovies = _context.FavoriteMovies.Where(f => f.UserId == userId).Select(f => f.Movie).ToList();
            return favoriteMovies;
        }
    }

}

