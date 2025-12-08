using App.Domain.Core._CommonEntities;
using App.Domain.Core.PostAgg.Data;
using App.Domain.Core.PostAgg.DTOs;
using App.Domain.Core.PostAgg.Entities;
using App.Domain.Core.UserAgg.Entities;
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
        public async Task<bool> CreatePostAsync(PostInputDTO model, CancellationToken ct)
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
          return await  _dbcontext.SaveChangesAsync(ct)==1;
            
        }

        public async Task<bool> EditTitlePost(EditPostDTO model, CancellationToken ct)
        {
           await _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdateAsync(set => set.SetProperty(p=>p.Title,model.Title),ct);
            return true;
        }
        public async Task<bool> EditDescriptionPostAsync(EditPostDTO model, CancellationToken ct)
        {
           await _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdateAsync(set => set.SetProperty(p => p.Description, model.Description), ct);
            return true;

        }
        public async Task<bool> EditCategoryPostAsync (EditPostDTO model, CancellationToken ct)
        {
          await  _dbcontext.Posts.Where(P => P.Id == model.Id)
                .ExecuteUpdateAsync(set => set.SetProperty(p => p.CategoryId, model.CategoryId),ct);
            return true;

        }
        public async Task<bool> EditImgPostAsync (EditPostDTO model, CancellationToken ct)
        {
           await _dbcontext.Posts.Where(P => P.Id == model.Id)
               .ExecuteUpdateAsync(set => set.SetProperty(p => p.ImageUrl, model.ImgUrl),ct);
            return true;
        }
        public async Task<string?> GetPostUrlAsync(int postId, CancellationToken ct)
        {
            return await _dbcontext.Posts.Where(P => P.Id == postId)
               .Select (p=>p.ImageUrl).FirstOrDefaultAsync(ct);
          
        }
        public async Task<bool> DeletePostAsync(int postId, CancellationToken ct) 
        {
           await _dbcontext.Posts.Where(p => p.Id == postId).ExecuteUpdateAsync(set => set.SetProperty(p => p.IsDeleted , true),ct);
            return true;
        }
        public async Task<List<PostOutputDTO>?> GetRecentPostsAsync(int userId, CancellationToken ct)

        {
          return await _dbcontext.Posts.Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PostOutputDTO
                {
                    Id=p.Id,
                    Title=p.Title,
                    Description=p.Description,
                    CreatedAt=p.CreatedAt,
                    Category=p.Category.Name,
                    Img=p.ImageUrl,
                    CategoryId=p.CategoryId
                }).ToListAsync(ct);

        }
        public async Task<PostOutputDTO?> GetPostByIdAsync (int userid,int id, CancellationToken ct)
        {
            return await _dbcontext.Posts.Where(p => p.UserId == userid && p.Id==id)
               
               .Select(p => new PostOutputDTO
               {
                   Id = p.Id,
                   Title = p.Title,
                   Description = p.Description,
                   CreatedAt = p.CreatedAt,
                   Category = p.Category.Name,
                   Img = p.ImageUrl,
                   CategoryId = p.CategoryId
               }).FirstOrDefaultAsync(ct);
        }
        public async Task<IEnumerable<ShowPostDTO>>? GetAllRecentPostsAsync(CancellationToken ct)

        {
            return await _dbcontext.Posts
                  .OrderByDescending(p => p.CreatedAt)
                  .Select(p => new ShowPostDTO
                  {
                      Id = p.Id,
                      Title = p.Title,
                      Description = p.Description,
                      CreatedAt = p.CreatedAt,
                      Category = p.Category.Name,
                      Img = p.ImageUrl,
                      Author = p.User.FirstName

                  }).ToListAsync(ct);

        }

       
    }
}
