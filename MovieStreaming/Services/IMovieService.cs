using System;
using MovieStreaming.Models;

namespace MovieStreaming.Services
{
    public interface IMovieService
    {
        List<Movie> SearchMoviesByTitle(string title);
    }
}

