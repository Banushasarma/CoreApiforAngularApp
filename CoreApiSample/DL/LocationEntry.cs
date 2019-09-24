using CoreApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiSample.DL
{
    public class LocationEntry
    {
        public List<Location> Select()
        {
            return new DBConnectivity().ExecuteSelectQuery<Location>("SELECT * FROM Location").ToList();
        }
    }
}
