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
       Task< bool> ExistEmailAsync(string email, CancellationToken ct);
        Task<LoginOutputUserDTO>? LoginAsync(string email, string password, CancellationToken ct);
        Task<bool> RegisterAsync(RegisterUserInputDTO model, CancellationToken ct);
    }
}
