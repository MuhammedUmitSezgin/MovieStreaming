using System;
using Microsoft.EntityFrameworkCore;
using MovieStreaming.Context;
using MovieStreaming.Models;
using MovieStreaming.Services;

namespace MovieStreaming.Views
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(Login login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CreateUserAsync(User model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username && u.Email == model.Email);
            if (existingUser != null)
                return false; // Kullanıcı zaten mevcut

            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool FavoriteSelected(int userId, int movieId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);

            if (user != null && movie != null)
            {
                var favori = new FavoriteMovie
                {
                    UserId = userId,
                    User = user,
                    MovieId = movieId,
                    Movie = movie
                };

                _context.FavoriteMovies.Add(favori);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        
    }
}

