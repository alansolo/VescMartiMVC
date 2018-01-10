using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.BL.Resource;
using VESCServices.ENT.Common;
using VESCServices.ENT.Enums;
using VESCServices.Framework;
using VESCServices.Framework.ExceptionVESC;

namespace VESCServices.BL
{
    /// <summary>
    /// Capa de seguridad.
    /// Esta clase debe ser clase padre de todas las clases pertenecientes a la capa de negocio siempre y cuando 
    /// las transacciones de dicha clase de negocio no requiera que el usuario este autenticado. En caso de que las transacciones
    /// realizadas en la clase necesiten que el usuario este autenticado debe deben heredas de SeguridadAutenticado
    /// </summary>
    public class Seguridad
    {        
        /// <summary>
        /// No se permite un constructor sin request por seguridad, mande excepcion
        /// </summary>
        public Seguridad()        
        {
            SeguridadException seguridadException = new SeguridadException(VescMessages.ConstructorVacio, new Exception());
            seguridadException.Code = ErrorCodeEnum.ConstructorVacio.ToString();
            throw new Exception();
        }
        /// <summary>
        /// Se valida que la peticion al servicio tenga datos minimos(request, IP), caso contrario lanza excepcion de tipo
        /// SeguridadException
        /// </summary>
        /// <param name="request"></param>
        public Seguridad(RequestBaseDTO request)
        {
            SeguridadException seguridadException;
            try
            {
                if (null == request)
                {
                    seguridadException = new SeguridadException(VescMessages.requestNull, new Exception());
                    seguridadException.Code = ErrorCodeEnum.requestNull.ToString();
                    throw seguridadException;
                }
                if (string.IsNullOrEmpty(request.ip))
                {
                    seguridadException = new SeguridadException(VescMessages.IpVacia, new Exception());
                    seguridadException.Code = ErrorCodeEnum.IpVacia.ToString();
                    throw seguridadException;
                }
            }
            catch (SeguridadException sEx)
            {
                throw sEx; 
            }
            catch (Exception ex)
            {
                seguridadException = new SeguridadException(VescMessages.ErrorDesconocido, ex);
                seguridadException.Code = ErrorCodeEnum.DesconocidoSeguridad.ToString();
                Log.WriteException(ErrorCodeEnum.DesconocidoLogin.ToString(), string.Empty, ex);
                throw seguridadException;
            }
        }
    }
}
