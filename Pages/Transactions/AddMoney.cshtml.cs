using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectBankApp.DataAccess;
using ProjectBankApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectBankApp.Pages.Transactions
{
    [Authorize(Roles = "User")]
    public class AddMoneyModel : PageModel
    {

        [BindProperty]
        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }

        [BindProperty]
        [Display(Name = "MyAccount")]
        [Required]
        public string MyAccount { get; set; }


      
        public DateTime DOT { get; set; }


        public string Remarks { get; set; }

        public string TransactionType { get; set; }
        public decimal OpeninBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        

        public AddMoneyModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            MyAccount = "";
            DOT = DateTime.Now;
            Amount = 0;
            TransactionType = "Credit";
            OpeninBalance = 0;
            ClosingBalance = 0;
            MyAccount = "";
            Remarks = "";

        }

        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId").Value;

            

            if (userId <= 0)
            {
                ErrorMessage = "Invalid ID";
                return;
            }

            //var customerData = new CustomerDataAccess();
            //var customer = customerData.GetById(userId);

            //if (customer != null)
            //{
            //    FirstName = customer.FirstName;
            //}
            //else
            //{
            //    ErrorMessage = "No Record Found with this Id";
            //}

            var accountData = new AccountsDataAccess();
            var account = accountData.GetByCustomerId(userId);

            if(account != null)
            {
                MyAccount = account.AccountNo;
            }
            else
            {
                ErrorMessage = "No Record Found with this Id";

            }
        }

        private string GetAccountNumber(int userId)
        {
            
            var accountDataAccess = new AccountsDataAccess();

            var accNumber = accountDataAccess.GetAccountById(userId);

           
            string accNo = accNumber.AccountNo;
            
            return accNo;
        }

        private decimal GetCurrentBalance(int userId)
        {
            //var userId = HttpContext.Session.GetInt32("UserId").Value;
            

            var accountDataAccess = new AccountsDataAccess();
            var accId = accountDataAccess.GetAccountById(userId);

            decimal curBal = accId.CurrentBalance;

            return curBal;
        }
     
        

        public void OnPost()
        {

            var userId = HttpContext.Session.GetInt32("UserId").Value;
            


            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please Try again";
                return;

            }


            var accountDataAccess = new AccountsDataAccess();

            var account = accountDataAccess.GetAccountById(userId);


            string accNo = account.AccountNo;
            int accId = account.Id;
            string accType = account.AccountType;

            var closingBalance = account.CurrentBalance + Amount;


            var transactionData = new TransactionsDataAccess();
            var newTransaction = new TransactionsDataModel
            {
                AccountId = accId,
                DOT = DOT,
                TransactonType = TransactionType,
                Amount = Amount,
                OpeningBalance = account.CurrentBalance,
                ClosingBalance = closingBalance,
                Remarks = $"Rs.{Amount}/- has been Credited to your account No. XXX{accNo.Substring(accNo.Length-4)} by using Online Add Money option on {DOT}. Your Current Balance is {closingBalance}"


            };

            var insertedTransaction = transactionData.Insert(newTransaction);
            ErrorMessage = "";
            if (insertedTransaction != null || insertedTransaction.Id > 0)
            {

                var result = accountDataAccess.UpdateBalance(closingBalance, userId);
                if (result)
                {
                    SuccessMessage = $"Successfully Credited Rs.{Amount} to your Account.";
                    return;
                }
            }

            ErrorMessage = $"Oh Snap! Transaction Falied. Please Try Again - {transactionData.ErrorMessage} - {accountDataAccess.ErrorMessage}";

        }
    }
}


