using System;
using System.Collections.Generic;

namespace MovieStreaming.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public List<FavoriteMovie> FavoriteMovies { get; set; }
    }
}
