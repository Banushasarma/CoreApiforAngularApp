using CoreApiSample.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiSample.DL
{
    public class LoginEntry
    {
        public List<Login> GetLogin(string UserName, string Password)
        {
            DynamicParameters dynamincParameter = new DynamicParameters();
            dynamincParameter.Add("@UserName", UserName, DbType.String, ParameterDirection.Input);
            dynamincParameter.Add("@Password", Password, DbType.String, ParameterDirection.Input);

            return new DBConnectivity().ExecuteSelectSP<Login>("Login_M_Select", dynamincParameter);
        }
    }
}
