using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescBL.Interfaces;
using VescDAL;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;
using System.Data;

namespace VescBL
{
    public class FormatoBL:IFormatoBL
    {
        public GetFormatoResponseDTO GetFormato(GetFormatoRequestDTO formatoRequest)
        {
            GetFormatoResponseDTO formatoResponse = new GetFormatoResponseDTO();
            List<CatFormato> listaFormato = new List<CatFormato>();

            FormatoDal formatoDal = new FormatoDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = formatoDal.GetFormato(formatoRequest.idFormato, formatoRequest.formato);

                listaFormato = dtDatos.AsEnumerable()
                               .Select(row => new CatFormato
                               {
                                   idFormato = row.Field<int?>("idFormato").GetValueOrDefault(),
                                   formato = string.IsNullOrEmpty(row.Field<string>("formato")) ? "" : row.Field<string>("formato"),
                                   descripcion = string.IsNullOrEmpty(row.Field<string>("descripcion")) ? "" : row.Field<string>("descripcion"),
                                   mensualidad = row.Field<decimal?>("mensualidad").GetValueOrDefault(),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                formatoResponse.ListaFormato = listaFormato;
                formatoResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {

                formatoResponse.ListaFormato = new List<CatFormato>();
                formatoResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return formatoResponse;
        }
        public EditFormatoResponseDTO EditFormato(EditFormatoRequestDTO formatoRequest)
        {
            EditFormatoResponseDTO formatoResponse = new EditFormatoResponseDTO();

            FormatoDal formatoDal = new FormatoDal();

            int resultado = 0;

            foreach (CatFormato formato in formatoRequest.ListaFormato)
            {
                try
                {
                    resultado = formatoDal.EditFormato(formato.idFormato, formato.formato, formato.descripcion, formato.mensualidad, formato.usuarioInsert);

                    if (resultado == 1)
                    {
                        formato.mensaje = "OK";
                    }
                    else
                    {
                        formato.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                }
                catch (Exception ex)
                {
                    formato.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }
            }

            return formatoResponse;
        }
        public AddFormatoResponseDTO AddFormato(AddFormatoRequestDTO formatoRequest)
        {
            AddFormatoResponseDTO formatoResponse = new AddFormatoResponseDTO();

            FormatoDal formatoDal = new FormatoDal();

            try
            {
                foreach (CatFormato formato in formatoRequest.ListaFormato)
                {
                    formatoDal.AddFormato(formato.formato, formato.descripcion, formato.mensualidad, formato.usuarioInsert);
                }

                formatoResponse.ListaFormato = new List<CatFormato>();
                formatoResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                formatoResponse.ListaFormato = new List<CatFormato>();
                formatoResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return formatoResponse;
        }

    }
}
