using App.Domain.Core._CommonEntities;
using App.Domain.Core.PostAgg.AppServices;
using App.Domain.Core.PostAgg.DTOs;
using App.Domain.Core.PostAgg.Services;
using Files.Contrcat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.PostAggApp
{
    public class PostAppService (IFileService file,IPostService postService):IPostAppService
    {
        public async Task<Result<bool>> CrestePost(PostInputDTO postDTO, CancellationToken ct)
        {
            if(postDTO.Img is not null)

            { postDTO.ImageUrl =await file.Upload(postDTO.Img, "Post",ct); }
           
           var result= await postService.CeatePost(postDTO, ct);
            if (result)
            {
                return Result<bool>.Success("پست با موفقیت ذخیره شد");
            }
            else
                return Result<bool>.Failure("پست ذخیره نشد");
        }
        public async Task<List<PostOutputDTO>> GetRecentPost(int userid, CancellationToken ct)
        {
             return await postService.GetRecentPost(userid,ct);
        }
        public async Task<bool> EditPost(EditPostDTO postDTO, CancellationToken ct) =>await postService.EditPost(postDTO,ct);
        public async Task<bool> DeletePost(int id, CancellationToken ct) =>await postService.DeletePost(id,ct);
        public async Task<PostOutputDTO?> GetPostById(int userid, int id, CancellationToken ct) =>await postService.GetPostById(userid, id,ct);
        public async Task<IEnumerable<ShowPostDTO>?> GetAllRecentPostsasync(CancellationToken ct) =>await postService.GetAllRecentPosts(ct);

        

        
    }
}
