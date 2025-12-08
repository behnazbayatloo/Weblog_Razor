using App.Domain.Core.PostAgg.Data;
using App.Domain.Core.PostAgg.DTOs;
using App.Domain.Core.PostAgg.Services;
using Files.Contrcat;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.PostAggSrv
{
    public class PostService(IPostRepository postrepo,IFileService fileservice):IPostService
    {
        public async Task<bool> CeatePost (PostInputDTO model, CancellationToken ct) => await postrepo.CreatePostAsync (model,ct);
        public async Task<bool> DeletePost (int id, CancellationToken ct) =>await postrepo.DeletePostAsync (id,ct);

        public async Task<bool> EditPost(EditPostDTO model, CancellationToken ct)
        {
            if (model.Title != null)
            {
                await postrepo.EditTitlePost(model,ct);
            }
            if (model.Description != null)
            {
                await postrepo.EditDescriptionPostAsync(model,ct);
            }
            if (model.CategoryId != null)
            {
              await  postrepo.EditCategoryPostAsync(model,ct);
            }
            if (model.Imag != null)
            {
                var img =await  postrepo.GetPostUrlAsync(model.Id,ct);
                fileservice.Delete(img,ct);
                model.ImgUrl =await fileservice.Upload(model.Imag,"Post",ct);
               
               await postrepo.EditImgPostAsync(model, ct);
            }
            return true;
        }
        public async Task<List<PostOutputDTO>> GetRecentPost(int userid, CancellationToken ct) =>await postrepo.GetRecentPostsAsync(userid,ct);
        public async Task<PostOutputDTO?> GetPostById(int userid, int id, CancellationToken ct) =>await postrepo.GetPostByIdAsync(userid, id,ct);
        public async Task<IEnumerable<ShowPostDTO>?> GetAllRecentPosts( CancellationToken ct) =>await postrepo.GetAllRecentPostsAsync(ct);

      
    }
}
