using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<User> Register(UserRegisterDto userForRegisterDto, string password);
        IDataResult<AccessToken> CreateAccessToken(User user);

        IResult UserExists(string username);
    }
}
