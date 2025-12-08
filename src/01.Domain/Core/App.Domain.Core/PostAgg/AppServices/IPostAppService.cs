using App.Domain.Core._CommonEntities;
using App.Domain.Core.PostAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.AppServices
{
    public interface IPostAppService
    {
        Task<Result<bool>> CrestePost(PostInputDTO postDTO, CancellationToken ct);
        Task<bool> DeletePost(int id, CancellationToken ct);
        Task<bool> EditPost(EditPostDTO postDTO, CancellationToken ct);
        Task<IEnumerable<ShowPostDTO>?> GetAllRecentPostsasync(CancellationToken ct);
        Task<PostOutputDTO?> GetPostById(int userid, int id, CancellationToken ct);
        Task<List<PostOutputDTO>> GetRecentPost(int userid, CancellationToken ct);
    }
}
