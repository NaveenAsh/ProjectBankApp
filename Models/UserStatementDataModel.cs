using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class UserStatementDataModel
    {

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime DOT { get; set; }

        public string TransactonType { get; set; }
        public decimal Amount { get; set; }

        public string AccountNo { get; set; }
        public string AccountType { get; set; }

        public string AccountHolderName { get; set; }



        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }

        public string Remarks { get; set; }


        //Constructor
        public UserStatementDataModel()
        {
            Id = -1;
            AccountId = 0;
            DOT = DateTime.Now;
            TransactonType = "";
            Amount = 0;
            OpeningBalance = 0;
            ClosingBalance = 0;
            Remarks = "";
            AccountNo = "";
            AccountType = "";
            AccountHolderName = "";

        }

     

    }
}
