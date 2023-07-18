using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventManagementApplication.WebUI.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        

            [Required(ErrorMessage = "The Email is required"), EmailAdress]
            public string Email { get; set; } = "";
            [Required(ErrorMessage = "Password is required"), EmailAdress]
            public string Password { get; set; } = "";

            public string errorMessage = "";
            public string successmessage = "";

            public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
            {
                base.OnPageHandlerExecuting(context);

                if (HttpContext.Session.GetString("role") != null)
                {
                    // The user is already authenticated => redirect the user to the home page
                    context.Result = new RedirectResult("/");
                }
            }
            public void OnGet()
            {
            }
            public void OnPost()
            {
                if (!ModelState.IsValid)
                {
                    errorMessage = "Data validation failed";
                    return;

                }

                //successfull data validation

                //connect to database and check the user credentials
            }

        }
    }

