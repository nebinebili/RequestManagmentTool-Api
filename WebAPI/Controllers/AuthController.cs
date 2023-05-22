using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthController(IAuthService authService,IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var userLogin = _authService.Login(userLoginDto);

            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }
            var result = _authService.CreateAccessToken(userLogin.Data);
            if (!result.Success)
            {

              return BadRequest(result.Message);
            }
            
            return Ok(result.Data);


        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userRegisterDto)
        {
            var userExists = _authService.UserExists(userRegisterDto.UserName);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userRegisterDto, userRegisterDto.Password);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }
            
            return Ok(registerResult);

        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(string oldpassword,string newpassword,string repeatnewpassword)
        {
            var result = _authService.ChangePassword(oldpassword, newpassword, repeatnewpassword);
            
            if (!result.Success)
            {

                return BadRequest(result.Message);
            }

            return Ok(result);

        }

        [HttpPut("ChangeImage")]
        public IActionResult ChangeImage(IFormFile file)
        {
            var result = _authService.ChangeImage(file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteImage")]
        public IActionResult DeleteImage()
        {
            var result = _authService.DeleteImage();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
