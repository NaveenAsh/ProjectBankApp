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
    public class TransactionsDataAccess
    {

        public string ErrorMessage { get; set; }

        //Get all Employee
        public List<TransactionsDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<TransactionsDataModel> details = new List<TransactionsDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select * from dbo.TransactionTable";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TransactionsDataModel transaction = new TransactionsDataModel();
                                transaction.Id = reader.GetInt32(0);
                                transaction.AccountId = reader.GetInt32(1);
                                transaction.DOT = reader.GetDateTime(2);
                                transaction.TransactonType = reader.GetString(3);
                                transaction.Amount = reader.GetDecimal(4);
                                transaction.OpeningBalance = reader.GetDecimal(5);
                                transaction.ClosingBalance = reader.GetDecimal(6);
                                transaction.Remarks = reader.GetString(7);

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

        //Get Employee By Id
        public TransactionsDataModel GetById(int id)
        {
            try
            {
                TransactionsDataModel transaction = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, AccountId, DOT, TransactionType, Amount, OpeningBalance, ClosingBalance, Remarks from dbo.TransacionTable where Id = {id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() == true)
                            {

                                transaction = new TransactionsDataModel();
                                transaction.Id = reader.GetInt32(0);
                                transaction.AccountId = reader.GetInt32(1);
                                transaction.DOT = reader.GetDateTime(2);
                                transaction.TransactonType = reader.GetString(3);
                                transaction.Amount = reader.GetDecimal(4);
                                transaction.OpeningBalance = reader.GetDecimal(5);
                                transaction.ClosingBalance = reader.GetDecimal(6);
                                transaction.Remarks = reader.GetString(7);



                            }
                        }
                    }
                }

                return transaction;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }

        public List<TransactionsDataModel> GetByName(string accId, string transtype)
        {
            try
            {
                List<TransactionsDataModel> details = new List<TransactionsDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"Select Id, AccountId, DOT, TransactionType, Amount, OpeningBalance, ClosingBalance, Remarks from dbo.TransacionTable" +
                        $" where AccountId like '%{accId}%' OR TransactionType like '%{transtype}%'";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                TransactionsDataModel transaction = new TransactionsDataModel();
                                transaction.Id = reader.GetInt32(0);
                                transaction.AccountId = reader.GetInt32(1);
                                transaction.DOT = reader.GetDateTime(2);
                                transaction.TransactonType = reader.GetString(3);
                                transaction.Amount = reader.GetDecimal(4);                        
                                transaction.OpeningBalance = reader.GetDecimal(5);
                                transaction.ClosingBalance = reader.GetDecimal(6);
                                transaction.Remarks = reader.GetString(7);




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
        //Insert new Employee
        public TransactionsDataModel Insert(TransactionsDataModel newTransaction)

        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = String.Empty;
                using (SqlConnection conn = Helpers.Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.TransactionTable (AccountId, DOT, TransactionType, Amount, OpeningBalance, ClosingBalance, Remarks) VALUES ({newTransaction.AccountId}, '{newTransaction.DOT.ToString("yyyy-MM-dd")}', '{newTransaction.TransactonType}', {newTransaction.Amount} , {newTransaction.OpeningBalance}, {newTransaction.ClosingBalance}, '{newTransaction.Remarks}'); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            newTransaction.Id = idInserted;
                            return newTransaction;
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
        //public AccountsDataModel Update(AccountsDataModel updAccount)
        //{
        //    try
        //    {
        //        ErrorMessage = "";
        //        using (SqlConnection conn = Database.GetConnection())
        //        {
        //            conn.Open();
        //            string sqlStmt = $"UPDATE dbo.AccountsTable SET CustomerId = {updAccount.CustomerId}, " +
        //                $"BranchId = {updAccount.BranchId}," +
        //                $"AccountNo = '{updAccount.AccountNo}'," +
        //                $"Accountype = '{updAccount.AccountType}'," +
        //                $"ACD = '{updAccount.ACD.ToString("yyyy-MM-dd")}'," +
        //                $"CurrentBalance = '{updAccount.CurrentBalance}'," +
        //                $"AccountStatus = '{updAccount.AccountStatus}'," +
        //               transaction.Remarks = reader.GetString(7);




        //            $"where Id = {updAccount.Id}";

        //            using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
        //            {
        //                int numOfRows = cmd.ExecuteNonQuery();
        //                if (numOfRows > 0)
        //                {
        //                    return updAccount;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = ex.Message;
        //    }
        //    return null;
        //}

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
                    string sqlStmt = $"DELETE FROM dbo.TransactionTable Where Id = {id}";

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



