using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class RazonSocialDal:DB
    {
        public RazonSocialDal()
        {
        }
        public RazonSocialDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetRazonSocial(int idRazonSocial, string razonSocial)
        {
            const string spName = "GetRazonSocial";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idRazonSocial != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idRazonSocial";
                parametro.Value = idRazonSocial;
                listaParametros.Add(parametro);
            }

            if (razonSocial != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@razonSocial";
                parametro.Value = razonSocial;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }
    }
}
