using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectBankApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]

        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "MiddleName")]
        [Required]
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
        [Display(Name = "BranchId")]
        [Required]
        public int BranchId { get; set; }



        [BindProperty]
        [Display(Name = "AccountStatus")]
        [Required]
        public string AccountStatus { get; set; }

        public string AccountNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public List<SelectListItem> BranchesList { get; set; }
        public List<SelectListItem> Genders { get; set; }

        public List<SelectListItem> AccountTypeList { get; set; }

        public List<SelectListItem> StateList { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public EditModel()
        {
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
            SuccessMessage = "";
            ErrorMessage = "";
            Genders = GetGenders();
            StateList = GetState();
            AccountTypeList = GetAccountType();
            UserName = "";
            Password = "";
            BranchesList = GetBranches();
            Status = "";
        }

        private List<SelectListItem> GetGenders()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Male", Value = "M" });
            selectItems.Add(new SelectListItem { Text = "Female", Value = "F" });
            selectItems.Add(new SelectListItem { Text = "Unspecified", Value = "U" });

            return selectItems;
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
        public void OnGet(int id)
        {
            Id = id;

            if (Id <= 0)
            {
                ErrorMessage = "Invalid ID";
                return;
            }

            var customerData = new CustomerDataAccess();
            var customer = customerData.GetById(id);

            if (customer != null)
            {
                FirstName = customer.FirstName;
                MiddleName = customer.MiddleName;
                LastName = customer.LastName;
                DOB = customer.DOB;
                Gender = customer.Gender;
                Address = customer.Address;
                City = customer.City;
                State = customer.State;
                Pincode = customer.Pincode;
                EmailId = customer.EmailId;
                MoblieNumber = customer.MobileNumber;
                Occupation = customer.Occupation;               
            }

            var accountData = new AccountsDataAccess();
            var account = accountData.GetByCustomerId(id);

            if( account!= null)
            {
                AccountType = account.AccountType;
                AccountStatus = account.AccountStatus;
            }

            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {

            StateList = GetState();
            AccountTypeList = GetAccountType();
            Genders = GetGenders();
            BranchesList = GetBranches();

            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data.Please correct and try again.";
                return;
            }

            var customerData = new CustomerDataAccess();
            var custToUpdate = new CustomerDataModel {Id=Id, FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, DOB = DOB, Gender = Gender,
                Address = Address, City = City, State = State, Pincode = Pincode, EmailId = EmailId, MobileNumber = MoblieNumber, Occupation = Occupation};
            var updatedCustomer = customerData.Update(custToUpdate);

            if (updatedCustomer == null || updatedCustomer.Id <= 0)
            {
                ErrorMessage = $"Oh Snap! Add Falied. Please Try Again - {updatedCustomer.ErrorMessage}";
                return;
            }

            var accountData = new AccountsDataAccess();
            var updAccount = new AccountsDataModel
            {
             
                CustomerId = updatedCustomer.Id,
                AccountType = AccountType,
                AccountStatus = AccountStatus,
            };

            var updatedAccount = accountData.AccountUpdate(updAccount);


            if (updatedAccount != null)
            {
                SuccessMessage = $"Successfully inserted Department{updatedCustomer.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = $"Oh Snap! Add Falied. Please Try Again - {accountData.ErrorMessage}";
            }


        }


    }
}
