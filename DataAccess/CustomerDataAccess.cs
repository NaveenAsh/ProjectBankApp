using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBankApp.Helpers;
using ProjectBankApp.Models;

namespace ProjectBankApp.DataAccess
{
    public class CustomerDataAccess
    {

        public string ErrorMessage { get; set; }

        //Get all Employee
        public List<CustomerDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<CustomerDataModel> details = new List<CustomerDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id, FirstName, MiddleName, LastName, DOB, Gender, Address, City, State, Pincode, EmailId, MobileNumber, Occupation from dbo.CustomerTable";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CustomerDataModel customer = new CustomerDataModel();
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.Address = reader.GetString(6);
                                customer.City = reader.GetString(7);
                                customer.State = reader.GetString(8);
                                customer.Pincode = reader.GetString(9);
                                customer.EmailId = reader.GetString(10);
                                customer.MobileNumber = reader.GetString(11);
                                customer.Occupation = reader.GetString(12);
                                //customer.UserId = reader.GetString(12);
                                //customer.Password = reader.GetString(13);
                                details.Add(customer);
                            }
                        }
                    }
                }

                return details;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        //Get Employee By Id
        public CustomerDataModel GetById(int id)
        {
            try
            {
                CustomerDataModel customer = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, FirstName, MiddleName, LastName, DOB, Gender, Address, City, State, Pincode, EmailId, MobileNumber, Occupation from dbo.CustomerTable where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                customer = new CustomerDataModel();
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.Address = reader.GetString(6);
                                customer.City = reader.GetString(7);
                                customer.State = reader.GetString(8);
                                customer.Pincode = reader.GetString(9);
                                customer.EmailId = reader.GetString(10);
                                customer.MobileNumber = reader.GetString(11);
                                customer.Occupation = reader.GetString(12);


                            }
                        }
                    }
                }

                return customer;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public List<CustomerDataModel> GetByName(string firstName, string middleName, string lastName, string mobileNumber)
        {
            try
            {
                List<CustomerDataModel> details = new List<CustomerDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, FirstName, MiddleName, LastName, DOB, Gender, Address, City, State, Pincode, EmailId, MobileNumber, Occupation from dbo.CustomerTable" +
                        $" where FirstName like '%{firstName}%' OR LastName like '%{lastName}%' OR MiddleName like '%{middleName}%' OR MoblieNumber like '%{mobileNumber}%' ";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                CustomerDataModel customer = new CustomerDataModel();
                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.Address = reader.GetString(6);
                                customer.City = reader.GetString(7);
                                customer.State = reader.GetString(8);
                                customer.Pincode = reader.GetString(9);
                                customer.EmailId = reader.GetString(10);
                                customer.MobileNumber = reader.GetString(11);
                                customer.Occupation = reader.GetString(12);
                                details.Add(customer);
                            }
                        }
                    }
                }

                return details;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        //public List<CustomerDataModel> GetByName(string firstName, string middleName, string lastName, string mobileNumber)
        //{
        //    try
        //    {
        //        List<CustomerDataModel> details = new List<CustomerDataModel>();
        //        using (SqlConnection conn = Database.GetConnection())
        //        {
        //            conn.Open();
        //            string sqlStmt = $"Select Id, FirstName, MiddleName, LastName, DOB, Gender, Address, City, State, Pincode, EmailId, MobileNumber, Occupation from dbo.CustomerTable" +
        //                $" where FirstName like '%{firstName}%' OR LastName like '%{lastName}%' OR MiddleName like '%{middleName}%' OR MoblieNumber like '%{mobileNumber}%' ";

        //            using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read() == true)
        //                    {
        //                        CustomerDataModel customer = new CustomerDataModel();
        //                        customer.Id = reader.GetInt32(0);
        //                        customer.FirstName = reader.GetString(1);
        //                        customer.MiddleName = reader.GetString(2);
        //                        customer.LastName = reader.GetString(3);
        //                        customer.DOB = reader.GetDateTime(4);
        //                        customer.Gender = reader.GetString(5);
        //                        customer.Address = reader.GetString(6);
        //                        customer.City = reader.GetString(7);
        //                        customer.State = reader.GetString(8);
        //                        customer.Pincode = reader.GetString(9);
        //                        customer.EmailId = reader.GetString(10);
        //                        customer.MobileNumber = reader.GetString(11);
        //                        customer.Occupation = reader.GetString(12);
        //                        details.Add(customer);
        //                    }
        //                }
        //            }
        //        }

        //        return details;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = ex.Message;
        //        return null;
        //    }
        //}


        public CustomerDataModel GetByUserId(string userId, string Password)
        {
            try
            {
                ErrorMessage = "";


                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select * from  customerTable where UserId = '{userId}' and Password= '{Password}'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CustomerDataModel customer = new CustomerDataModel();

                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.Address = reader.GetString(6);
                                customer.City = reader.GetString(7);
                                customer.State = reader.GetString(8);
                                customer.Pincode = reader.GetString(9);
                                customer.EmailId = reader.GetString(10);
                                customer.MobileNumber = reader.GetString(11);
                                customer.Occupation = reader.GetString(12);

                                return customer;



                            }
                        }
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

            //Insert new Employee
        public CustomerDataModel Insert(CustomerDataModel newCustomer)

            {
                try
                {
                    ErrorMessage = string.Empty;
                    ErrorMessage = String.Empty;
                    using (SqlConnection conn = Helpers.Database.GetConnection())
                    {
                        conn.Open();
                        string sqlStmt = $"INSERT INTO dbo.CustomerTable (FirstName, MiddleName, LastName, DOB, Gender, Address, City, State, Pincode, EmailId, MobileNumber, Occupation, UserId, Password ) VALUES ('{newCustomer.FirstName}', '{newCustomer.MiddleName}', '{newCustomer.LastName}' , '{newCustomer.DOB.ToString("yyyy-MM-dd")}', '{newCustomer.Gender}' ,'{newCustomer.Address}', '{newCustomer.City}', '{newCustomer.State}', '{newCustomer.Pincode}', '{newCustomer.EmailId}' , '{newCustomer.MobileNumber}','{newCustomer.Occupation}', '{newCustomer.UserId}', '{newCustomer.Password}' ); SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                            if (idInserted > 0)
                            {
                                newCustomer.Id = idInserted;
                                return newCustomer;
                            }
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return null;
                }
        }

            //Update Employee
        public CustomerDataModel Update(CustomerDataModel updCustomer)
            {
                try
                {
                    ErrorMessage = "";
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string sqlStmt = $"UPDATE dbo.CustomerTable SET FirstName = '{updCustomer.FirstName}', " +
                            $"MiddleName = '{updCustomer.MiddleName}'," +
                            $"LastName = '{updCustomer.LastName}'," +
                            $"DOB = '{updCustomer.DOB.ToString("yyyy-MM-dd")}'," +
                            $"Gender = '{updCustomer.Gender}'," +
                            $"Address = '{updCustomer.Address}'," +
                            $"City = '{updCustomer.City}'," +
                            $"State = '{updCustomer.State}'," +
                            $"Pincode = '{updCustomer.Pincode}'," +
                            $"EmailId = '{updCustomer.EmailId}'," +
                            $"MobileNumber = '{updCustomer.MobileNumber}'," +
                            $"Occupation = '{updCustomer.Occupation}'" +
                            $"where Id = {updCustomer.Id}";

                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            int numOfRows = cmd.ExecuteNonQuery();
                            if (numOfRows > 0)
                            {
                                return updCustomer;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                return null;
        }

            //Delete Employee
            public int Delete(int id)
            {
                try
                {
                    ErrorMessage = String.Empty;
                    int numOfRows = 0;

                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        string sqlStmt = $"DELETE FROM dbo.CustomerTable Where Id = {id}";

                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            numOfRows = cmd.ExecuteNonQuery();
                        }
                    }
                    return numOfRows;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
    }
}




