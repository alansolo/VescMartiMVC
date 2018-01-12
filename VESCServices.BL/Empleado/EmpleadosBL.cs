using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.BL.Resource;
using VESCServices.DAL.Empleado;
using VESCServices.ENT.Common;
using VESCServices.ENT.Entities;
using VESCServices.ENT.Enums;
using VESCServices.ENT.Request.Dependiente;
using VESCServices.ENT.Request.Empleado;
using VESCServices.ENT.Response;
using VESCServices.ENT.Response.Dependiente;
using VESCServices.ENT.Response.Empleado;
using VESCServices.Framework.ExceptionVESC;

namespace VESCServices.BL.Empleado
{
    /// <summary>
    /// Las transacciones con empleados requieren que el usuario este autenticado en el sitio, por eso hereda de SeguridadAutenticado
    /// </summary>
    public class EmpleadosBL : SeguridadAutenticado
    {
        public EmpleadosBL() : base()
        { }
        /// <summary>
        /// Todas las clases deben implementar este contructor para agregar la capa de seguridad, para fines de prueba agil se puede omitir(No olvidar agregar al subir a produccion!)
        /// </summary>
        /// <param name="request"></param>
        public EmpleadosBL(RequestBaseDTO request)
            : base(request)
        {
        }
        /// <summary>
        /// Alta de empleado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AltaEmpleadoResponseDTO AltaEmpleado(AltaEmpleadoRequestDTO request)
        {
            AltaEmpleadoResponseDTO response = new AltaEmpleadoResponseDTO();
            response.ListaEmpleado = new List<EmpleadoDTO>();

            foreach (EmpleadoDTO empleado in request.ListaEmpleado)
            {
                this.ValidaEmpleadoAlta(empleado);
                try
                {
                    empleado.Success = (new EmpleadoDAL()).AltaEmpleado(empleado);
                    response.Success = empleado.Success;
                }
                catch (EmpleadoException empleadoException)
                {
                    empleado.Success = false;
                    response.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
                }
                catch (Exception ex)
                {
                    empleado.Success = false;
                    response.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido + ", " + ex.Message} };
                }

                response.ListaEmpleado.Add(empleado);
            }

            return response;
        }
        public EditEmpleadoResponseDTO EditEmpleado(EditEmpleadoRequestDTO request)
        {
            EditEmpleadoResponseDTO response = new EditEmpleadoResponseDTO();
            response.ListaEmpleado = new List<EmpleadoDTO>();

            foreach (EmpleadoDTO empleado in request.ListaEmpleado)
            {
                this.ValidaEmpleadoEdit(empleado);
                try
                {
                    empleado.Success = (new EmpleadoDAL()).EditEmpleado(empleado);
                    response.Success = empleado.Success;
                }
                catch (EmpleadoException empleadoException)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
                }
                catch (Exception ex)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido + ", " + ex.Message } };
                }

            }

            return response;
        }
        /// <summary>
        /// Busqueda de empleado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BuscarEmpleadoResponseDTO BuscarEmpleado(BuscarEmpleadoRequestDTO request)
        {
            BuscarEmpleadoResponseDTO response = new BuscarEmpleadoResponseDTO();            
            try
            {
                response.ListaEmpleado = (new EmpleadoDAL()).BuscarEmpleado(request.Filtro);
                response.Success = true;
            }
            catch (EmpleadoException empleadoException)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido } };
            }
            return response;
 
        }
        /// <summary>
        /// Alta de dependientes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AltaDependienteResponseDTO AltaDependiente(AltaDependienteRequestDTO request)
        {
            AltaDependienteResponseDTO response = new AltaDependienteResponseDTO();
            response.ListaDependiente = new List<EmpleadoDTO>();

            foreach (EmpleadoDTO empleado in request.ListaDependiente)
            {
                this.ValidaEmpleadoAlta(empleado);
                try
                {
                    empleado.Success = (new EmpleadoDAL()).AltaEmpleado(empleado);
                }
                catch (EmpleadoException empleadoException)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
                }
                catch (Exception ex)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido + ", " + ex.Message } };
                }

                response.ListaDependiente.Add(empleado);
            }

            return response;
        }
        /// <summary>
        /// Busqueda de dependientes!
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public EditDependienteResponseDTO EditDependiente(EditDependienteRequestDTO request)
        {
            EditDependienteResponseDTO response = new EditDependienteResponseDTO();
            response.ListaDependiente = new List<EmpleadoDTO>();

            foreach (EmpleadoDTO empleado in request.ListaDependiente)
            {
                this.ValidaEmpleadoEdit(empleado);
                try
                {
                    empleado.Success = (new EmpleadoDAL()).EditEmpleado(empleado);
                }
                catch (EmpleadoException empleadoException)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
                }
                catch (Exception ex)
                {
                    empleado.Success = false;
                    empleado.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido + ", " + ex.Message } };
                }
            }

            return response;
        }
        public BuscarEmpleadoResponseDTO BuscarDependiente(BuscarEmpleadoRequestDTO request)
        {
            BuscarEmpleadoResponseDTO response = new BuscarEmpleadoResponseDTO();
            try
            {
                response.ListaEmpleado = (new EmpleadoDAL()).BuscarDependiente(idUsuario);
            }
            catch (EmpleadoException empleadoException)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = empleadoException.Code, Descripction = empleadoException.Message } };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogin.ToString(), Descripction = VescMessages.ErrorDesconocido } };
            }
            return response;

        }        
        /// <summary>
        /// Valida que el objeto de tranferencia de datos de empleado contenga los campos requeridos!
        /// </summary>
        /// <param name="empleado"></param>
        private void ValidaEmpleadoAlta(EmpleadoDTO empleado)
        {
            EmpleadoException empleadoException;
            if (empleado.idEmpresa == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }
            if (empleado.idEmpresaInfFiscal == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            //if (empleado.idEmpleado == 0)
            //{
            //    empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
            //    empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
            //    throw empleadoException;
            //}

            if (empleado.cusId == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.numEmpleado == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.nombre == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.apellidoP == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.apellidoM == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.rfc == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.curp == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.genero == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.email == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.calle == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.numExterior == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.colonia == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.municipioDelegacion == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.estado == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.cp == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.telefono == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.telefono2 == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idPlan == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idClub == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idTipoPago == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.usuarioInsert == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.usuarioUpdate == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

        }

        private void ValidaEmpleadoEdit(EmpleadoDTO empleado)
        {
            EmpleadoException empleadoException;
            if (empleado.idEmpresa == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }
            if (empleado.idEmpresaInfFiscal == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idEmpleado == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.cusId == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.numEmpleado == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.nombre == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.apellidoP == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.apellidoM == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.rfc == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.curp == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.genero == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.email == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.calle == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.numExterior == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.colonia == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.municipioDelegacion == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.estado == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.cp == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.telefono == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.telefono2 == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idPlan == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idClub == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.idTipoPago == 0)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }


            if (empleado.usuarioInsert == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

            if (empleado.usuarioUpdate == string.Empty)
            {
                empleadoException = new EmpleadoException(VescMessages.CampoObligatorio, new Exception());
                empleadoException.Code = ErrorCodeEnum.CampoObligatorio.ToString();
                throw empleadoException;
            }

        }

    }
}
