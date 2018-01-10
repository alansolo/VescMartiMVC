using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VESCServices.DAL.Seguridad
{
    public class SeguridadDAL : DB
    {
        /// <summary>
        /// Verifica si una sesion esta activa, y que la sesion y la IP coincida con la proporcionada inicialmente
        /// </summary>
        /// <param name="token">Token de sesion</param>
        /// <param name="ip">IP</param>
        /// <returns>Si la sesion es valida, regresa el id del usuario al que pertenece la sesion, si no es valida regresa cero</returns>
        public int ValidarSesionActiva(Guid token, string ip)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@token", Value = token });
            listaParametros.Add(new SqlParameter { ParameterName = "@ip", Value = ip });
            return int.Parse(base.ExecuteScalar("sp_validarSesionActiva", listaParametros));
        }

    }
}
