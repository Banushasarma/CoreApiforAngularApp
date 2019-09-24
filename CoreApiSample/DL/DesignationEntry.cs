using CoreApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiSample.DL
{
    public class DesignationEntry
    {
        public List<Designation> Select()
        {
            return new DBConnectivity().ExecuteSelectQuery<Designation>("SELECT * FROM Designation").ToList();
        }
    }
}
