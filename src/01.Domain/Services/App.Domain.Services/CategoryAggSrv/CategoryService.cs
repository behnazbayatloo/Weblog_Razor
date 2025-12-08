using App.Domain.Core.CategoryAgg.Data;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.CategoryAggSrv
{
    public class CategoryService(ICategoryRepository categoryRepository) :ICategoryService
    {
        public async Task<IEnumerable<GetCategoryDTO>> GetAll(int id, CancellationToken ct)
        {
           return await categoryRepository.GetAllAsync(id,ct);
        }
        public async Task<bool> CreteCategory(int userid,string categoryName, CancellationToken ct) =>await categoryRepository.CreateCategoryAsync(userid, categoryName,ct);
    public async Task<bool> DeleteCategory(int id, CancellationToken ct) =>await categoryRepository.DleteCategoryAsync(id,ct);
    }
}
