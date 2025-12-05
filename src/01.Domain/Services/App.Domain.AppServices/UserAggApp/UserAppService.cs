using App.Domain.Core._CommonEntities;
using App.Domain.Core.UserAgg.AppServices;
using App.Domain.Core.UserAgg.DTOs;
using App.Domain.Core.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.UserAggApp
{
    public class UserAppService (IUserService _usersrvice):IUserAppService
    {
        public Result<bool> Register(RegisterUserInputDTO model)
        {
            var Exist = _usersrvice.ExistEmail(model.Email);
            if (Exist)
            {
                return Result<bool>.Failure("شما قبلا ثبت نام کرده اید!");
            }
            else
            {
                var ensureemil=  _usersrvice.EnsureEmail(model.Email);

                var ensurepass=_usersrvice.EnsurePassword(model.HashPassword);
                if (!ensureemil || !ensurepass)
                {
                    return Result<bool>.Failure("پسورد یا ایمیل شما نامعتبر است! ");
                }
                model.HashPassword = _usersrvice.HashPassword(model.HashPassword); 
                var result=  _usersrvice.Register(model);

                if (result)
                {
                    return Result<bool>.Success("ثبت نام با موفقیت انجام شد");

                }
                else
                {
                    return Result<bool>.Failure(" !ثبت نام ناموفق بود. دوباره تلاش کنید   ");
                }
            }
 
        }


        public Result<LoginOutputUserDTO> Login(string email,string password)
        {
          var login=  _usersrvice.Login(email, password);

            if (login is not null)
            {


                return Result<LoginOutputUserDTO>.Success("لاگین با موفقیت انجام شد.", login);
                   }
            else
            {
                return Result<LoginOutputUserDTO>.Failure("نام کاربری یا کلمه عبور اشتباه می باشد.");
            }
        

    }
    }
}
