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
      

        public bool Register(RegisterUserInputDTO model)
        {
            var entity = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                HashPassword = model.HashPassword
               
            };

            _dbcontext.Users.Add(entity);
            return _dbcontext.SaveChanges() == 1;
        }

        public bool ExistEmail(string email)
        {
            return _dbcontext.Users.Any(u => u.Email == email); 
        }

        public LoginOutputUserDTO? Login(string email, string password)
        {
            return _dbcontext.Users.Where(u => u.Email == email && u.HashPassword == password)
                .Select(u => new LoginOutputUserDTO
                {
                    Email = email,
                    Id = u.Id,
                    LastName = u.LastName,
                    FirstName = u.FirstName
                }).FirstOrDefault();

        }
    }
}
