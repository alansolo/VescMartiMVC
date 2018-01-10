using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.BL.Resource;
using VESCServices.DAL.Account;
using VESCServices.ENT.Common;
using VESCServices.ENT.Enums;
using VESCServices.ENT.Request.Account;
using VESCServices.ENT.Response.Account;
using VESCServices.Framework;

namespace VESCServices.BL.Account
{
    /// <summary>
    /// Manejo de cuenta de usuario: para ejecutar los metodos el usuario requiere estar autenticado, por eso hereda de Seguridad autenticado
    /// </summary>
    public class AccountAutenticadoBL : SeguridadAutenticado
    {
        /// <summary>
        /// Todas las clases deben implementar este contructor para agregar la capa de seguridad a la clase de negocio
        /// </summary>
        /// <param name="request"></param>
        public AccountAutenticadoBL(RequestBaseDTO request)
            : base(request)
        {
        }
        /// <summary>
        /// Cierra sesion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LogoutResponseDTO Logout(LogoutRequestDTO request)
        {
            LogoutResponseDTO response = new LogoutResponseDTO();
            try
            {
                (new AccountDAL()).CerrarSesion(request.tokenSesion);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoLogout.ToString(), Descripction = VescMessages.ErrorDesconocido + ErrorCodeEnum.DesconocidoLogout.ToString() } };
                Log.WriteException(ErrorCodeEnum.DesconocidoLogin.ToString(), base.idUsuario.ToString() , ex);
            }
            return response;
        }
    }
}
