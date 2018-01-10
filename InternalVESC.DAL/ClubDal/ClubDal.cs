using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class ClubDal:DB
    {
        public ClubDal()
        {
        }
        public ClubDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetClub(int idClub, string club)
        {
            const string spName = "GetClub";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idClub != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idClub";
                parametro.Value = idClub;
                listaParametros.Add(parametro);
            }

            if (club != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@club";
                parametro.Value = club;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }
        public int EditClub(int idClub, string club, string descripcion,
                   string usuarioUpdate)
        {
            const string spName = "UpdateClub";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idClub != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idClub";
                    parametro.Value = idClub;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@club";
                    parametro.Value = club;
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
        public int AddClub(string club, string descripcion,
                    string usuarioInsert)
        {
            const string spName = "InsertClub";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@club";
            parametro.Value = club;
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
