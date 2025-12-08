using App.Domain.Core.UserAgg.AppServices;
using App.Domain.Core.UserAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Razor.Pages.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
        [DataType(DataType.EmailAddress,ErrorMessage ="لطفا ادرس ایمیل را وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پر کردن این فیلد اجباریست")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage="رمز شما حداقل باید 5 کاراکتر باشد")]
        [MaxLength(10,ErrorMessage = "رمز شما حداکثر باید 10 کاراکتر باشد")]
        public string Password { get; set; }
    }

    public class RegisterModel(IUserAppService userAppService) : PageModel
    {
        [BindProperty]
        public RegisterViewModel Model { get; set; }
        public string Massege { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(CancellationToken ct)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var usermodel = new RegisterUserInputDTO()
            {
Email = Model.Email,
FirstName = Model.FirstName,
LastName = Model.LastName,
HashPassword=Model.Password
            };
            var registerResult = await userAppService.Register(usermodel,ct);
            if (registerResult.IsSuccess)
            {
                Massege = registerResult.Message;
                return RedirectToPage("/Account/Login");
            }
            else
            {
                Massege = registerResult.Message;
            }
            return Page();
        }
    }
}
