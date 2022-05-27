using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;

namespace ProjectBankApp.Pages.Users
{
    public class UserStatementModel : PageModel
    {
        public List<UserStatementDataModel> UserStatementList { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public UserStatementModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            UserStatementList = new List<UserStatementDataModel>();

        }


        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId").Value;

            var userTransaction = new UserDetailsDataAccess();
            UserStatementList = userTransaction.GetAllTransactionsById(userId);
        }



        public void OnPostSearch()
        {
            //    if (!ModelState.IsValid)
            //    {
            //        ErrorMessage = "Invalid DATA!!!!!";
            //        return;
            //    }

            //    if (string.IsNullOrEmpty(SearchText) || SearchText.Length < 2)
            //    {
            //        ErrorMessage = "Please Enter a string of length a minimum of 2 characters or more.";
            //        return;
            //    }

            //    var customerData = new CustomerDataAccess();
            //    CustomerList = customerData.GetByName(SearchText, SearchText, SearchText, SearchText);

            //    //if (Departments != null || Departments.Count > 0)

            //    if (CustomerList != null && CustomerList.Count > 0)
            //    {
            //        SuccessMessage = $"{CustomerList.Count} data(s) Found";

            //    }
            //    else
            //    {
            //        ErrorMessage = "Sorry! No Data Found.";

            //    }
            //}

            //public void OnPostClear()
            //{
            //    SearchText = "";
            //    ModelState.Clear();

            //    var customerData = new CustomerDataAccess();
            //    CustomerList = customerData.GetByName(SearchText, SearchText, SearchText, SearchText);


        }

    }
}

