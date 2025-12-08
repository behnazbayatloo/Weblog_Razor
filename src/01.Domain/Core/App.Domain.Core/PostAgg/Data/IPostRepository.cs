using App.Domain.Core.PostAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.PostAgg.Data
{
    public interface IPostRepository
    {
        Task<bool> CreatePostAsync(PostInputDTO model, CancellationToken ct);
       Task< bool> DeletePostAsync(int postId, CancellationToken ct);
        Task<bool> EditCategoryPostAsync(EditPostDTO model, CancellationToken ct);
        Task<bool> EditDescriptionPostAsync(EditPostDTO model, CancellationToken ct);
       Task< bool> EditImgPostAsync(EditPostDTO model, CancellationToken ct);
        Task<bool> EditTitlePost(EditPostDTO model, CancellationToken ct);
        Task<IEnumerable<ShowPostDTO>>? GetAllRecentPostsAsync(CancellationToken ct);
        Task<PostOutputDTO>? GetPostByIdAsync(int userid, int id, CancellationToken ct);
        Task<string>? GetPostUrlAsync(int postId, CancellationToken ct);
        Task<List<PostOutputDTO>>? GetRecentPostsAsync(int userId, CancellationToken ct);
    }
}
