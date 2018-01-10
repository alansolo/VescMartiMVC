using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VescDAL
{
    public class EmpresaDal : DB
    {
        public EmpresaDal()
        {
        }
        public EmpresaDal(string dataBaseConnection):base(dataBaseConnection)
        {
        }
        public DataTable GetEmpresa(int idEmpresa, string empresa)
        {
            const string spName = "GetEmpresa";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            if (idEmpresa != 0)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@idEmpresa";
                parametro.Value = idEmpresa;
                listaParametros.Add(parametro);
            }

            if (empresa != null)
            {
                parametro = new SqlParameter();
                parametro.ParameterName = "@empresa";
                parametro.Value = empresa;
                listaParametros.Add(parametro);
            }

            return base.ExecuteDataTable(spName, listaParametros);
        }
        public int EditEmpresa(int idEmpresa, string empresa, string nombreContacto, string apellidoPContacto, string apellidoMContacto,
                    string puestoContacto, string telefonoContacto, string telefono2Contacto, string correoContacto, bool estatus,
                    string usuarioUpdate)
        {
            const string spName = "UpdateEmpresa";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();
            int resultado = 0;

            try
            {
                if (idEmpresa != 0)
                {
                    parametro = new SqlParameter();
                    parametro.ParameterName = "@idEmpresa";
                    parametro.Value = idEmpresa;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@empresa";
                    parametro.Value = empresa;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@nombreContacto";
                    parametro.Value = nombreContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@apellidoPContacto";
                    parametro.Value = apellidoPContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@apellidoMContacto";
                    parametro.Value = apellidoMContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@puestoContacto";
                    parametro.Value = puestoContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@telefonoContacto";
                    parametro.Value = telefonoContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@telefono2Contacto";
                    parametro.Value = telefono2Contacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@correoContacto";
                    parametro.Value = correoContacto;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@estatus";
                    parametro.Value = estatus;
                    listaParametros.Add(parametro);

                    parametro = new SqlParameter();
                    parametro.ParameterName = "@usuarioUpdate";
                    parametro.Value = usuarioUpdate;
                    listaParametros.Add(parametro);
                }

                resultado = base.ExecuteNonQuery(spName, listaParametros);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return resultado;
        }
        public int AddEmpresa(string empresa, string nombreContacto, string apellidoPContacto, string apellidoMContacto,
                   string puestoContacto, string telefonoContacto, string telefono2Contacto, string correoContacto, bool estatus,
                   int idLogin, string usuarioInsert)
        {
            const string spName = "InsertEmpresa";
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter();

            parametro = new SqlParameter();
            parametro.ParameterName = "@empresa";
            parametro.Value = empresa;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@nombreContacto";
            parametro.Value = nombreContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@apellidoPContacto";
            parametro.Value = apellidoPContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@apellidoMContacto";
            parametro.Value = apellidoMContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@puestoContacto";
            parametro.Value = puestoContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@telefonoContacto";
            parametro.Value = telefonoContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@telefono2Contacto";
            parametro.Value = telefono2Contacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@correoContacto";
            parametro.Value = correoContacto;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@estatus";
            parametro.Value = estatus;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@idLogin";
            parametro.Value = idLogin;
            listaParametros.Add(parametro);

            parametro = new SqlParameter();
            parametro.ParameterName = "@usuarioInsert";
            parametro.Value = usuarioInsert;
            listaParametros.Add(parametro);

            return base.ExecuteNonQuery(spName, listaParametros);
        }

       
    }
}
