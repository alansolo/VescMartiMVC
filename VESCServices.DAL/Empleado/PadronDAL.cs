using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VESCServices.ENT.Entities;

namespace VESCServices.DAL.Empleado
{
    public class PadronDAL : DB
    {
        /// <summary>
        /// Consulta Padron
        /// </summary>
        /// <param name="idEmpresa">Id empresa</param>
        /// <returns>Lista de padron</returns>
        public List<PadronDTO> ObtenerPadron(int idEmpresa)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpresa", Value = idEmpresa });
            SqlDataReader reader = base.ExecuteReader("sp_consultaPadron", listaParametros);
            List<PadronDTO> result = new List<PadronDTO>();
            while (reader.Read())
            {
                result.Add(new PadronDTO
                {
                    Club = reader["club"].ToString(),
                    Empleado = reader["nombre"].ToString(),
                    EmpleadoId = int.Parse(reader["idEmpleado"].ToString()),
                    ESI = decimal.Parse(reader["EmpleadoSinIva"].ToString()),
                    Estatus = bool.Parse(reader["Estatus"].ToString()),
                    EstatusDescripcion = reader["EstatusDescripcion"].ToString(),
                    ET = decimal.Parse(reader["Empleado"].ToString()),
                    IC = decimal.Parse(reader["IvaCnia"].ToString()),
                    ICSI = decimal.Parse(reader["ImporteCniaSinIva"].ToString()),
                    IE = decimal.Parse(reader["IvaEmpleado"].ToString()),
                    IR = decimal.Parse(reader["RetencionIva"].ToString()),
                    ITC = decimal.Parse(reader["ImporteCnia"].ToString()),
                    plan = reader["plan"].ToString(),
                    RazonSocial = reader["razonSocial"].ToString(),
                    RSI = decimal.Parse(reader["RetencionSIva"].ToString()),
                    RT = decimal.Parse(reader["Retencion"].ToString()),
                    Total = decimal.Parse(reader["Total"].ToString())
                });
            }
            return result;
        }
    }
}
