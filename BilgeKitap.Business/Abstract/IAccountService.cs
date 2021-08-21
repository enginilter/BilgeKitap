using BilgeKitap.Core.Entities.Concrete;
using BilgeKitap.Core.Utilities.Results;
using BilgeKitap.Core.Utilities.Security.JWT;
using BilgeKitap.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Business.Abstract
{
    public interface IAccountService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
