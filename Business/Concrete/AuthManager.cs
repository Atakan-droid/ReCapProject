using Business.Abstract;
using Business.Constants;
using CORE.Entities.Concrete;
using CORE.Utilities;
using CORE.Utilities.Security.Hashing;
using CORE.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,
            ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claim=_userService.GetClaim(user);
            var accesToken=_tokenHelper.CreateToken(user, claim.Data);
            return new SuccessDataResult<AccessToken>(accesToken, Messages.AccessTokenCreated); ;
        }

        public IDataResult<User> login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VeriyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccesfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User {Email=userForRegisterDto.Email,
            FirstName=userForRegisterDto.FirstName,
            LastName=userForRegisterDto.LastName,
            PasswordHash=passwordHash,
            PasswordSalt=passwordSalt,
            Status=true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
