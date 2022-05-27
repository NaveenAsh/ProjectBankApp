using System.Data.SqlClient;
using ProjectBankApp.Helpers;
using ProjectBankApp.Models;

namespace ProjectBankApp.DataAccess
{
    public class AdminDashBoardDataAccess
    {
        public string ErrorMessage { get; set; }
            public AdminDashBoardDataModel GetAll()
            {
                try
                {

                    ErrorMessage = String.Empty;
                    ErrorMessage = "";
                    var d = new AdminDashBoardDataModel();
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        var sqlStmt = "select count(*) as CustomerCount from CustomerTable";
                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            d.CustomerCount = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                      
                        sqlStmt = "select count(*) as ActiveUsers from AccountCount where AccountStatus = 'A' ";
                        using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                        {
                            d.ActiveUsersCount = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                    }

                    return d;


                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                    return null;
                }

            }

        }
    }


