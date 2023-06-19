using AutoMapper;
using Business.Abstract;
using Business.Constants;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using File = Entities.Concrete.File;



namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IFileHelper _fileHelper;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IConfiguration _configuration { get; }



        public AuthManager(IConfiguration configuration,IUserService userService,IFileHelper fileHelper,ITokenHelper tokenHelper, IMapper mapper, IUnitofWork unitofWork, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _unitofWork = unitofWork;
            _httpContextAccessor = httpContextAccessor;
            _fileHelper = fileHelper;
            _configuration = configuration;
        }

        public IDataResult<User> Login(UserLoginDto userForLoginDto)
        {
            var userCheck =_userService.GetByUserName(userForLoginDto.UserName);

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

        public IResult Register(UserRegisterDto userRegisterDto, string password)
        {
            IResult result = BusinessRules.Run(CheckPasswordValidation(password));

            if (result != null)
            {
                return result;
            }

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
            return new SuccessResult(Messages.SuccessfullyRegister);
        }

        public IResult UserExists(string username)
        {
            if (_userService.GetByUserName(username) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult ChangePassword(string oldpassword, string newpassword, string repeatnewpassword)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _unitofWork.User.GetAll(u => u.Id == userid).FirstOrDefault();

            IResult result = BusinessRules.Run(
                CheckCurrentPassword(oldpassword, user, newpassword),
                CheckPasswordValidation(newpassword),
                CheckRepeatPassword(newpassword,repeatnewpassword));

            if (result != null)
            {
                return result;
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(newpassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _unitofWork.User.Update(user);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        public IResult CheckPasswordValidation(string password)
        {
            return
            (password.Length < 8 && !Regex.IsMatch(password, @"[a-zA-Z]"))
            ? new ErrorResult("Password length must be more 8 character or equal and  must not have only with numbers") :
            (password.Length < 8 || (password.Length < 8 && Regex.IsMatch(password, @"[a-zA-Z]"))
            ? new ErrorResult("Password length must be more 8 character or equal") :
            (!Regex.IsMatch(password, @"[a-zA-Z]"))
            ? new ErrorResult("Password must not have only with numbers") :
            new SuccessResult());
        }

        public IResult CheckCurrentPassword(string currentpassword, User user, string newpassword)
        {
            return 
            (!HashingHelper.VerifyPasswordHash(currentpassword, user.PasswordHash, user.PasswordSalt))
            ?new ErrorResult(Messages.PasswordError) :
            (currentpassword == newpassword)
            ?new ErrorResult("Old password must not again using"):
            new SuccessResult();
        }

        public IResult CheckRepeatPassword(string newpassword, string repeatnewpassword)
        {
            return (repeatnewpassword != newpassword)
            ? new ErrorResult("Repeat password is not correct") : 
              new SuccessResult();
        }

        public IResult ChangeImage(IFormFile file)
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _unitofWork.User.GetAll(u => u.Id == userid).FirstOrDefault();

            IResult result = BusinessRules.Run(CheckFileType(file.FileName));

            if (result != null)
            {
                return result;
            }

            string str = _configuration.GetSection("FilePaths").GetSection("ImagePath").Value;
            string filePath;
            if (user.ImageId == null)
            {
              filePath= _fileHelper.Upload(file, str);
            }
            else
            {
                var currentImage = _unitofWork.File.GetAll(f => f.Id == user.ImageId).SingleOrDefault();
                filePath= _fileHelper.Update(file, currentImage.Path + "\\" + currentImage.FileName, str);
            }


            File imageFile = new File
            {
                FileOriginalName = file.FileName,
                Size = file.Length,
                MimeType = file.ContentType,
                Extension = Path.GetExtension(filePath),
                FileName = filePath,
                Path = str
            };

            if (user.ImageId != null) _unitofWork.File.Delete(_unitofWork.File.GetAll(f => f.Id == user.ImageId).SingleOrDefault());
            _unitofWork.File.Add(imageFile);
            

            user.ImageId = imageFile.Id;
            _unitofWork.User.Update(user);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        public IResult CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".jpg":
                    return new SuccessResult();
                case ".jpeg":
                    return new SuccessResult();
                case ".png":
                    return new SuccessResult();
                default:
                    return new ErrorResult(Messages.ErrorFileFormat);
            }
        }

        public IResult DeleteImage()
        {
            int userid = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _unitofWork.User.GetAll(u => u.Id == userid).FirstOrDefault();
            var image=_unitofWork.File.GetAll(f=>f.Id==user.ImageId).FirstOrDefault();

            if (image == null) return new ErrorResult(Messages.NoImage);

            user.ImageId = null;
            _unitofWork.User.Update(user);

            _unitofWork.File.Delete(image);


            _fileHelper.Delete(Path.Combine(image.Path + "\\" + image.FileName));


            return new SuccessResult(Messages.SuccessfullyDeleted);
        }
    }
}
