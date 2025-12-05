using App.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.Data
{
    public interface IUserRepository
    {
        bool ExistEmail(string email);
        LoginOutputUserDTO? Login(string email, string password);
        bool Register(RegisterUserInputDTO model);
    }
}
