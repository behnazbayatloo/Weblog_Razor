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
        public async Task<IActionResult> OnPostAsync( CancellationToken ct)
        {
           
           var result= await category.CreateCategory(GetUserId(), Model.Name,ct);
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
