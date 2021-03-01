using CORE.Entities.Concrete;
using CORE.Utilities;
using CORE.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
       IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<User> login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
