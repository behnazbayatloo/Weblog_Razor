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
        public List<GetCategoryDTO> GetAll(int id)
        {
           return  categoryRepository.GetAll(id);
        }
    }
}
