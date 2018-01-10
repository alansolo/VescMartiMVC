using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VescBL;
using VESCServices.BL.Account;
using VESCServices.BL.Empleado;
using VESCServices.ENT.Common;
using VESCServices.ENT.Request.Account;
using VESCServices.ENT.Request.Dependiente;
using VESCServices.ENT.Request.Empleado;
using VESCServices.ENT.Request.Padron;
using VESCServices.ENT.Request.RazonSocial;
using VESCServices.ENT.Response;
using VESCServices.ENT.Response.Account;
using VESCServices.ENT.Response.Empleado;
using VESCServices.ENT.Response.Padron;
using VESCServices.ENT.Entities;

namespace VESCServices.Services
{
    public class VescService : IVescService
    {
        
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            return (new AccountBL(request)).Login(request);
        }
        
        public SendPasswordResponseDTO SendPassword(SendPasswordRequestDTO request)
        {
            return new SendPasswordResponseDTO();
        }

        public ChangePasswordResponseDTO ChangePassword(ChangePasswordRequestDTO request)
        {
            return new ChangePasswordResponseDTO();
        }
        public LogoutResponseDTO Logout(LogoutRequestDTO request)
        {
            return (new AccountAutenticadoBL(request)).Logout(request);
        }

        public AltaEmpleadoResponseDTO AltaEmpleado(AltaEmpleadoRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new EmpleadosBL(requestBase)).AltaEmpleado(request);
        }
        public EditEmpleadoResponseDTO EditEmpleado(EditEmpleadoRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new EmpleadosBL(requestBase)).EditEmpleado(request);
        }
        public AltaEmpleadoResponseDTO AltaDependiente(AltaEmpleadoRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new EmpleadosBL(requestBase)).AltaEmpleado(request);
        }

        public BuscarEmpleadoResponseDTO BuscarEmpleado(BuscarEmpleadoRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new EmpleadosBL(requestBase)).BuscarEmpleado(request);
        }
        public ConsultaPadronResponseDTO ConsultaPadron(ConsultaPadronRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new PadronBL()).ObtenerPadron(request);
        }

        public GetRazonSocialResponseDTO GetRazonSocial(GetRazonSocialRequestDTO request)
        {
            RequestBaseDTO requestBase = new RequestBaseDTO();
            requestBase.tokenSesion = request.tokenSesion;
            requestBase.ip = request.ip;

            return (new RazonSocialBL(requestBase)).GetRazonSocial(request);
        }
    }
}

