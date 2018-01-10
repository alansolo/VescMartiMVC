using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescDAL;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;
using System.Data;
using VescBL.Interfaces;

namespace VescBL
{
    public class ModalidadPagoBL: IModalidadPagoBL
    {
        public GetModalidadPagoResponseDTO GetModalidadPago(GetModalidadPagoRequestDTO modalidadPagoRequest)
        {
            GetModalidadPagoResponseDTO modalidadPagoResponse = new GetModalidadPagoResponseDTO();
            List<CatModalidadPago> listaModalidadPago = new List<CatModalidadPago>();

            ModalidadPagoDal modalidadPagoDal = new ModalidadPagoDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = modalidadPagoDal.GetModalidadPago(modalidadPagoRequest.IdModalidadPago, modalidadPagoRequest.ModalidadPago);

                listaModalidadPago = dtDatos.AsEnumerable()
                               .Select(row => new CatModalidadPago
                               {
                                   idModalidadPago = row.Field<int?>("idModalidadPago").GetValueOrDefault(),
                                   modalidadPago = string.IsNullOrEmpty(row.Field<string>("modalidadPago")) ? "" : row.Field<string>("modalidadPago"),
                                   descripcion = string.IsNullOrEmpty(row.Field<string>("descripcion")) ? "" : row.Field<string>("descripcion"),                                  
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                modalidadPagoResponse.ListaModalidadPago = listaModalidadPago;
                modalidadPagoResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                modalidadPagoResponse.ListaModalidadPago = new List<CatModalidadPago>();
                modalidadPagoResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return modalidadPagoResponse;
        }
        public EditModalidadPagoResponseDTO EditModalidadPago(EditModalidadPagoRequestDTO modalidadPagoRequest)
        {
            EditModalidadPagoResponseDTO modalidadPagoResponse = new EditModalidadPagoResponseDTO();
            modalidadPagoResponse.ListaModalidadPago = new List<CatModalidadPago>();

            ModalidadPagoDal modalidadPagoDal = new ModalidadPagoDal();

            int resultado = 0;

            foreach (CatModalidadPago modalidadPago in modalidadPagoRequest.ListaModalidadPago)
            {
                try
                {
                    resultado = modalidadPagoDal.EditModalidadPago(modalidadPago.idModalidadPago, modalidadPago.modalidadPago, modalidadPago.descripcion, modalidadPago.usuarioInsert);

                    if (resultado != 0)
                    {
                        modalidadPago.mensaje = "OK";
                    }
                    else
                    {
                        modalidadPago.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                }
                catch (Exception ex)
                {
                    modalidadPago.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";

                }

                modalidadPagoResponse.ListaModalidadPago.Add(modalidadPago);
            }

            return modalidadPagoResponse;
        }
        public AddModalidadPagoResponseDTO AddModalidadPago(AddModalidadPagoRequestDTO modalidadPagoRequest)
        {
            AddModalidadPagoResponseDTO modalidadPagoResponse = new AddModalidadPagoResponseDTO();
            modalidadPagoResponse.ListaModalidadPago = new List<CatModalidadPago>();

            ModalidadPagoDal modalidadPagoDal = new ModalidadPagoDal();

            int resultado = 0;

            foreach (CatModalidadPago modalidadPago in modalidadPagoRequest.ListaModalidadPago)
            {
                try
                {
                    resultado = modalidadPagoDal.AddModalidadPago(modalidadPago.modalidadPago, modalidadPago.descripcion, modalidadPago.usuarioInsert);

                    if (resultado > 0)
                    {
                        modalidadPago.mensaje = "OK";
                    }
                    else
                    {
                        modalidadPago.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }
                }
                catch (Exception ex)
                {
                    modalidadPago.mensaje = "ERROR: " + ex.Message;
                }

                modalidadPagoResponse.ListaModalidadPago.Add(modalidadPago);

            }

            return modalidadPagoResponse;
        }
    }
}
