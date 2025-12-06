using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.PostAgg.AppServices;
using App.Domain.Core.PostAgg.DTOs;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Razor.Pages.Account
{
    public class CreatePostViewModel
    {
        [Required(ErrorMessage ="پر کردن این فیلد الزامیست")]
        public string Title { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامیست")]
        public string Description { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامیست")]
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
   
    public class CreatePostModel (IPostAppService postAppService, ICategoryAppService category,ICookieService cookie): BasePageModel
    {
        [BindProperty]
        public CreatePostViewModel Model { get; set; }
        
        public List<SelectListItem> Categories { get; set; }
         
        public string Message { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        public IActionResult OnGet()
        {

           
            

            if (GetUserId() == 0)
            {
                // کاربر لاگین نیست
                return RedirectToPage("/Login");
            }
            
            Categories = category.GetAll(GetUserId()).Select(c=> new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();

            return Page();
        }
        public IActionResult OnPost()
        {

            
            var newPost = new PostInputDTO
            {
                UserId = GetUserId(),
                CategoryId=Model.CategoryId,
                Description = Model.Description,
                ImageUrl = Model.ImageUrl,
                Title = Model.Title
                
            };
            var result= postAppService.CrestePost(newPost);
            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/PostManagement");
            }
            else
            {
                
                Categories = category.GetAll(GetUserId()).Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name

                }).ToList();
                Message = result.Message;
                return Page();

            }
            
            
        }
    }
}
