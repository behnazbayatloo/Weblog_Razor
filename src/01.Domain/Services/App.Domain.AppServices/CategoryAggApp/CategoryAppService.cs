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
        public async Task<IEnumerable<GetCategoryDTO>> GetAll(int id, CancellationToken ct)
        {
            return await categoryService.GetAll(id,ct);
        }
        public async Task<Result<bool>> CreateCategory(int userid, string name, CancellationToken ct)
        {
            var result = await categoryService.CreteCategory(userid, name,ct);
            if (result)
            {
                return Result<bool>.Success("دسته بندی ثبت شد");
            }
            else return Result<bool>.Failure("دسته بندی ثبت نشد");
        }
        public async Task<Result<bool>> DeleteCategory(int id, CancellationToken ct)
        {
            var result =await categoryService.DeleteCategory(id, ct);
            if (result)
            { return Result<bool>.Success("دسته بندی حذف شد"); }
            else return Result<bool>.Failure("دسته بندی حذف نشد");
        }
    }
}
