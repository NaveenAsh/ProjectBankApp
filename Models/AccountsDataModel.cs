using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class AccountsDataModel
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public string AccountNo { get; set; } 
        public string AccountType { get; set; }
        public DateTime ACD { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountStatus { get; set; }
        

        //Constructor
        public AccountsDataModel()
        {
            Id = -1;
            CustomerId = 0;
            BranchId= 0;
            AccountNo = "";
            AccountType = "";
            ACD = DateTime.Now;
            CurrentBalance = 0;
            AccountStatus = "";



        }

        public bool IsValid()
        {

            if (AccountType == null || AccountType.Trim() == "" || AccountType.Trim().Length <= 3)
            {
                return false;
            }

            if (AccountNo == null || AccountNo.Trim() == "" || AccountNo.Trim().Length > 12)
            {
                return false;
            }
          
            if (ACD > DateTime.Now)
            {
                return false;
            }

            if (AccountStatus == null || AccountStatus.Trim() == "" )
            {
                return false;
            }

           


          

            return true;
        }

    }
}
