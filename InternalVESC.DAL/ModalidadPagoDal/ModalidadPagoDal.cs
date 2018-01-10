using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class ModalidadPagoDal:DB
    {
        public ModalidadPagoDal()
        {
        }
        public ModalidadPagoDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetModalidadPago(int idModalidadPago, string modalidadPago)
        {
            const string spName = "GetModalidadPago";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idModalidadPago != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idModalidadPago";
                parametro.Value = idModalidadPago;
                listaParametros.Add(parametro);
            }

            if (modalidadPago != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@modalidadPago";
                parametro.Value = modalidadPago;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }
        public int EditModalidadPago(int idModalidadPago, string modalidadPago, string descripcion,
           string usuarioUpdate)
        {
            const string spName = "UpdateModalidadPago";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idModalidadPago != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idModalidadPago";
                    parametro.Value = idModalidadPago;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@modalidadPago";
                    parametro.Value = modalidadPago;
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
        public int AddModalidadPago(string modalidadPago, string descripcion,
                    string usuarioInsert)
        {
            const string spName = "InsertModalidadPago";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@modalidadPago";
            parametro.Value = modalidadPago;
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
