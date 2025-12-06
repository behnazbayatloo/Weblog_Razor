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
        public bool CeatePost (PostInputDTO model)=>postrepo.CreatePost (model);
        public bool DeletePost (int id)=>postrepo.DeletePost (id);

        public bool EditPost(EditPostDTO model)
        {
            if (model.Title != null)
            {
                postrepo.EditTitlePost(model);
            }
            if (model.Description != null)
            {
                postrepo.EditDescriptionPost(model);
            }
            if (model.CategoryId != null)
            {
                postrepo.EditCategoryPost(model);
            }
            if (model.Imag != null)
            {
                var img = postrepo.GetPostUrl(model.Id);
                fileservice.Delete(img);
                model.ImgUrl = fileservice.Upload(model.Imag,"Post");
               
                postrepo.EditImgPost(model);
            }
            return true;
        }
        public List<PostOutputDTO> GetRecentPost(int userid) => postrepo.GetRecentPosts(userid);
        public PostOutputDTO? GetPostById(int userid, int id) => postrepo.GetPostById(userid, id);
        public IEnumerable<ShowPostDTO>? GetAllRecentPosts()=> postrepo.GetAllRecentPosts();
    }
}
