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
        public Result<bool> CrestePost(PostInputDTO postDTO)
        {
            if(postDTO.Img is not null)

            { postDTO.ImageUrl = file.Upload(postDTO.Img, "Post"); }
           
           var result= postService.CeatePost(postDTO);
            if (result)
            {
                return Result<bool>.Success("پست با موفقیت ذخیره شد");
            }
            else
                return Result<bool>.Failure("پست ذخیره نشد");
        }
        public List<PostOutputDTO> GetRecentPost(int userid)
        {
             return postService.GetRecentPost(userid);
        }
        public bool EditPost(EditPostDTO postDTO) => postService.EditPost(postDTO);
        public bool DeletePost(int id) => postService.DeletePost(id);
    }
}
