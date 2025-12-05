using App.Domain.Core.CategoryAgg.Data;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CategoryAgg
{
    public class CategoryRepository (AppDbContext _dbcontext):ICategoryRepository
    {
       public List<GetCategoryDTO> GetAll (int userid)
        {
            return _dbcontext.Categories.Where(C=>C.UserId == userid)
                .Select (c=> new GetCategoryDTO
                {
                    Id=c.Id,
                    Name=c.Name,
                })
                .ToList();
        }
    }
}
