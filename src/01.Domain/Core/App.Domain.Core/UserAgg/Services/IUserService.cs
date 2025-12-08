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
        Task<bool> ExistEmail(string email, CancellationToken ct);
        string HashPassword(string password);
        Task<LoginOutputUserDTO> Login(string email, string password, CancellationToken ct);
        Task<bool> Register(RegisterUserInputDTO model, CancellationToken ct);
    }
}
