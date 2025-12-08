using App.Domain.Core._CommonEntities;
using App.Domain.Core.UserAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.UserAgg.AppServices
{
    public interface IUserAppService
    {
        Task<Result<LoginOutputUserDTO>> Login(string email, string password, CancellationToken ct);
        Task<Result<bool>> Register(RegisterUserInputDTO model, CancellationToken ct);
    }
}
