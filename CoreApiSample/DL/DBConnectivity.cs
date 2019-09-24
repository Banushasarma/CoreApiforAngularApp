using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace CoreApiSample.DL
{
    public class DBConnectivity
    {
        SqlConnection sqlConnection;
        public DBConnectivity()
        {
            sqlConnection = new SqlConnection(Startup.ConecctionString);
        }

        public List<T> ExecuteSelectSP<T>(string SPName) 
        {
            return sqlConnection.Query<T>(SPName, null, null, false, null, CommandType.StoredProcedure).ToList();
        }

        public List<T> ExecuteSelectSP<T>(string SPName, DynamicParameters dynamicParameters)
        {
            return sqlConnection.Query<T>(SPName, dynamicParameters, null, false, null, CommandType.StoredProcedure).ToList();
        }

        public T ExecuteSelectSingleSP<T>(string SPName)
        {
            return sqlConnection.Query<T>(SPName, null, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public T ExecuteSelectSingleSP<T>(string SPName, DynamicParameters dynamicParameters)
        {
            return sqlConnection.Query<T>(SPName, dynamicParameters, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        } 

        public Int32 ExecuteSP(string SPName)
        {
            return sqlConnection.Execute(SPName, null, null, null, CommandType.StoredProcedure);
        }

        public Int32 ExecuteSP(string SPName, DynamicParameters dynamicParameters)
        {
            return sqlConnection.Execute(SPName, dynamicParameters, null, null, CommandType.StoredProcedure);
        }

        public List<T> ExecuteSelectQuery<T>(string sqlQuery)
        {
            return sqlConnection.Query<T>(sqlQuery, null, null, false, null, CommandType.Text).ToList();
        }

        public List<T> ExecuteSelectQuery<T>(string sqlQuery, DynamicParameters dynamicParameters)
        {
            return sqlConnection.Query<T>(sqlQuery, dynamicParameters, null, false, null, CommandType.Text).ToList();
        }


        public T ExecuteSelectSingleQuery<T>(string sqlQuery)
        {
            return sqlConnection.Query<T>(sqlQuery, null, null, false, null, CommandType.Text).FirstOrDefault();
        }

        public T ExecuteSelectSingleQuery<T>(string sqlQuery, DynamicParameters dynamicParameters)
        {
            return sqlConnection.Query<T>(sqlQuery, dynamicParameters, null, false, null, CommandType.Text).FirstOrDefault();
        }

        public int ExecuteQuery(string sqlQuery)
        {
            return sqlConnection.Execute(sqlQuery, null, null, null, CommandType.Text);
        }
    }
}
