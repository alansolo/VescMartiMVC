using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VescDAL
{
    public class AccountDal : DB
    {
        public void Login(string User, string password)
        {

            List<SqlParameter> parametersList = new List<SqlParameter>();
            parametersList.Add(new SqlParameter {ParameterName = "@User" ,DbType = DbType.String, Value= User });
            parametersList.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            this.ExecuteNonQuery("sp_login", parametersList);
        }

    }
}
