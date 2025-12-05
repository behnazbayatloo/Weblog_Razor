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
    //public class CategoryViewModel
    //{
    //    public string Title { get; set; }
    //    public int Id { get; set; }
    //}
    public class CreatePostModel (IPostAppService postAppService): BasePageModel
    {
        [BindProperty]
        public CreatePostViewModel Model { get; set; }
       
        public List<SelectListItem> Categories { get; set; }
        
        public IActionResult OnGetCreate()
        {
            var userId = Request.Cookies["Id"];
            var firstName = Request.Cookies["FirstName"];

            if (string.IsNullOrEmpty(userId))
            {
                // کاربر لاگین نیست
                return RedirectToPage("/Account/Login");
            }
            //Categories =;
            return Page();
        }
        public IActionResult OnPostCreate()
        {
            var userId = Request.Cookies["Id"];
            var firstName = Request.Cookies["FirstName"];

            if (string.IsNullOrEmpty(userId))
            {
                // کاربر لاگین نیست
                return RedirectToPage("/Account/Login");
            }
            var newPost = new PostInputDTO
            {
                //CategoryId=Model.

            };




            return RedirectToPage("Account/Posts");
        }
    }
}
