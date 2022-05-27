using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class CustomerDataModel
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
        public string UserId { get; set; }
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public string SuccessMessage { get; set; }
        
        //Constructor
        public CustomerDataModel()
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
            UserId = "";
            Password = "";
            ErrorMessage = "";
            SuccessMessage = "";

        }

        public bool IsValid()
        {

            if (FirstName == null || FirstName.Trim() == "" || FirstName.Trim().Length > 15)
            {
                return false;
            }

            if (MiddleName == null || MiddleName.Trim() == "" || MiddleName.Trim().Length > 15)
            {
                return false;
            }

            if (LastName == null || LastName.Trim() == null || LastName.Trim().Length > 15)
            {
                return false;
            }

            if (DOB > DateTime.Now.AddYears(-19))
            {
                return false;
            }

            if (Gender == null || Gender.Trim() == "" || Gender.Trim().Length > 10)
            {
                return false;
            }

            if (Address == null || Address.Trim() == "" || Address.Trim().Length > 20)
            {
                return false;
            }

            if (City == null || City.Trim() == "" || City.Trim().Length > 20)
            {
                return false;
            }

            if (State == null || State.Trim() == "" || State.Trim().Length > 20)
            {
                return false;
            }

            if (Pincode == null || Pincode.Trim() == "" || Pincode.Trim().Length > 6)
            {
                return false;
            }

            if (EmailId == null || EmailId.Trim() == "" || EmailId.Trim().Length <=8 )
            {
                return false;
            }

            if (MobileNumber == null || MobileNumber.Trim() == string.Empty || MobileNumber.Length > 10)
            {
                return false;
            }

            if (Occupation == null || Occupation.Trim() == string.Empty || Occupation.Length > 15)
            {
                return false;
            }


            //if (UserId == null || UserId.Trim() == string.Empty || UserId.Length > 15)
            //{
            //    return false;
            //}

            //if (Password == null || Password.Trim() == string.Empty || Password.Length > 15)
            //{
            //    return false;
            //}

            return true;
        }

    }
}
