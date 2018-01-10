using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VescDAL;
using VescENT.Request;
using VescENT.Response;
using VescBL.Interfaces;
using VescENT.Entities;

namespace VescBL
{
    public class LoginEmpresaBL: ILoginEmpresaBL
    {
        public GetLoginEmpresaResponseDTO GetLoginEmpresa(GetLoginEmpresaRequestDTO loginEmpresaRequest)
        {
            GetLoginEmpresaResponseDTO loginEmpresaResponse = new GetLoginEmpresaResponseDTO();
            List<LoginEmpresa> listaLoginEmpresa = new List<LoginEmpresa>();

            LoginEmpresaDal loginEmpresaDal = new LoginEmpresaDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = loginEmpresaDal.GetLoginEmpresa(loginEmpresaRequest.IdLogin, loginEmpresaRequest.IdEmpresa);

                listaLoginEmpresa = dtDatos.AsEnumerable()
                               .Select(row => new LoginEmpresa
                               {
                                   idLogin = row.Field<int?>("idLogin").GetValueOrDefault(),
                                   idEmpresa = row.Field<int?>("idEmpresa").GetValueOrDefault(),
                                   estatus = row.Field<bool?>("estatus").GetValueOrDefault(),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                loginEmpresaResponse.ListaLoginEmpresa = listaLoginEmpresa;
                loginEmpresaResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                loginEmpresaResponse.ListaLoginEmpresa = new List<LoginEmpresa>();
                loginEmpresaResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return loginEmpresaResponse;
        }

    }
}
