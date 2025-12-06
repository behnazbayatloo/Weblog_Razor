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
        bool CreatePost(PostInputDTO model);
        bool DeletePost(int postId);
        bool EditCategoryPost(EditPostDTO model);
        bool EditDescriptionPost(EditPostDTO model);
        bool EditImgPost(EditPostDTO model);
        bool EditTitlePost(EditPostDTO model);
        string? GetPostUrl(int postId);
        List<PostOutputDTO>? GetRecentPosts(int userId);
    }
}
