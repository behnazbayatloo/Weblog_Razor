using App.Domain.Core._CommonEntities;
using App.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.Services
{
    public interface IUserService
    {
        bool EnsureEmail(string email);
        bool EnsurePassword(string password);
        bool ExistEmail(string email);
        string HashPassword(string password);
        LoginOutputUserDTO Login(string email, string password);
        bool Register(RegisterUserInputDTO model);
    }
}
