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
        Result<bool> CrestePost(PostInputDTO postDTO);
        bool DeletePost(int id);
        bool EditPost(EditPostDTO postDTO);
        IEnumerable<ShowPostDTO>? GetAllRecentPosts();
        PostOutputDTO? GetPostById(int userid, int id);
        List<PostOutputDTO> GetRecentPost(int userid);
    }
}
