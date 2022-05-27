//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Security.Claims;
//using ProjectBankApp.DataAccess;
//using ProjectBankApp.Models;

//namespace ProjectBankApp.Pages.Users
//{
//    public class UserDashBoardModel : PageModel
//    {
//        public decimal CurrentBalance { get; set; }
//        public string AccountNumber { get; set; }
//        public string UserName { get; set; }

//        public string ErrorMessage { get; set; }

//        [FromQuery(Name = "action")]
//        public string Action { get; set; }
//        private readonly ILogger<UserDashBoardModel> _logger;


//        public UserDashBoardModel(ILogger<UserDashBoardModel> logger)
//        {
//            _logger = logger;
//            CurrentBalance = 0;
//            AccountNumber = "";
//            UserName = "";
//            ErrorMessage = "";

//        }
//        public void OnGet()
//        {
//            var userId = HttpContext.Session.GetInt32("UserId").Value;

//            if (!String.IsNullOrEmpty(Action) && Action.ToLower() == "logout")
//            {
//                Logout();
//                return;
//            }

//            var userDashBoardData = new UserDashBoardDataAccess();
//            var userDashBoardData2 = new UserDashBoardDataAccess();
//            var dashboardUname = userDashBoardData2.GetUserName(userId);
//            var dashboard = userDashBoardData.GetAccountDetails(userId);
//            if (dashboard != null)
//            {
//                AccountNumber = dashboard.AccountNumber;
//                CurrentBalance = dashboard.CurrentBalance;
//                UserName = dashboardUname.UserName;
//            }
//            else
//            {
//                ErrorMessage = $"No Dashboard Data Available - {userDashBoardData.ErrorMessage}";
//            }

         
//        }
//        public void OnPost()
//        {
//            Logout();
//        }
//        private void Logout()
//        {
//            HttpContext.SignOutAsync();
//            Response.Redirect("/Index");
//        }
//    }
//}
