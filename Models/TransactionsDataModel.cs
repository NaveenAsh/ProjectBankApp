using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class TransactionsDataModel
    {

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime DOT { get; set; }

        public string TransactonType  { get; set; }
        public decimal Amount { get; set; }

        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }

        public string Remarks { get; set; }


        //Constructor
        public TransactionsDataModel()
        {
            Id = -1;
            AccountId = 0;        
            DOT = DateTime.Now;
            TransactonType = "";
            Amount = 0;
            OpeningBalance = 0;
            ClosingBalance = 0;
            Remarks = "";

        }

        public bool IsValid()
        {
            if (Amount <= 0 )
            {
                return false;
            }

            if (DOT > DateTime.Now)
            {
                return false;
            }         

            return true;
        }

    }
}
