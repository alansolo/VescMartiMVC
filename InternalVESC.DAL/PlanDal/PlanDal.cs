using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VescDAL
{
    public class PlanDal: DB
    {
        public PlanDal()
        {
        }
        public PlanDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetPlan(int idPlan, string plan)
        {
            const string spName = "GetPlan";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idPlan != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idPlan";
                parametro.Value = idPlan;
                listaParametros.Add(parametro);
            }

            if (plan != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@plan";
                parametro.Value = plan;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }
        public int EditPlan(int idPlan, string plan, string descripcion, int idModalidadPago,
                    string usuarioUpdate)
        {
            const string spName = "UpdatePlan";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idPlan != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idPlan";
                    parametro.Value = idPlan;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@plan";
                    parametro.Value = plan;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@descripcion";
                    parametro.Value = descripcion;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idModalidadPago";
                    parametro.Value = idModalidadPago;
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
        public int AddPlan(string plan, string descripcion, int idModalidadPago,
                    string usuarioInsert)
        {
            const string spName = "InsertPlan";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@plan";
            parametro.Value = plan;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@descripcion";
            parametro.Value = descripcion;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@idModalidadPago";
            parametro.Value = idModalidadPago;
            listaParametros.Add(parametro); 

            parametro = new SqlParameter();
            parametro.ParameterName = "@usuarioInsert";
            parametro.Value = usuarioInsert;
            listaParametros.Add(parametro);

            return base.ExecuteNonQuery(spName, listaParametros);
        }
    }
}
