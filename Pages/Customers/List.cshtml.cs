using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;

namespace ProjectBankApp.Pages.Customers
{
    public class ListModel : PageModel
    {
        public List<CustomerDataModel> CustomerList { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public ListModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            CustomerList = new List<CustomerDataModel>();

        }


        public void OnGet()
        {
            var customerData = new CustomerDataAccess();
            CustomerList = customerData.GetAll();
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

        //    var customerData = new UserDetailsDataAccess();
        //    CustomerList = customerData.SearchByName(SearchText, SearchText);

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

