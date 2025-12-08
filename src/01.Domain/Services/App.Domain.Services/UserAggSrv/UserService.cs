using App.Domain.Core._CommonEntities;
using App.Domain.Core.UserAgg.Data;
using App.Domain.Core.UserAgg.DTOs;
using App.Domain.Core.UserAgg.Services;
using App.Domain.Services.HashService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.UserAggSrv
{
    public class UserService (IUserRepository _userrepo):IUserService
    {
        public string HashPassword(string password) => password.ToMd5Hex();
        public async Task<bool> ExistEmail(string email, CancellationToken ct) => await _userrepo.ExistEmailAsync(email, ct);
        public async Task<bool> Register(RegisterUserInputDTO model, CancellationToken ct) =>await _userrepo.RegisterAsync(model,ct);
        public bool EnsureEmail(string email)
        {
            if (email.Contains("@")) { return true; }
            else return false;
        }
        public bool EnsurePassword (string password)
        {
            if (password.Length<5)
            { return false; }
            else { return true; }
        }
        public async Task<LoginOutputUserDTO> Login (string email, string password, CancellationToken ct)
        {
          return await _userrepo.LoginAsync(email, password.ToMd5Hex(),ct);

        }

        
    }
}
