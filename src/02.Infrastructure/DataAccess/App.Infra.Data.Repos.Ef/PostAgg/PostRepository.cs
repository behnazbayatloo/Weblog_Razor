using App.Domain.Core.PostAgg.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.PostAgg
{
    public class PostRepository( AppDbContext _dbcontext) :IPostRepository
    {
    }
}
