using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class NivelDal:DB
    {
        public NivelDal()
        {
        }
        public NivelDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetNivel(int idNivel, string nivel)
        {
            const string spName = "GetNivel";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idNivel != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idNivel";
                parametro.Value = idNivel;
                listaParametros.Add(parametro);
            }

            if (nivel != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@nivel";
                parametro.Value = nivel;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }

        public int EditNivel(int idNivel, string nivel, string descripcion,
                   string usuarioUpdate)
        {
            const string spName = "UpdateNivel";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idNivel != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idNivel";
                    parametro.Value = idNivel;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@nivel";
                    parametro.Value = nivel;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@descripcion";
                    parametro.Value = descripcion;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@usuarioUpdate";
                    parametro.Value = usuarioUpdate;
                    listaParametros.Add(parametro);
                }

                resultado = base.ExecuteNonQuery(spName, listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        public int AddNivel(string nivel, string descripcion,
                    string usuarioInsert)
        {
            const string spName = "InsertNivel";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@nivel";
            parametro.Value = nivel;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@descripcion";
            parametro.Value = descripcion;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@usuarioInsert";
            parametro.Value = usuarioInsert;
            listaParametros.Add(parametro);

            return base.ExecuteNonQuery(spName, listaParametros);
        }
    }
}
