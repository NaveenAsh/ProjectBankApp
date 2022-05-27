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
    public class UserDetailsDataAccess
    {

        public string ErrorMessage { get; set; }

        //Get all Employee
        public List<UserProfileDataModel> GetAllUserProfile()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";
                List<UserProfileDataModel> details = new List<UserProfileDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "SELECT CT.Id as CustomerId, CT.FirstName, CT.MiddleName, CT.LastName, Ct.DOB, Ct.Gender, AT.AccountNo, AT.AccountType, AT.ACD, AT.CurrentBalance, Bt.BranchName, Bt.BranchIFSC, Bt.BranchCity, Ct.Address, Ct.City, Ct.State, ct.Pincode, Ct.EmailId, Ct.MobileNumber, ct.Occupation, AT.AccountStatus  FROM[dbo].[CustomerTable] AS CT  INNER JOIN[dbo].[AccountsTable] AS AT ON AT.CustomerId = CT.Id INNER JOIN[dbo].[BranchTable] AS BT ON BT.Id = AT.BranchId ORDER BY CT.Id";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                UserProfileDataModel customer = new UserProfileDataModel();
                                customer.Id = reader.GetInt32(0);
                                
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.AccountNo = reader.GetString(6);
                                customer.AccountType = reader.GetString(7);
                                customer.ACD = reader.GetDateTime(8);
                                customer.CurrentBalance = reader.GetDecimal(9);
                                customer.BranchName = reader.GetString(10);
                                customer.BranchIFSC = reader.GetString(11);
                                customer.BranchCity = reader.GetString(12);
                                customer.Address = reader.GetString(13);
                                customer.City = reader.GetString(14);
                                customer.State = reader.GetString(15);
                                customer.Pincode = reader.GetString(16);
                                customer.EmailId = reader.GetString(17);
                                customer.MobileNumber = reader.GetString(18);
                                customer.Occupation = reader.GetString(19);                              
                                customer.AccountStatus = reader.GetString(20);
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

        public List<UserProfileDataModel> GetUserProfileById(int id)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";
                List<UserProfileDataModel> details = new List<UserProfileDataModel>();

               

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"SELECT CT.Id as CustomerId, CT.FirstName, CT.MiddleName, CT.LastName, Ct.DOB, Ct.Gender, AT.AccountNo, AT.AccountType, AT.ACD, AT.CurrentBalance, Bt.BranchName, Bt.BranchIFSC, Bt.BranchCity, Ct.Address, Ct.City, Ct.State, ct.Pincode, Ct.EmailId, Ct.MobileNumber, ct.Occupation, AT.AccountStatus" +
                        $"  FROM[dbo].[CustomerTable] AS CT  INNER JOIN[dbo].[AccountsTable] AS AT ON AT.CustomerId = CT.Id INNER JOIN[dbo].[BranchTable] AS BT ON BT.Id = AT.BranchId where CT.Id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                UserProfileDataModel customer = new UserProfileDataModel();

                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.AccountNo = reader.GetString(6);
                                customer.AccountType = reader.GetString(7);
                                customer.ACD = reader.GetDateTime(8);
                                customer.CurrentBalance = reader.GetDecimal(9);
                                customer.BranchName = reader.GetString(10);
                                customer.BranchIFSC = reader.GetString(11);
                                customer.BranchCity = reader.GetString(12);
                                customer.Address = reader.GetString(13);
                                customer.City = reader.GetString(14);
                                customer.State = reader.GetString(15);
                                customer.Pincode = reader.GetString(16);
                                customer.EmailId = reader.GetString(17);
                                customer.MobileNumber = reader.GetString(18);
                                customer.Occupation = reader.GetString(19);
                                customer.AccountStatus = reader.GetString(20);
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


        public List<UserProfileDataModel> SearchByName(string name, string mobNo)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";
                List<UserProfileDataModel> details = new List<UserProfileDataModel>();



                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"SELECT CT.Id as CustomerId, CT.FirstName, CT.MiddleName, CT.LastName, Ct.DOB, Ct.Gender, AT.AccountNo, AT.AccountType, AT.ACD, AT.CurrentBalance," +
                        $" Bt.BranchName, Bt.BranchIFSC, Bt.BranchCity, Ct.Address, Ct.City, Ct.State, ct.Pincode, Ct.EmailId, Ct.MobileNumber, ct.Occupation, AT.AccountStatus" +
                        $"  FROM[dbo].[CustomerTable] AS CT  INNER JOIN[dbo].[AccountsTable] AS AT" +
                        $" ON AT.CustomerId = CT.Id INNER JOIN[dbo].[BranchTable] AS BT ON BT.Id = AT.BranchId where CT.FirstName like '%{name}%' OR CT.MobileNumber like '%{mobNo}%'";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {
                                UserProfileDataModel customer = new UserProfileDataModel();

                                customer.Id = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.MiddleName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                customer.DOB = reader.GetDateTime(4);
                                customer.Gender = reader.GetString(5);
                                customer.AccountNo = reader.GetString(6);
                                customer.AccountType = reader.GetString(7);
                                customer.ACD = reader.GetDateTime(8);
                                customer.CurrentBalance = reader.GetDecimal(9);
                                customer.BranchName = reader.GetString(10);
                                customer.BranchIFSC = reader.GetString(11);
                                customer.BranchCity = reader.GetString(12);
                                customer.Address = reader.GetString(13);
                                customer.City = reader.GetString(14);
                                customer.State = reader.GetString(15);
                                customer.Pincode = reader.GetString(16);
                                customer.EmailId = reader.GetString(17);
                                customer.MobileNumber = reader.GetString(18);
                                customer.Occupation = reader.GetString(19);
                                customer.AccountStatus = reader.GetString(20);
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



        public List<UserStatementDataModel> GetAllTransactions()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";
                List<UserStatementDataModel> details = new List<UserStatementDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"SELECT TT.Id as TransactionId, AT.AccountNo, CT.FirstName as AccountHolderName, AT.AccountType, TT.DOT, TT.TransactionType, TT.Amount, TT.OpeningBalance, TT.ClosingBalance, TT.Remarks FROM[dbo].[TransactionTable] AS TT" +
                                    $" INNER JOIN[dbo].[AccountsTable] AS AT ON AT.Id = TT.AccountId" +
                                    $" INNER JOIN [dbo].[CustomerTable] AS CT ON CT.Id = AT.CustomerId ORDER BY TT.Id DESC";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                UserStatementDataModel transaction = new UserStatementDataModel();
                                transaction.Id = reader.GetInt32(0);
                                transaction.AccountNo = reader.GetString(1);
                                transaction.AccountHolderName = reader.GetString(2);
                                transaction.AccountType = reader.GetString(3);
                                transaction.DOT = reader.GetDateTime(4);
                                transaction.TransactonType = reader.GetString(5);
                                transaction.Amount = reader.GetDecimal(6);
                                transaction.OpeningBalance = reader.GetDecimal(7);
                                transaction.ClosingBalance = reader.GetDecimal(8);
                                transaction.Remarks = reader.GetString(9);

                                details.Add(transaction);
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

        public List<UserStatementDataModel> GetAllTransactionsById(int id)
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";
                List<UserStatementDataModel> details = new List<UserStatementDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"SELECT TT.Id as TransactionId, AT.AccountNo, CT.FirstName as AccountHolderName, AT.AccountType, TT.DOT, TT.TransactionType, TT.Amount, TT.OpeningBalance, TT.ClosingBalance, TT.Remarks FROM[dbo].[TransactionTable] AS TT" +
                                    $" INNER JOIN[dbo].[AccountsTable] AS AT ON AT.Id = TT.AccountId" +
                                    $" INNER JOIN [dbo].[CustomerTable] AS CT ON CT.Id = AT.CustomerId where CT.Id = {id} ORDER BY TT.Id DESC";


                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                UserStatementDataModel transaction = new UserStatementDataModel();

                                transaction.Id = reader.GetInt32(0);
                                transaction.AccountNo = reader.GetString(1);
                                transaction.AccountHolderName = reader.GetString(2);
                                transaction.AccountType = reader.GetString(3);
                                transaction.DOT = reader.GetDateTime(4);
                                transaction.TransactonType = reader.GetString(5);
                                transaction.Amount = reader.GetDecimal(6);
                                transaction.OpeningBalance = reader.GetDecimal(7);
                                transaction.ClosingBalance = reader.GetDecimal(8);
                                transaction.Remarks = reader.GetString(9);
                                details.Add(transaction);
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


       
    }
}




