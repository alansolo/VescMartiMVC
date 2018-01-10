using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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
    [ServiceContract]
    public interface IVescService
    {
        [OperationContract]
        LoginResponseDTO Login(LoginRequestDTO request);
        [OperationContract]
        LogoutResponseDTO Logout(LogoutRequestDTO request);
        [OperationContract]
        SendPasswordResponseDTO SendPassword(SendPasswordRequestDTO request);
        [OperationContract]
        ChangePasswordResponseDTO ChangePassword(ChangePasswordRequestDTO request);
        [OperationContract]
        AltaEmpleadoResponseDTO AltaEmpleado(AltaEmpleadoRequestDTO request);
        [OperationContract]
        EditEmpleadoResponseDTO EditEmpleado(EditEmpleadoRequestDTO request);
        [OperationContract]
        AltaEmpleadoResponseDTO AltaDependiente(AltaEmpleadoRequestDTO request);
        [OperationContract]
        BuscarEmpleadoResponseDTO BuscarEmpleado(BuscarEmpleadoRequestDTO request);
        [OperationContract]
        ConsultaPadronResponseDTO ConsultaPadron(ConsultaPadronRequestDTO request);
        [OperationContract]
        GetRazonSocialResponseDTO GetRazonSocial(GetRazonSocialRequestDTO request);
    }
}
