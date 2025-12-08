using App.Domain.Core.CategoryAgg.Data;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CategoryAgg
{
    public class CategoryRepository (AppDbContext _dbcontext):ICategoryRepository
    {
       public async Task<IEnumerable<GetCategoryDTO>> GetAllAsync (int userid, CancellationToken ct)
        {
            return await _dbcontext.Categories.Where(C=>C.UserId == userid)
                .Select (c=> new GetCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync(ct);
        }
        public async Task<bool> CreateCategoryAsync(int userid,string name, CancellationToken ct)
        {
            var cat = new Category { UserId= userid,Name = name };
            _dbcontext.Categories.Add(cat);
           return await _dbcontext.SaveChangesAsync(ct) == 1;
        }
        public async Task<bool> DleteCategoryAsync(int id, CancellationToken ct)
        {
           await _dbcontext.Categories.Where(c => c.Id == id)
                .ExecuteDeleteAsync(ct);
            return true;
        }
    }
}
