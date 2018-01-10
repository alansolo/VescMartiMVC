using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VescDAL
{
    public class LoginEmpresaDal : DB
    {
        public LoginEmpresaDal()
        {
        }
        public LoginEmpresaDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetLoginEmpresa(int idLogin, int idEmpresa)
        {
            const string spName = "GetLoginEmpresa";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idLogin != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idLogin";
                parametro.Value = idLogin;
                listaParametros.Add(parametro);
            }

            if (idEmpresa != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idEmpresa";
                parametro.Value = idEmpresa;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }

       
    }
}
