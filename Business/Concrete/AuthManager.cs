using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;


        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userCheck=_userService.GetByFullName(userForLoginDto.FullName);

            if (userCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //if (userCheck.Password!=userForLoginDto.Password)
            //{
            //    return new ErrorDataResult<User>(Messages.PasswordError);
            //}

            return new SuccessDataResult<User>(userCheck, Messages.SuccessfullyLogin);
        }
    }
}
