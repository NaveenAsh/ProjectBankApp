using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;

namespace ProjectBankApp.Pages.Users
{
    public class AllUserProfileModel : PageModel
    {
        public List<UserProfileDataModel> UserProfileList { get; set; }
        public List<UserProfileDataModel> SearchList { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public AllUserProfileModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SearchText = "";
            UserProfileList = new List<UserProfileDataModel>();
            SearchList = new List<UserProfileDataModel>();

        }


        public void OnGet()
        {
            var usersProfile = new UserDetailsDataAccess();
            UserProfileList = usersProfile.GetAllUserProfile();
        }



        public void OnPostSearch()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid DATA!!!!!";
                return;
            }

            if (string.IsNullOrEmpty(SearchText) || SearchText.Length < 2)
            {
                ErrorMessage = "Please Enter a string of length a minimum of 2 characters or more.";
                return;
            }

            var customerData = new UserDetailsDataAccess();
            UserProfileList = customerData.SearchByName(SearchText, SearchText);

            //if (Departments != null || Departments.Count > 0)

            if (UserProfileList != null && UserProfileList.Count > 0)
            {
                SuccessMessage = $"{UserProfileList.Count} data(s) Found";

            }
            else
            {
                ErrorMessage = "Sorry! No Data Found.";

            }
        }

        public void OnPostClear()
        {
            SearchText = "";
            ModelState.Clear();

            var customerData = new UserDetailsDataAccess();
            UserProfileList = customerData.SearchByName(SearchText, SearchText);


        }

    }
}

