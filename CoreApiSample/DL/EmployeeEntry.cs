using CoreApiSample.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiSample.DL
{
    public class EmployeeEntry
    {
        public List<Employee> GetEmployees()
        {
            return new DBConnectivity().ExecuteSelectSP<Employee>("Employee_M_Select");
        }

        public void Delete(int id)
        {
            new DBConnectivity().ExecuteQuery(String.Format("DELETE FROM Employee WHERE Id = {0}", id));
        }

        public void Save(Employee employee)
        {
            DynamicParameters dynamincParameter = new DynamicParameters();
            dynamincParameter.Add("@Id", employee.Id, DbType.Int32, ParameterDirection.Input);
            dynamincParameter.Add("@Name", employee.Name, DbType.String, ParameterDirection.Input);
            dynamincParameter.Add("@LocationId", employee.LocationId, DbType.Int32, ParameterDirection.Input);
            dynamincParameter.Add("@DesignationId", employee.LocationId, DbType.Int32, ParameterDirection.Input);
            dynamincParameter.Add("@Age", employee.Age, DbType.Int32, ParameterDirection.Input);
            dynamincParameter.Add("@DOB", employee.DOB, DbType.DateTime, ParameterDirection.Input); 

            new DBConnectivity().ExecuteSP("Employee_M_Save", dynamincParameter);
        }
    }
}
