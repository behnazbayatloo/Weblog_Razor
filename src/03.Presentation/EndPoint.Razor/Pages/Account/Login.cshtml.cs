using App.Domain.Core.UserAgg.AppServices;
using EndPoint.Razor.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Razor.Pages.Account
{
    public class LoginViewModel
    {
       
        public string Email { get; set; }
     
        public string Password { get; set; }
    }

    public class LoginModel (IUserAppService userAppService, ICookieService cookieService) : BasePageModel
    {
        [BindProperty]
        public LoginViewModel Model { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var loginResult= userAppService.Login(Model.Email,Model.Password);
          
            if (loginResult.IsSuccess)
            {
                cookieService.Set("Id", loginResult.Data.Id.ToString());
                cookieService.Set("FirstName", loginResult.Data.FirstName);
                cookieService.Set("LastName", loginResult.Data.LastName);
                cookieService.Set("Email", loginResult.Data.Email);
                return RedirectToPage("/Account/CreatePost");
            }
            else
            {
                Message = loginResult.Message;
            }


            return Page();
        }
    }
}
