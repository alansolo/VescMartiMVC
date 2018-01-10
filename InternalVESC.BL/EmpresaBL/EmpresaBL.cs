using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Request;
using VescENT.Response;
using VescBL.Interfaces;
using VescENT.Entities;
using System.Data;
using VescDAL;

namespace VescBL
{
    public class EmpresaBL: IEmpresaBL
    {
        public GetEmpresaResponseDTO GetEmpresa(GetEmpresaRequestDTO empresaRequest)
        {
            GetEmpresaResponseDTO empresaResponse = new GetEmpresaResponseDTO();
            List<Empresa> listaEmpresa = new List<Empresa>();

            EmpresaDal empresaDal = new EmpresaDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = empresaDal.GetEmpresa(empresaRequest.IdEmpresa, empresaRequest.Empresa);

                listaEmpresa = dtDatos.AsEnumerable()
                               .Select(row => new Empresa
                               {
                                   idEmpresa = row.Field<int?>("idEmpresa").GetValueOrDefault(),
                                   empresa1 = string.IsNullOrEmpty(row.Field<string>("empresa")) ? "" : row.Field<string>("empresa"),
                                   puestoContacto = string.IsNullOrEmpty(row.Field<string>("puestoContacto")) ? "" : row.Field<string>("puestoContacto"),
                                   apellidoPContacto = string.IsNullOrEmpty(row.Field<string>("apellidoPContacto")) ? "" : row.Field<string>("apellidoPContacto"),
                                   apellidoMContacto = string.IsNullOrEmpty(row.Field<string>("apellidoMContacto")) ? "" : row.Field<string>("apellidoMContacto"),
                                   nombreContacto = string.IsNullOrEmpty(row.Field<string>("nombreContacto")) ? "" : row.Field<string>("nombreContacto"),
                                   correoContacto = string.IsNullOrEmpty(row.Field<string>("correoContacto")) ? "" : row.Field<string>("correoContacto"),
                                   telefonoContacto = string.IsNullOrEmpty(row.Field<string>("telefonoContacto")) ? "" : row.Field<string>("telefonoContacto"),
                                   telefono2Contacto = string.IsNullOrEmpty(row.Field<string>("telefono2Contacto")) ? "" : row.Field<string>("telefono2Contacto"),
                                   estatus = row.Field<bool?>("estatus").GetValueOrDefault(),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                empresaResponse.ListaEmpresa = listaEmpresa;
                empresaResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                empresaResponse.ListaEmpresa = new List<Empresa>();
                empresaResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return empresaResponse;
        }
        public EditEmpresaResponseDTO EditEmpresa(EditEmpresaRequestDTO empresaRequest)
        {
            EditEmpresaResponseDTO empresaResponse = new EditEmpresaResponseDTO();
            empresaResponse.ListaEmpresa = new List<Empresa>();

            EmpresaDal empresaDal = new EmpresaDal();
         
            int resultado = 0;

            foreach (Empresa empresa in empresaRequest.ListaEmpresa)
            {
                try
                { 
                    resultado = empresaDal.EditEmpresa(empresa.idEmpresa, empresa.empresa1, empresa.nombreContacto, empresa.apellidoPContacto,
                                        empresa.apellidoMContacto, empresa.puestoContacto, empresa.telefonoContacto, empresa.telefono2Contacto,
                                        empresa.correoContacto, empresa.estatus, empresa.usuarioUpdate);

                    if(resultado == 1)
                    {
                        empresa.mensaje = "OK";
                    }
                    else
                    {
                        empresa.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                }
                catch (Exception ex)
                {
                    empresa.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }
            }    

            return empresaResponse;
        }
        public AddEmpresaResponseDTO AddEmpresa(AddEmpresaRequestDTO empresaRequest)
        {
            AddEmpresaResponseDTO empresaResponse = new AddEmpresaResponseDTO();

            EmpresaDal empresaDal = new EmpresaDal();

            try
            {
                foreach (Empresa empresa in empresaRequest.ListaEmpresa)
                {
                    empresaDal.AddEmpresa(empresa.empresa1, empresa.nombreContacto, empresa.apellidoPContacto,
                                        empresa.apellidoMContacto, empresa.puestoContacto, empresa.telefonoContacto, empresa.telefono2Contacto,
                                        empresa.correoContacto, empresa.estatus, empresa.idLogin, empresa.usuarioUpdate);
                }

                empresaResponse.ListaEmpresa = new List<VescENT.Entities.Empresa>();
                empresaResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                empresaResponse.ListaEmpresa = new List<Empresa>();
                empresaResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return empresaResponse;
        }
    }
}
