using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class UserProfileDataModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Occupation { get; set; }
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public DateTime ACD { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountStatus { get; set; }
        public string BranchIFSC { get; set; }

        public string BranchName { get; set; }

        public string BranchCity { get; set; }



        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }

        //Constructor
        public UserProfileDataModel()
        {
            Id = -1;
            FirstName = "";
            MiddleName = "";
            LastName = "";
            DOB = DateTime.Now.AddYears(-20);
            Gender = "";
            Address = "";
            City = "";
            State = "";
            Pincode = "";
            MobileNumber = "";
            Pincode = "";
            EmailId = "";
            MobileNumber = "";
            Occupation = "";
           
            ErrorMessage = "";
            SuccessMessage = "";
            BranchIFSC = "";
            BranchName = "";
            BranchCity = "";
            AccountNo = "";
            AccountType = "";
            ACD = DateTime.Now;
            CurrentBalance = 0;
            AccountStatus = "";

        }


    }
}
