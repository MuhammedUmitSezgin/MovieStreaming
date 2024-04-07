using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStreaming.Models;
using MovieStreaming.Services;

namespace MovieStreaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(Login model)
        {
            var result = await _userService.Login(model);
            return new JsonResult(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(model);
                if (result)
                    return Ok("User created successfully");
            }
            return BadRequest(ModelState);
        }        
    }
}

