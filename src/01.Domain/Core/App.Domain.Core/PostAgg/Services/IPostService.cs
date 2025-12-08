using App.Domain.Core.PostAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.Services
{
    public interface IPostService
    {
         Task<bool> CeatePost(PostInputDTO model, CancellationToken ct);
        Task<bool> DeletePost(int id, CancellationToken ct);
        Task<bool> EditPost(EditPostDTO model, CancellationToken ct);
      Task< IEnumerable<ShowPostDTO>?> GetAllRecentPosts( CancellationToken ct);
        Task<PostOutputDTO?> GetPostById(int userid, int id, CancellationToken ct);
       Task< List<PostOutputDTO>> GetRecentPost(int userid, CancellationToken ct);
    }
}
