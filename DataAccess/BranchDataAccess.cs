
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBankApp.Models;
using ProjectBankApp.Helpers;

namespace ProjectBankApp.DataAccess
{
    public class BranchDataAccess
    {
        public string ErrorMessage { get;  set; }

        public BranchDataAccess()
        {
            ErrorMessage = "";
        }

        //Get all Departments
        public List<BranchDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                ErrorMessage = "";

                List<BranchDataModel> departments = new List<BranchDataModel>();

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select * from dbo.BranchTable";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                BranchDataModel branch = new BranchDataModel();
                                branch.Id = reader.GetInt32(0);
                                branch.BranchIFSC = reader.GetString(1);
                                branch.BranchName = reader.GetString(2);
                                branch.BranchCity = reader.GetString(2);

                                departments.Add(branch);
                            }
                        }
                    }
                }

                return departments;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
    } 
}
     