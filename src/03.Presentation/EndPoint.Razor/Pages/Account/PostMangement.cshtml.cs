using App.Domain.Core.PostAgg.AppServices;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Razor.Pages.Account
{
    public class PostViewModel
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
        public List<PostViewModel> Posts { get; set; }
        public string Message { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        
        public void OnGet()
        {
            var id = cookie.GetUserId();
            Posts = postappsrv.GetRecentPost(id).Select (p=> new PostViewModel
            {
                Id=p.Id,
                Title=p.Title,
                ImageUrl=p.Img,
                Category=p.Category,
                Description=p.Description.Length> 200 ? p.Description.Substring(0, 200) + "..." : p.Description,
                CreateAt=p.CreatedAt.ToPersianString("yyyy/mm/dd")
            } 
            ).ToList();

        }
       
        public IActionResult OnPostDelete (int id)
        {
            var result = postappsrv.DeletePost(id);
            if (result)
            {
                Message = "پست حذف شد";
            }else
            {
                Message = "پست حذف نشد";
            }
                return Page();
        }
        
    }
}
