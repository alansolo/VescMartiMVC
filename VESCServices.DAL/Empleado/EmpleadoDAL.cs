using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VESCServices.ENT.Entities;

namespace VESCServices.DAL.Empleado
{
    public class EmpleadoDAL : DB
    {
        /// <summary>
        /// Alta de empleado
        /// </summary>
        /// <param name="empleado">Objeto de tranferencia de datos de empleado</param>
        /// <returns>true si se guardo correctamente, false caso contrario</returns>
        public bool AltaEmpleado(EmpleadoDTO empleado)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpresa", Value = empleado.idEmpresa });
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpresaInfFiscal", Value = empleado.idEmpresaInfFiscal });
            //listaParametros.Add(new SqlParameter { ParameterName = "@idEmpleado", Value = empleado.idEmpleado });
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpleadoPadre", Value = empleado.idEmpleadoPadre });
            listaParametros.Add(new SqlParameter { ParameterName = "@cusId", Value = empleado.cusId });
            listaParametros.Add(new SqlParameter { ParameterName = "@numEmpleado", Value = empleado.numEmpleado });
            listaParametros.Add(new SqlParameter { ParameterName = "@nombre", Value = empleado.nombre });
            listaParametros.Add(new SqlParameter { ParameterName = "@apellidoP", Value = empleado.apellidoP });
            listaParametros.Add(new SqlParameter { ParameterName = "@apellidoM", Value = empleado.apellidoM });
            listaParametros.Add(new SqlParameter { ParameterName = "@fechaNacimiento", Value = empleado.fechaNacimiento });
            listaParametros.Add(new SqlParameter { ParameterName = "@rfc", Value = empleado.rfc });
            listaParametros.Add(new SqlParameter { ParameterName = "@curp", Value = empleado.curp });
            listaParametros.Add(new SqlParameter { ParameterName = "@genero", Value = empleado.genero });
            listaParametros.Add(new SqlParameter { ParameterName = "@email", Value = empleado.email });
            listaParametros.Add(new SqlParameter { ParameterName = "@calle", Value = empleado.calle });
            listaParametros.Add(new SqlParameter { ParameterName = "@numExterior", Value = empleado.numExterior });
            listaParametros.Add(new SqlParameter { ParameterName = "@numInterior", Value = empleado.numExterior });
            listaParametros.Add(new SqlParameter { ParameterName = "@colonia", Value = empleado.colonia });
            listaParametros.Add(new SqlParameter { ParameterName = "@municipioDelegacion", Value = empleado.municipioDelegacion });
            listaParametros.Add(new SqlParameter { ParameterName = "@estado", Value = empleado.estado });
            listaParametros.Add(new SqlParameter { ParameterName = "@cp", Value = empleado.cp });
            listaParametros.Add(new SqlParameter { ParameterName = "@telefono", Value = empleado.telefono });
            if (empleado.telefono2 != null)
                listaParametros.Add(new SqlParameter { ParameterName = "@telefono2", Value = empleado.telefono2 });
            listaParametros.Add(new SqlParameter { ParameterName = "@idPlan", Value = empleado.idPlan });
            listaParametros.Add(new SqlParameter { ParameterName = "@idClub", Value = empleado.idClub });
            listaParametros.Add(new SqlParameter { ParameterName = "@idTipoPago", Value = empleado.idTipoPago });
            listaParametros.Add(new SqlParameter { ParameterName = "@estatus", Value = empleado.idTipoPago });
            listaParametros.Add(new SqlParameter { ParameterName = "@usuarioInsert", Value = empleado.usuarioInsert });
            return (base.ExecuteNonQuery("sp_altaEmpleado", listaParametros) > 0);

        }
        public bool EditEmpleado(EmpleadoDTO empleado)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpresa", Value = empleado.idEmpresa });
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpresaInfFiscal", Value = empleado.idEmpresaInfFiscal });
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpleado", Value = empleado.idEmpleado });
            listaParametros.Add(new SqlParameter { ParameterName = "@idEmpleadoPadre", Value = empleado.idEmpleadoPadre });
            listaParametros.Add(new SqlParameter { ParameterName = "@cusId", Value = empleado.cusId });
            listaParametros.Add(new SqlParameter { ParameterName = "@numEmpleado", Value = empleado.numEmpleado });
            listaParametros.Add(new SqlParameter { ParameterName = "@nombre", Value = empleado.nombre });
            listaParametros.Add(new SqlParameter { ParameterName = "@apellidoP", Value = empleado.apellidoP });
            listaParametros.Add(new SqlParameter { ParameterName = "@apellidoM", Value = empleado.apellidoM });
            listaParametros.Add(new SqlParameter { ParameterName = "@fechaNacimiento", Value = empleado.fechaNacimiento });
            listaParametros.Add(new SqlParameter { ParameterName = "@rfc", Value = empleado.rfc });
            listaParametros.Add(new SqlParameter { ParameterName = "@curp", Value = empleado.curp });
            listaParametros.Add(new SqlParameter { ParameterName = "@genero", Value = empleado.genero });
            listaParametros.Add(new SqlParameter { ParameterName = "@email", Value = empleado.email });
            listaParametros.Add(new SqlParameter { ParameterName = "@calle", Value = empleado.calle });
            listaParametros.Add(new SqlParameter { ParameterName = "@numExterior", Value = empleado.numExterior });
            listaParametros.Add(new SqlParameter { ParameterName = "@numInterior", Value = empleado.numInterior });
            listaParametros.Add(new SqlParameter { ParameterName = "@colonia", Value = empleado.colonia });
            listaParametros.Add(new SqlParameter { ParameterName = "@municipioDelegacion", Value = empleado.municipioDelegacion });
            listaParametros.Add(new SqlParameter { ParameterName = "@estado", Value = empleado.estado });
            listaParametros.Add(new SqlParameter { ParameterName = "@cp", Value = empleado.cp });
            listaParametros.Add(new SqlParameter { ParameterName = "@telefono", Value = empleado.telefono });
            if(empleado.telefono2 != null)
                listaParametros.Add(new SqlParameter { ParameterName = "@telefono2", Value = empleado.telefono2 });
            listaParametros.Add(new SqlParameter { ParameterName = "@idPlan", Value = empleado.idPlan });
            listaParametros.Add(new SqlParameter { ParameterName = "@idClub", Value = empleado.idClub });
            listaParametros.Add(new SqlParameter { ParameterName = "@idTipoPago", Value = empleado.idTipoPago });
            listaParametros.Add(new SqlParameter { ParameterName = "@estatus", Value = empleado.idTipoPago });
            listaParametros.Add(new SqlParameter { ParameterName = "@usuarioUpdate", Value = empleado.usuarioUpdate });
            return (base.ExecuteNonQuery("sp_editEmpleado", listaParametros) > 0);

        }
        /// <summary>
        /// Busca empleado
        /// </summary>
        /// <param name="filtro">Filtro de la busqueda</param>
        /// <returns>Lista de empleados</returns>
        public List<EmpleadoDTO> BuscarEmpleado(FiltroBusquedaEmpleadoDTO filtro)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();

            if (filtro.EmpresaId != null)
            {
                listaParametros.Add(new SqlParameter { ParameterName = "@EmpresaId", Value = filtro.EmpresaId });
            }
            if (filtro.RazonSocialId != null)
            {
                listaParametros.Add(new SqlParameter { ParameterName = "@RazonSocialId", Value = filtro.RazonSocialId });
            }
            if (filtro.EmpleadoID != null)
            {
                listaParametros.Add(new SqlParameter { ParameterName = "@EmpleadoID", Value = filtro.EmpleadoID });
            }
            if (filtro.EmpleadoPadreID != null || filtro.EmpleadoPadreID > 0)
            {
                listaParametros.Add(new SqlParameter { ParameterName = "@EmpleadoPadreID", Value = filtro.EmpleadoPadreID });
            }
            if (filtro.Estatus != null)
            {
                listaParametros.Add(new SqlParameter { ParameterName = "@Estatus", Value = filtro.Estatus });
            }

            DataTable dtBuscarEmpleado = new DataTable();
            dtBuscarEmpleado = base.ExecuteDataTable("sp_buscarEmpleado", listaParametros);

            List<EmpleadoDTO> result = new List<EmpleadoDTO>();

            result = dtBuscarEmpleado.AsEnumerable()
                .Select(row => new EmpleadoDTO
                {
                    idEmpresa = row.Field<int?>("idEmpresa").GetValueOrDefault(),
                    idEmpresaInfFiscal = row.Field<int?>("idEmpresaInfFiscal").GetValueOrDefault(),
                    idClub = row.Field<int?>("idClub").GetValueOrDefault(),
                    idPlan = row.Field<int?>("idPlan").GetValueOrDefault(),
                    idEmpleado = row.Field<long?>("idEmpleado").GetValueOrDefault(),
                    idEmpleadoPadre = row.Field<long?>("idEmpleadoPadre").GetValueOrDefault(),
                    apellidoM = string.IsNullOrEmpty(row.Field<string>("apellidoM")) ? "" : row.Field<string>("apellidoM"),
                    apellidoP = string.IsNullOrEmpty(row.Field<string>("apellidoP")) ? "" : row.Field<string>("apellidoP"),
                    calle = string.IsNullOrEmpty(row.Field<string>("calle")) ? "" : row.Field<string>("calle"),
                    colonia = string.IsNullOrEmpty(row.Field<string>("colonia")) ? "" : row.Field<string>("colonia"),
                    cp = row.Field<int?>("cp").GetValueOrDefault(),
                    curp = string.IsNullOrEmpty(row.Field<string>("curp")) ? "" : row.Field<string>("curp"),
                    cusId = string.IsNullOrEmpty(row.Field<string>("cusId")) ? "" : row.Field<string>("cusId"),
                    email = string.IsNullOrEmpty(row.Field<string>("email")) ? "" : row.Field<string>("email"),
                    estado = string.IsNullOrEmpty(row.Field<string>("estado")) ? "" : row.Field<string>("estado"),
                    genero = string.IsNullOrEmpty(row.Field<string>("genero")) ? "" : row.Field<string>("genero"),
                    telefono = string.IsNullOrEmpty(row.Field<string>("telefono")) ? "" : row.Field<string>("telefono"),
                    telefono2 = string.IsNullOrEmpty(row.Field<string>("telefono2")) ? "" : row.Field<string>("telefono2"),
                    rfc = string.IsNullOrEmpty(row.Field<string>("rfc")) ? "" : row.Field<string>("rfc"),
                    numExterior = row.Field<int?>("numExterior").GetValueOrDefault(),
                    numInterior = row.Field<int?>("numInterior").GetValueOrDefault(),
                    numEmpleado = string.IsNullOrEmpty(row.Field<string>("numEmpleado")) ? "" : row.Field<string>("numEmpleado"),
                    nombre = string.IsNullOrEmpty(row.Field<string>("nombre")) ? "" : row.Field<string>("nombre"),
                    municipioDelegacion = string.IsNullOrEmpty(row.Field<string>("municipioDelegacion")) ? "" : row.Field<string>("municipioDelegacion"),
                    idTipoPago = row.Field<int?>("idTipoPago").GetValueOrDefault(),
                    estatus = row.Field<bool?>("estatus").GetValueOrDefault(),
                    fechaNacimiento = row.Field<DateTime?>("fechaNacimiento").GetValueOrDefault(),
                    fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                    usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                    fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                    usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate")
                }).ToList();

            return result;
        }
        /// <summary>
        /// Busca dependiente
        /// </summary>
        /// <param name="usuarioId">Id usuario</param>
        /// <returns>Lista de dependientes</returns>
        public List<EmpleadoDTO> BuscarDependiente(int usuarioId)
        {
            List<SqlParameter> listaParametros = new List<SqlParameter>();
            listaParametros.Add(new SqlParameter { ParameterName = "@EmpleadoId", Value = usuarioId });
            SqlDataReader reader = base.ExecuteReader("sp_buscarDependiente", listaParametros);

            List<EmpleadoDTO> result = new List<EmpleadoDTO>();
            while (reader.Read())
            {
                result.Add(new EmpleadoDTO
                {
                    apellidoM = reader["apellidoM"].ToString(),
                    apellidoP = reader["apellidoP"].ToString(),
                    calle = reader["calle"].ToString(),
                    colonia = reader["colonia"].ToString(),
                    cp = int.Parse(reader["cp"].ToString()),
                    curp = reader["curp"].ToString(),
                    cusId = reader["cusId"].ToString(),
                    email = reader["email"].ToString(),
                    estado = reader["estado"].ToString(),
                    genero = reader["genero"].ToString(),
                    telefono2 = reader["telefono2"].ToString(),
                    telefono = reader["telefono"].ToString(),
                    rfc = reader["rfc"].ToString(),
                    numExterior = int.Parse(reader["numExterior"].ToString()),
                    numEmpleado = reader["numEmpleado"].ToString(),
                    nombre = reader["nombre"].ToString(),
                    municipioDelegacion = reader["municipioDelegacion"].ToString(),
                    idTipoPago = int.Parse(reader["idTipoPago"].ToString())
                });
            }
            return result;
        }
    }
}
