using App.Domain.Core.PostAgg.AppServices;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Razor.Pages.Account
{
    public class PostMangementViewModel
    {
        public int Id { get; set; }
        public string CreateAt { get; set; }
        public string Title { get; set; }
      public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
    public class PostMangementModel(IPostAppService postappsrv ,ICookieService cookie) : BasePageModel
    {
        [BindProperty]
        public List<PostMangementViewModel> Posts { get; set; }
        public string Message { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        
        public async Task OnGet(CancellationToken ct)
        {
            var ps = await postappsrv.GetRecentPost(GetUserId(),ct);
            Posts = ps.Select (p=> new PostMangementViewModel
            {
                Id=p.Id,
                Title=p.Title,
                ImageUrl=p.Img,
                Category=p.Category,
                Description=p.Description.Length> 10 ? p.Description.Substring(0, 10) + "..." : p.Description,
                CreateAt=p.CreatedAt.ToPersianString("yyyy/mm/dd")
            } 
            ).ToList();

        }
       
        public async Task<IActionResult> OnPostDelete (int id,CancellationToken ct)
        {
            var result =await postappsrv.DeletePost(id,ct);
            if (result)
            {
                Message = "پست حذف شد";
            }else
            {
                Message = "پست حذف نشد";
            }
                return RedirectToPage("/Account/PostMangement");
        }
        
    }
}
