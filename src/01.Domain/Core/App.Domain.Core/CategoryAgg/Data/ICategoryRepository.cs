using App.Domain.Core.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryAgg.Data
{
    public interface ICategoryRepository
    {
        Task<bool> CreateCategoryAsync(int userid, string name,CancellationToken ct);
        Task<bool> DleteCategoryAsync(int id, CancellationToken ct);
        Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int userid, CancellationToken ct);
    }
}
