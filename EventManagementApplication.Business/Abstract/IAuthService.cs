using EventManagementApplication.Core.Utilities.Results;
using EventManagementApplication.Core.Utilities.Security.JWT;
using EventManagementApplication.Entities.Concrete;
using EventManagementApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementApplication.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<bool> ResetPassword(ResetPasswordDto resetPasswordDto);

    }
}
