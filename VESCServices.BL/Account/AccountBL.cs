using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.ENT.Request.Account;
using VESCServices.ENT.Response.Account;
using VESCServices.BL;
using VESCServices.ENT.Common;
using VESCServices.ENT.Enums;
using VESCServices.BL.Resource;
using VESCServices.DAL.Account;
using VESCServices.Framework;
using VESCServices.Framework.ExceptionVESC;


namespace VESCServices.BL.Account
{
    /// <summary>
    /// Clase con transacciones que no necesitan que el usuario este autenticado
    /// </summary>
    public class AccountBL : Seguridad
    {
        public AccountBL() { }
        /// <summary>
        /// Todas las clases deben implementar este constructor para agregar la capa de seguridad
        /// </summary>
        /// <param name="request"></param>
        public AccountBL(RequestBaseDTO request): base(request) { }
        /// <summary>
        /// Realiza la autenticacion del usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            try
            {
                response = this.validateRequestLogin(request);
                if (response.Success)
                {
                    AccountDAL accountDal = new AccountDAL();
                    int idUsuario = accountDal.Login(request.usuario, request.contrasena);
                    if (idUsuario > 0)
                    {
                        response.TokenSesion = this.CrearSesion(idUsuario, request.ip);
                    }
                    else
                    {
                        response.Success = false;
                        response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.UsarioContrasenaNoValida.ToString(), Descripction = VescMessages.UsarioContrasenaNoValida } };
                    }
                }
            }
            catch (LoginException loginEx)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO{ Code = loginEx.Code , Descripction = loginEx.Message} };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO{ Code = ErrorCodeEnum.DesconocidoLogin.ToString() , Descripction = VescMessages.ErrorDesconocido  + ErrorCodeEnum.DesconocidoLogin.ToString()} };
                Log.WriteException(ErrorCodeEnum.DesconocidoLogin.ToString(), request.usuario, ex);
            }
            return response;
        }
        /// <summary>
        /// Valida que el request contenga los datos requeridos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private LoginResponseDTO validateRequestLogin(LoginRequestDTO request)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            if (string.IsNullOrEmpty(request.usuario) || string.IsNullOrEmpty(request.contrasena))
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.UsuarioContrasenaVacia.ToString(), Descripction = VescMessages.UsuarioContrasenaVacia } };
            else
                response.Success = true;
            return response;
        }
        /// <summary>
        /// Crea una sesion
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private Guid CrearSesion(int idUsuario, string ip)
        {
            Guid token;
            if (validarSesionUnica(idUsuario))
            {
                 token = (new AccountDAL()).CrearSesion(idUsuario, ip);
            }
            else
            {
                LoginException loginException = new LoginException(VescMessages.SesionActiva,new Exception());
                loginException.Code = ErrorCodeEnum.SesionActiva.ToString();
                throw loginException;           
            }
            return token;
        }
        /// <summary>
        /// Valida que un usuario no tenga sesion activa antes de crear una nueva sesion
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        private bool validarSesionUnica(int idUsuario)
        {

            int numeroSesiones = (new AccountDAL()).SesionesActivas(idUsuario);
            bool sesionUnica = false;
            if (numeroSesiones == 0)
            {
                sesionUnica = true;
            }
            else if (numeroSesiones > 1)
            {
                Log.Write("IdUsuario : " + idUsuario.ToString(), "Usuario con multiples sesiones : " + numeroSesiones.ToString());
            }
            return sesionUnica;
        }
    }
}
