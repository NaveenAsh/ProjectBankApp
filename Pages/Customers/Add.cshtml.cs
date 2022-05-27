using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectBankApp.Pages.Customers
{
    //[Authorize()]
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [BindProperty]
        [Display(Name = "LastName")]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DOB { get; set; }

        [BindProperty]
        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }


        [BindProperty]
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        [BindProperty]
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [BindProperty]
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [BindProperty]
        [Display(Name = "Pincode")]
        [Required]
        public string Pincode { get; set; }

        [BindProperty]
        [Display(Name = "EmailId")]
        [Required]
        public string EmailId { get; set; }

        [BindProperty]
        [Display(Name = "MoblieNumber")]
        [Required]
        public string MoblieNumber { get; set; }

        [BindProperty]
        [Display(Name = "Occupation")]
        [Required]
        public string Occupation { get; set; }

        [BindProperty]
        [Display(Name = "AccountType")]
        [Required]
        public string AccountType { get; set; }


        [BindProperty]
        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }


        public string AccountNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public DateTime ACD { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountStatus { get; set; }

        public List<SelectListItem> BranchesList { get; set; }
        public List<SelectListItem> Genders { get; set; }

        public List<SelectListItem> AccountTypeList { get; set; }

        public List<SelectListItem> StateList { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public AddModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            FirstName = "";
            MiddleName = "";
            LastName = "";
            DOB = DateTime.Now.AddYears(-19);
            Address = "";
            City = "";
            State = "";
            Pincode = "000000";
            EmailId = "";
            MoblieNumber = "0000000000";
            Genders = GetGenders();
            StateList = GetState();
            AccountTypeList = GetAccountType();
            UserName = "";
            Password = "";
            ACD = DateTime.Now;
            AccountNo = GetAccountNo();
            BranchesList = GetBranches();
            CurrentBalance = 0;
            AccountStatus = "A";
        }

        public void OnGet(int id)
        {
        }


        private List<SelectListItem> GetGenders()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Male", Value = "M" });
            selectItems.Add(new SelectListItem { Text = "Female", Value = "F" });
            selectItems.Add(new SelectListItem { Text = "Unspecified", Value = "U" });

            return selectItems;
        }

        private List<SelectListItem> GetAccountType()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Savings", Value = "Savings" });
            selectItems.Add(new SelectListItem { Text = "Current", Value = "Current" });
            selectItems.Add(new SelectListItem { Text = "Salary", Value = "Salary" });
            selectItems.Add(new SelectListItem { Text = "FD Account", Value = "FdAccount" });

            return selectItems;

        }

        private List<SelectListItem> GetBranches()
        {


            //Get Data from Data Access
            var branchDataAccess = new BranchDataAccess();
            var branchesList = branchDataAccess.GetAll();

            //Create SelectListItem
            var branchSelectionList = new List<SelectListItem>();
            foreach (var branch in branchesList)
            {
                branchSelectionList.Add(new SelectListItem
                {
                    Text = $"{branch.BranchName}",
                    Value = branch.Id.ToString(),
                });
            }
            return branchSelectionList;
        }






        private List<SelectListItem> GetState()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "TamilNadu", Value = "TamilNadu" });
            selectItems.Add(new SelectListItem { Text = "Karnataka", Value = "Karnataka" });
            selectItems.Add(new SelectListItem { Text = "Kerela", Value = "Kerela" });
            selectItems.Add(new SelectListItem { Text = "Andhra Pradesh", Value = "Andhra Pradesh" });
            selectItems.Add(new SelectListItem { Text = "Telungana", Value = "Telungana" });
            selectItems.Add(new SelectListItem { Text = "Rest of India", Value = "ROI" });


            return selectItems;

        }

        private string GetAccountNo()
        {
            var accNum = DateTime.Now.ToString("yyMMddHHmmss");

            return accNum;

        }

        private string GetUserId()
        {
            var userId = EmailId.Split('@')[0];

            return userId;

        }




        public void OnPost()
        {
            StateList = GetState();
            AccountTypeList = GetAccountType();
            AccountNo = GetAccountNo();
            Genders = GetGenders();

            BranchesList = GetBranches();



            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please Try again";
                return;

            }

            var customerData = new CustomerDataAccess();
            var newCustomer = new CustomerDataModel
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                DOB = DOB,
                Gender = Gender,
                Address = Address,
                City = City,
                State = State,
                Pincode = Pincode,
                EmailId = EmailId,
                MobileNumber = MoblieNumber,
                Occupation = Occupation,
                UserId = GetUserId(),
                Password = DOB.ToString("ddMMyyy")
            };

            var insertedCustomer = customerData.Insert(newCustomer);

            if (insertedCustomer == null || insertedCustomer.Id <= 0)
            {
                ErrorMessage = $"Oh Snap! Add Falied. Please Try Again - {customerData.ErrorMessage}";
                return;
            }

            var accountData = new AccountsDataAccess();
            var newAccount = new AccountsDataModel
            {
                CustomerId = insertedCustomer.Id,
                BranchId = BranchId,
                AccountNo = AccountNo,
                AccountType = AccountType,
                ACD = DateTime.Now,
                CurrentBalance = CurrentBalance,
                AccountStatus = AccountStatus,
            };

            var insertedAccount = accountData.Insert(newAccount);


            if (insertedAccount != null && insertedAccount.Id > 0)
            {
                SuccessMessage = $"Successfully inserted Department{insertedCustomer.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = $"Oh Snap! Add Falied. Please Try Again - {accountData.ErrorMessage}";
            }

        }
    }
}


