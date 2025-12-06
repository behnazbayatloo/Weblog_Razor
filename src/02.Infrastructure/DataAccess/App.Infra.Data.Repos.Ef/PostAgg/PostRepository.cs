using App.Domain.Core._CommonEntities;
using App.Domain.Core.PostAgg.Data;
using App.Domain.Core.PostAgg.DTOs;
using App.Domain.Core.PostAgg.Entities;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.PostAgg
{
    public class PostRepository( AppDbContext _dbcontext) :IPostRepository
    {
        public bool CreatePost(PostInputDTO model )
        {
            var post = new Post
            {
                UserId = model.UserId,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,

            };
            _dbcontext.Posts.Add(post);
          return  _dbcontext.SaveChanges()==1;
            
        }

        public bool EditTitlePost(EditPostDTO model)
        {
            _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdate(set => set.SetProperty(p=>p.Title,model.Title));
            return true;
        }
        public bool EditDescriptionPost(EditPostDTO model)
        {
            _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdate(set => set.SetProperty(p => p.Description, model.Description));
            return true;

        }
        public bool EditCategoryPost (EditPostDTO model)
        {
            _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdate(set => set.SetProperty(p => p.CategoryId, model.CategoryId));
            return true;

        }
        public bool EditImgPost (EditPostDTO model)
        {
            _dbcontext.Posts.Where(P => P.Id == model.Id)
               .ExecuteUpdate(set => set.SetProperty(p => p.ImageUrl, model.Imag));
            return true;
        }
        public string? GetPostUrl(int postId)
        {
            return _dbcontext.Posts.Where(P => P.Id == postId)
               .Select (p=>p.ImageUrl).FirstOrDefault();
          
        }
        public bool DeletePost(int postId) 
        {
            _dbcontext.Posts.Where(p => p.Id == postId).ExecuteUpdate(set => set.SetProperty(p => p.IsDeleted , true));
            return true;
        }
        public List<PostOutputDTO>? GetRecentPosts(int userId)

        {
          return  _dbcontext.Posts.Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PostOutputDTO
                {
                    Id=p.Id,
                    Title=p.Title,
                    Description=p.Description,
                    CreatedAt=p.CreatedAt,
                    Category=p.Category.Name,
                    Img=p.ImageUrl

                }).ToList();

        }

    }
}
