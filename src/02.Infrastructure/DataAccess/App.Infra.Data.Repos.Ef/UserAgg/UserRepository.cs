using App.Domain.Core.UserAgg.Data;
using App.Domain.Core.UserAgg.DTOs;
using App.Domain.Core.UserAgg.Entities;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.UserAgg
{
    public class UserRepository(AppDbContext _dbcontext):IUserRepository
    {
      

        public async Task<bool> RegisterAsync(RegisterUserInputDTO model, CancellationToken ct)
        {
            var entity = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                HashPassword = model.HashPassword
               
            };

            _dbcontext.Users.Add(entity);
            return await _dbcontext.SaveChangesAsync(ct) == 1;
        }

        public async Task<bool> ExistEmailAsync(string email, CancellationToken ct)
        {
            return await _dbcontext.Users.AnyAsync(u => u.Email == email,ct); 
        }

        public async Task<LoginOutputUserDTO?> LoginAsync(string email, string password, CancellationToken ct)
        {
            return await _dbcontext.Users.Where(u => u.Email == email && u.HashPassword == password)
                .Select(u => new LoginOutputUserDTO
                {
                    Email = email,
                    Id = u.Id,
                    LastName = u.LastName,
                    FirstName = u.FirstName
                }).FirstOrDefaultAsync(ct);

        }
    }
}
