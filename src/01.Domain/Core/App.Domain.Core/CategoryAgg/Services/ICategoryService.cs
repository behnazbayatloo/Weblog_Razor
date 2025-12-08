using App.Domain.Core.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Services
{
    public interface ICategoryService
    {
        Task<bool> CreteCategory(int userid, string categoryName, CancellationToken ct);
        Task<bool> DeleteCategory(int id, CancellationToken ct);
        Task<IEnumerable<GetCategoryDTO>> GetAll(int id, CancellationToken ct);
    }
}
