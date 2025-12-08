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
        public async Task<Result<bool>> Register(RegisterUserInputDTO model, CancellationToken ct)
        {
            var Exist =await _usersrvice.ExistEmail(model.Email,ct);
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
                var result= await _usersrvice.Register(model, ct);

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


        public async Task<Result<LoginOutputUserDTO>> Login(string email,string password, CancellationToken ct)
        {
          var login= await _usersrvice.Login(email, password, ct);

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
