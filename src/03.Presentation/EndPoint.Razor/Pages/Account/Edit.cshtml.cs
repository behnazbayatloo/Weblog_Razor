using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.AppServices;
using App.Domain.Core.PostAgg.DTOs;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace EndPoint.Razor.Pages.Account
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string CreateAt { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? ImgFile { get; set; } 
    }

    public class EditModel (IPostAppService postApp ,ICategoryAppService category) : BasePageModel
    {
        [BindProperty]
        public EditPostViewModel Post { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public void OnGet(int id)
        {
            Categories = category.GetAll(GetUserId()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
            var model = postApp.GetPostById(GetUserId(), id);
            Post = new EditPostViewModel { 
            CategoryId=model.CategoryId,
            Description=model.Description,
            Title=model.Title,
            ImageUrl=model.Img,
            
            };

        }
        public IActionResult OnPost ()
        {
            var newPost = new EditPostDTO
            {
                Id = Post.Id,
                Title = Post.Title,
                CategoryId=Post.CategoryId,
                Description = Post.Description,
                Imag=Post.ImgFile

            };
            var result = postApp.EditPost(newPost);
            if(result)
            {
                return RedirectToPage("/Account/PostMangement");
            }
            return Page();
        }
    }
}
