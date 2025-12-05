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
        Result<LoginOutputUserDTO> Login(string email, string password);
        Result<bool> Register(RegisterUserInputDTO model);
    }
}
