using App.Domain.Core._CommonEntities;
using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CategoryAggApp
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService

    {
        public IEnumerable<GetCategoryDTO> GetAll(int id)
        {
            return categoryService.GetAll(id);
        }
        public Result<bool> CreateCategory(int userid, string name)
        {
            var result = categoryService.CreteCategory(userid, name);
            if (result)
            {
                return Result<bool>.Success("دسته بندی ثبت شد");
            }
            else return Result<bool>.Failure("دسته بندی ثبت نشد");
        }
        public Result<bool> DeleteCategory(int id)
        {
            var result = categoryService.DeleteCategory(id);
            if (result)
            { return Result<bool>.Success("دسته بندی حذف شد"); }
            else return Result<bool>.Failure("دسته بندی حذف نشد");
        }
    }
}
