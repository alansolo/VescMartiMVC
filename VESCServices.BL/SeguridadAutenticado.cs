using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.BL.Resource;
using VESCServices.DAL.Seguridad;
using VESCServices.ENT.Common;
using VESCServices.ENT.Enums;
using VESCServices.Framework.ExceptionVESC;

namespace VESCServices.BL
{
    /// <summary>
    /// Clase que se utilizara como clase padre para las clases de negocio cuyas transacciones requieran que el usuario este autenticado.
    /// </summary>
    public class SeguridadAutenticado : Seguridad
    {
        /// <summary>
        /// Al validar que la sesion de un usuario sea valida, se establece el valod IdUsuario de dicha sesion
        /// </summary>
        protected int idUsuario;
        /// <summary>
        /// No se permite constructor vacio, al ingresar lanzara excepcion implementadaa en la clase base.
        /// </summary>
        public SeguridadAutenticado() : base() { }
        /// <summary>
        /// Se valida que el la sesion contenida en el request sea valida.
        /// </summary>
        /// <param name="request"></param>
        public SeguridadAutenticado(RequestBaseDTO request)
            : base(request)
        {
            SeguridadException seguridadAutenticadoException;
            this.idUsuario = (new SeguridadDAL()).ValidarSesionActiva(request.tokenSesion, request.ip);
            if (idUsuario.Equals(0))
            {
                seguridadAutenticadoException = new SeguridadException(VescMessages.SesionNoValida, new Exception());
                seguridadAutenticadoException.Code = ErrorCodeEnum.SesionNoValida.ToString();
                throw seguridadAutenticadoException;
            }

        }
    }
}
