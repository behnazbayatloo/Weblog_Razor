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
        bool CeatePost(PostInputDTO model);
        bool DeletePost(int id);
        bool EditPost(EditPostDTO model);
        IEnumerable<ShowPostDTO>? GetAllRecentPosts();
        PostOutputDTO? GetPostById(int userid, int id);
        List<PostOutputDTO> GetRecentPost(int userid);
    }
}
