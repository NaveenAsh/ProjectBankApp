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
    public class AccountsDataAccess
    {

        public string ErrorMessage { get; set; }

        //Get all Employee
        public List<AccountsDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<AccountsDataModel> details = new List<AccountsDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select Id, CustomerId, BranchId, AccountNo, AccountType, ACD, CustomerBalance, AccountStatus from dbo.AccountsTable";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                AccountsDataModel account = new AccountsDataModel();
                                account.Id = reader.GetInt32(0);
                                account.CustomerId = reader.GetInt32(1);
                                account.BranchId = reader.GetInt32(2);
                                account.AccountNo = reader.GetString(3);
                                account.AccountType = reader.GetString(4);
                                account.ACD = reader.GetDateTime(5);
                                account.CurrentBalance = reader.GetDecimal(6);
                                account.AccountStatus = reader.GetString(7);

                                //customer.UserId = reader.GetString(12);
                                //customer.Password = reader.GetString(13);
                                details.Add(account);
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
        public AccountsDataModel GetById(int id)
        {
            try
            {
                AccountsDataModel account = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, CustomerId, BranchId, AccountNo, AccountType, ACD, CurrentBalance, AccountStatus from dbo.AccountsTable where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                account = new AccountsDataModel();
                                account.Id = reader.GetInt32(0);
                                account.CustomerId = reader.GetInt32(1);
                                account.BranchId = reader.GetInt32(2);
                                account.AccountNo = reader.GetString(3);
                                account.AccountType = reader.GetString(4);
                                account.ACD = reader.GetDateTime(5);
                                account.CurrentBalance = reader.GetDecimal(6);
                                account.AccountStatus = reader.GetString(7);


                            }
                        }
                    }
                }

                return account;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public AccountsDataModel GetByCustomerId(int id)
        {
            try
            {
                AccountsDataModel account = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select * from dbo.AccountsTable where CustomerId = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                account = new AccountsDataModel();
                                account.Id = reader.GetInt32(0);
                                account.CustomerId = reader.GetInt32(1);
                                account.BranchId = reader.GetInt32(2);
                                account.AccountNo = reader.GetString(3);
                                account.AccountType = reader.GetString(4);
                                account.ACD = reader.GetDateTime(5);
                                account.CurrentBalance = reader.GetDecimal(6);
                                account.AccountStatus = reader.GetString(7);

                            }
                        }
                    }
                }

                return account;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        public AccountsDataModel GetAccountById(int id)
        {
            try
            {
                AccountsDataModel account = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select * from dbo.AccountsTable where CustomerId = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                account = new AccountsDataModel();
                                account.Id = reader.GetInt32(0);
                                account.CustomerId = reader.GetInt32(1);
                                account.BranchId = reader.GetInt32(2);
                                account.AccountNo = reader.GetString(3);
                                account.AccountType = reader.GetString(4);
                                account.ACD = reader.GetDateTime(5);
                                account.CurrentBalance = reader.GetDecimal(6);
                                account.AccountStatus = reader.GetString(7);


                            }
                        }
                        //accNo.AccountNo = Convert.ToString(cmd.ExecuteScalar());
                        //return accNo;
                    }
                    //using (SqlDataReader reader = cmd.ExecuteReader())
                    //{
                    //    if (reader.Read() == true)
                    //    {

                    //        account = new AccountsDataModel();
                    //        account.AccountNo = reader.GetString(0);
                    //        //account.AccountType = reader.GetString(1);


                    //    }
                    //}
                }
                return account;

            }

            //return account;

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }

        }   
    

        public List<AccountsDataModel> GetByName(string accNo, string accStatus, string lastName, string accType)
        {
            try
            {
                List<AccountsDataModel> details = new List<AccountsDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, CustomerId, BranchId, AccountNo, AccountType, ACD, CustomerBalance, AccountStatus from dbo.AccountsTable" +
                        $" where AccountNo like '%{accNo}%' OR LastName like '%{lastName}%' OR AccountStatus like '%{accStatus}%' OR AccountType like '%{accType}%' ";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                AccountsDataModel account = new AccountsDataModel();
                                account.Id = reader.GetInt32(0);
                                account.CustomerId = reader.GetInt32(1);
                                account.BranchId = reader.GetInt32(2);
                                account.AccountNo = reader.GetString(3);
                                account.AccountType = reader.GetString(4);
                                account.ACD = reader.GetDateTime(5);
                                account.CurrentBalance = reader.GetDecimal(6);
                                account.AccountStatus = reader.GetString(7);


                                details.Add(account);
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
        //Insert new Employee
        public AccountsDataModel Insert(AccountsDataModel newAccount)

        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Helpers.Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.AccountsTable (CustomerId, BranchId, AccountNo, AccountType, ACD, CurrentBalance, AccountStatus ) VALUES ({newAccount.CustomerId}, {newAccount.BranchId}, '{newAccount.AccountNo}' , '{newAccount.AccountType}' , '{newAccount.ACD.ToString("yyyy-MM-dd")}' , {newAccount.CurrentBalance}, '{newAccount.AccountStatus}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newAccount.Id = idInserted;
                            return newAccount;
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
        public AccountsDataModel Update(AccountsDataModel updAccount)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.AccountsTable SET CustomerId = {updAccount.CustomerId}, " +
                        $"BranchId = {updAccount.BranchId}," +
                        $"AccountNo = '{updAccount.AccountNo}'," +
                        $"Accountype = '{updAccount.AccountType}'," +
                        $"ACD = '{updAccount.ACD.ToString("yyyy-MM-dd")}'," +
                        $"CurrentBalance = {updAccount.CurrentBalance}," +
                        $"AccountStatus = '{updAccount.AccountStatus}'," +
                     


                        $"where Id = {updAccount.Id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updAccount;
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

        public AccountsDataModel AccountUpdate(AccountsDataModel updAccount)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.AccountsTable SET CustomerId = {updAccount.CustomerId}, " +
                                     $"AccountType = '{updAccount.AccountType}'," +                      
                                     $"AccountStatus = '{updAccount.AccountStatus}'" +
                                    $"where CustomerId = {updAccount.CustomerId}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return updAccount;
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
        public bool UpdateBalance(decimal currentBal, int userId)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Update AccountsTable Set CurrentBalance = {currentBal} where CustomerId = {userId}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return false;
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
                    string sqlStmt = $"DELETE FROM dbo.AccountsTable Where Id = {id}";

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



