using App.Domain.Core._CommonEntities;
using App.Domain.Core.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.AppServices
{
    public interface ICategoryAppService
    {
        Result<bool> CreateCategory(int userid, string name);
        Result<bool> DeleteCategory(int id);
        IEnumerable<GetCategoryDTO> GetAll(int id);
    }
}
