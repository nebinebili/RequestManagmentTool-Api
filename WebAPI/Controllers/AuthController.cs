using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public  ActionResult Login(UserLoginDto userLoginDto)
        {
            var userLogin = _authService.Login(userLoginDto);

            if(!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }
            return Ok(userLogin);
        }
    }
}
