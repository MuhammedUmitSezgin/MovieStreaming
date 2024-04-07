using System;
using System.Threading.Tasks;
using MovieStreaming.Models;

namespace MovieStreaming.Services
{
    public interface IUserService
    {
        Task<bool> Login(Login model);
        Task<bool> CreateUserAsync(User model);
    }
}

