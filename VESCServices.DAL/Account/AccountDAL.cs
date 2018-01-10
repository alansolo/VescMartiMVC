using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace VESCServices.DAL.Account
{
    public class AccountDAL : DB
    {
        /// <summary>
        /// Realiza la autenticacion de usuario        
        /// </summary>
        /// <param name="usuario">correo</param>
        /// <param name="contrasena">contraseña</param>
        /// <returns>si la autenticacion es correcta regresa el id del usuario, si la autenticacion es incorrecta regresa cero </returns>
        public int Login(string usuario, string contrasena)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@usuario", Value = usuario });
            listaParametros.Add(new SqlParameter { ParameterName = "@contrasena", Value = contrasena });
            return int.Parse(base.ExecuteScalar("sp_login", listaParametros));
        }
        /// <summary>
        /// Obtiene el numero de sesiones activas de un usuario
        /// </summary>
        /// <param name="idUsuario">Id de usuario</param>
        /// <returns>Numero de sesiones activas</returns>
        public int SesionesActivas(int idUsuario)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@idUsuario", Value = idUsuario.ToString(), DbType = System.Data.DbType.String });            
            return int.Parse(base.ExecuteScalar("sp_sesionUnica", listaParametros));
        }
        /// <summary>
        /// Crea sesion para un idUsuario y registra la IP desde donde esta iniciando sesion
        /// </summary>
        /// <param name="idUsuario">Id Usuario</param>
        /// <param name="ip">Ip</param>
        /// <returns>Token de sesion</returns>
        public Guid CrearSesion(int idUsuario, string ip)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@idUsuario", Value = idUsuario });
            listaParametros.Add(new SqlParameter { ParameterName = "@ip", Value = ip });
            return Guid.Parse(base.ExecuteScalar("sp_crearSesion", listaParametros)); 
        }
        /// <summary>
        /// Cierra sesion
        /// </summary>
        /// <param name="token">Token de sesion</param>
        /// <returns></returns>
        public int CerrarSesion(Guid token)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@token", Value = token });            
            return base.ExecuteNonQuery("sp_cerrarSesion", listaParametros);
        }
    }
}
