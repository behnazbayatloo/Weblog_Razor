using App.Domain.Core.CommentAgg.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CommentAgg
{
    public class CommentRepository (AppDbContext _dbcontext): ICommentRepository
    {
    }
}
