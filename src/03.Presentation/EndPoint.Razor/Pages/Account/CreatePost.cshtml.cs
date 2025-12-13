using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.DTOs;
using App.Domain.Core.PostAgg.AppServices;
using App.Domain.Core.PostAgg.DTOs;
using EndPoint.Razor.Extentions;
using EndPoint.Razor.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EndPoint.Razor.Pages.Account
{
    public class CreatePostViewModel
    {
        [Required(ErrorMessage ="پر کردن این فیلد الزامیست")]
        public string Title { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامیست")]
        public string Description { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد الزامیست")]
        public IFormFile? ImageFile { get; set; }
        public int CategoryId { get; set; }
    }
   
    public class CreatePostModel (IPostAppService postAppService, ICategoryAppService category,ICookieService cookie): BasePageModel
    {
        [BindProperty]
        public CreatePostViewModel CPost { get; set; }
        
        public List<SelectListItem> Categories { get; set; }
         
        public string Message { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        public async Task<IActionResult> OnGet(CancellationToken ct)
        {

           
            

            if (GetUserId() == 0)
            {
                // کاربر لاگین نیست
                return RedirectToPage("/Account/Login");
            }
            var cat = await category.GetAll(GetUserId(), ct);
            Categories= cat.Select(c=> new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
           
            return Page();
        }
        public async Task<IActionResult> OnPost(CancellationToken ct)
        {

           
            var newPost = new PostInputDTO
            {
                UserId = GetUserId(),
                CategoryId=CPost.CategoryId,
                Description = CPost.Description,
                Img = CPost.ImageFile,
                Title = CPost.Title
                
            };
            var result=await postAppService.CrestePost(newPost,ct);
            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Account/PostMangement");
            }
            else
            {
                var cat = await category.GetAll(GetUserId(), ct);
                Categories= cat.Select(c => new SelectListItem
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
