using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;

namespace ProjectBankApp.Pages
{
    public class IndexModel : PageModel
    {
        

        [FromQuery(Name = "action")]
        public string Action { get; set; }
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
           
          

        }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(Action) && Action.ToLower() == "logout")
            {
                Logout();
                return;
            }
        }

        public void OnPost()
            {
                Logout();
            }
        
        
        private void Logout()
        {
            HttpContext.SignOutAsync();
            Response.Redirect("/Index");
        }
    }
}
