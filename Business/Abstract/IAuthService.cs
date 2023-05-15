using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult Register(UserRegisterDto userForRegisterDto, string password);
        IResult ChangePassword(string oldpassword,string newpassword,string repeatnewpassword);
        IResult ChangeImage(IFormFile file);

        IResult UserExists(string username);
    }
}
