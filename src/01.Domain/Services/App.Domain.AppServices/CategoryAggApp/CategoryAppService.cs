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
    public class CategoryAppService (ICategoryService categoryService):ICategoryAppService

    {
        public List<GetCategoryDTO> GetAll(int id)
        {
            return categoryService.GetAll(id);
        }
    }
}
