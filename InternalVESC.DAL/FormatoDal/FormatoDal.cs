using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class FormatoDal:DB
    {
        public FormatoDal()
        {
        }
        public FormatoDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetFormato(int idFormato, string formato)
        {
            const string spName = "GetFormato";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idFormato != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idFormato";
                parametro.Value = idFormato;
                listaParametros.Add(parametro);
            }

            if (formato != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@formato";
                parametro.Value = formato;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }

        public int EditFormato(int idFormato, string formato, string descripcion, decimal mensualidad,
                   string usuarioUpdate)
        {
            const string spName = "UpdateFormato";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idFormato != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idFormato";
                    parametro.Value = idFormato;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@formato";
                    parametro.Value = formato;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@descripcion";
                    parametro.Value = descripcion;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@mensualidad";
                    parametro.Value = mensualidad;
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
        public int AddFormato(string formato, string descripcion, decimal mensualidad,
                    string usuarioInsert)
        {
            const string spName = "InsertFormato";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@formato";
            parametro.Value = formato;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@descripcion";
            parametro.Value = descripcion;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@mensualidad";
            parametro.Value = mensualidad;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@usuarioInsert";
            parametro.Value = usuarioInsert;
            listaParametros.Add(parametro);

            return base.ExecuteNonQuery(spName, listaParametros);
        }
    }
}
