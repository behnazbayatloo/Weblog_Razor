using App.Domain.Core.CategoryAgg.Data;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.CategoryAgg.Entities;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CategoryAgg
{
    public class CategoryRepository (AppDbContext _dbcontext):ICategoryRepository
    {
       public IEnumerable<GetCategoryDTO> GetAll (int userid)
        {
            return _dbcontext.Categories.Where(C=>C.UserId == userid)
                .Select (c=> new GetCategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }
        public bool CreateCategory(int userid,string name)
        {
            var cat = new Category { UserId= userid,Name = name };
            _dbcontext.Categories.Add(cat);
           return _dbcontext.SaveChanges() == 1;
        }
        public bool DleteCategory(int id)
        {
            _dbcontext.Categories.Where(c => c.Id == id)
                .ExecuteDelete();
            return true;
        }
    }
}
