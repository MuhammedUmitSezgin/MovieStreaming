using System;
using MovieStreaming.Models;

namespace MovieStreaming.Services
{
    public interface IFavoriteMovieService
    {
        bool MarkFavoriteMovies(int userId, List<int> movieIds);
        List<Movie> SelectedFavoriteUser(int userId);
    }
}

