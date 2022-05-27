using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBankApp.Models
{
    public class BranchDataModel
    {
        public int Id { get; set; }

        public string BranchIFSC { get; set; }

        public string BranchName { get; set; }

        public string BranchCity { get; set; }

        //Constructor
        public BranchDataModel()
        {
            Id = -1;
            BranchIFSC = "";
            BranchName = "";
            BranchCity = "";
        }

     
    }
}
