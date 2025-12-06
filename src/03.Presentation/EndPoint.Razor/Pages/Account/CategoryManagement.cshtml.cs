using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.Entities;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Razor.Pages.Account
{
   public class CategoryViewModel
    {
        public string Name { get; set; }

    }
    public class CategoryManagementModel(ICategoryAppService category, ICookieService cookie) : BasePageModel
    {
        [BindProperty]
        public CategoryViewModel Model { get; set; }  
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var userid = cookie.GetUserId();
           var result= category.CreateCategory(userid, Model.Name);
            if(result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToPage("/Account/CreatePost");
            }
            else
            {
                Message = result.Message;
                return Page();

            }
        }
    }
}
