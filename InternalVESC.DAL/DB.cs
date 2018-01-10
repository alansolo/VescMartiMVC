using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VescDAL
{
    public class DB
    {
        private SqlConnection sqlConnection;
        private SqlCommand command;
        protected string connectionString;

        public DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["VESC"].ToString();
        }
        public DB(string dataBaseConnection)
        {
            connectionString = ConfigurationManager.ConnectionStrings[dataBaseConnection].ToString();
        }
        protected string ExecuteScalar(string spName, List<SqlParameter> parameters)
        {
            string result = string.Empty;

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (SqlParameter item in parameters)
                        command.Parameters.Add(item);

                    command.Connection = sqlConnection;
                    sqlConnection.Open();
                    result = (string)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    //TODO: Implementar excepcion, escribir en log error!
                }
            }

            return result;
        }
        protected int ExecuteNonQuery(string spName, List<SqlParameter> parameters)
        {
            int result = 0;

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (SqlParameter item in parameters)
                        command.Parameters.Add(item);

                    command.Connection = sqlConnection;
                    sqlConnection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //TODO: Implementar excepcion, escribir en log error!
                    throw ex;
                }
            }

            return result;
        }
        //public SqlDataReader ExecuteReader(string spName, SqlParameter[] parameters)
        //{
        //    SqlDataReader reader;
        //    try
        //    {
        //        sqlConnection = new SqlConnection(connectionString);
        //        command = new SqlCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = spName;
        //        foreach (SqlParameter item in parameters)
        //            command.Parameters.Add(item);

        //        command.Connection = sqlConnection;
        //        sqlConnection.Open();
        //        reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        //reader.
                
        //        var uno = reader;
        //    }
        //    catch (Exception ex)
        //    {
        //        reader = null;
        //        if (sqlConnection.State != ConnectionState.Closed)
        //            sqlConnection.Close();
        //        //TODO: Implementar excepcion, escribir en log error!
        //    }
        //    return reader;
        //}
        protected DataTable ExecuteDataTable(string spName, List<SqlParameter> parameters)
        {
            DataSet dataSet = null;
            DataTable dataTable = new DataTable();

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (SqlParameter item in parameters)
                        command.Parameters.Add(item);

                    command.Connection = sqlConnection;
                    sqlConnection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataSet = new DataSet("dsResult");
                    dataAdapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        dataTable = dataSet.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Implementar excepcion, escribir en log error!
                }
            }

            return dataTable;
        }
        protected DataSet ExecuteDataSet(string spName, List<SqlParameter> parameters)
        {
            DataSet dataSet = null;

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = spName;
                    foreach (SqlParameter item in parameters)
                        command.Parameters.Add(item);

                    command.Connection = sqlConnection;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataSet = new DataSet("dsResult");
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    //TODO: Implementar excepcion, escribir en log error!
                }
            }

            return dataSet;
        }
       
    }
}
