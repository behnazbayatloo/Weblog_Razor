using App.Domain.Core.PostAgg.AppServices;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint.Razor.Pages.Account
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? Img { get; set; }
        public string Author { get; set; }
    }
    public class PostsModel(IPostAppService postapp) : BasePageModel
    {
        public List<PostViewModel> Posts { get; set; }
        public void OnGet()
        {
            Posts = postapp.GetAllRecentPosts().Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                CreatedAt = p.CreatedAt.ToPersianString("yyyy/mm/dd"),
                Author = p.Author,
                Img = p.Img,
                Category  = p.Category,
                Description=p.Description,

            }).ToList();
        }
    }
}
