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
        bool CreateCategory(int userid, string name);
        bool DleteCategory(int id);
        IEnumerable<GetCategoryDTO> GetAll(int userid);
    }
}
