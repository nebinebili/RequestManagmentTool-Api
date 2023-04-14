using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper,IUnitofWork unitofWork)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userCheck = _userService.GetByUserName(userForLoginDto.UserName);

            if (userCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheck.PasswordHash, userCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userCheck, Messages.SuccessfullyLogin);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            var user = _mapper.Map<User>(userRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            var number = 0;

            foreach (RegisterCategoryDto info in userRegisterDto.Categories)
            {
                // Asagidaki usulda:
                // 2,5 category gonderdikde user-e idsi 2 olan category varsa  add edecek id si 5 olani yoxdusa add etmeyecek

                Category category = _unitofWork.Category.Get(c => c.Id == info.Id);
                if (category == null)
                {
                    return new ErrorDataResult<User>(user, Messages.CategoryDoesNotExist);
                }

                ++number;
                if (number == 1) _userService.Add(user); //yuxarida yazdiqda(dovrden colde) category movcud olmasa bele add edecek useri
                //burda dovr icinde oldugu ucun her defe user add elememk ucun ise number ile yoxlanis edirem

                

                CategoryUser categoryUser = new CategoryUser
                {
                    CategoryId = info.Id,
                    UserId = user.Id,
                    CreatePermisson = info.CreatePermission,
                    ExecutePermisson = info.ExecutePermission
                };
                _unitofWork.CategoryUser.Add(categoryUser);
            }
            // User Categoryuserden evvel add edilmelidirki Categoryuser table na Userin Id sini qeyd ede bilek.
            _unitofWork.Complete();
            return new SuccessDataResult<User>(user, Messages.SuccessfullyRegister);
        }

        public IResult UserExists(string username)
        {
            if (_userService.GetByUserName(username) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
