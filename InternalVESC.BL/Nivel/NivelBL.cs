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
    public class NivelBL:INivelBL
    {
        public GetNivelResponseDTO GetNivel(GetNivelRequestDTO nivelRequest)
        {
            GetNivelResponseDTO nivelResponse = new GetNivelResponseDTO();
            List<CatNivel> listaNivel = new List<CatNivel>();

            NivelDal nivelDal = new NivelDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = nivelDal.GetNivel(nivelRequest.idNivel, nivelRequest.nivel);

                listaNivel = dtDatos.AsEnumerable()
                               .Select(row => new CatNivel
                               {
                                   idNivel = row.Field<int?>("idNivel").GetValueOrDefault(),
                                   nivel = string.IsNullOrEmpty(row.Field<string>("nivel")) ? "" : row.Field<string>("nivel"),
                                   descripcion = string.IsNullOrEmpty(row.Field<string>("descripcion")) ? "" : row.Field<string>("descripcion"),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                nivelResponse.ListaNivel = listaNivel;
                nivelResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {

                nivelResponse.ListaNivel = new List<CatNivel>();
                nivelResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return nivelResponse;
        }
        public EditNivelResponseDTO EditNivel(EditNivelRequestDTO nivelRequest)
        {
            EditNivelResponseDTO nivelResponse = new EditNivelResponseDTO();

            NivelDal nivelDal = new NivelDal();

            int resultado = 0;

            foreach (CatNivel nivel in nivelRequest.ListaNivel)
            {
                try
                {
                    resultado = nivelDal.EditNivel(nivel.idNivel, nivel.nivel, nivel.descripcion, nivel.usuarioInsert);

                    if (resultado == 1)
                    {
                        nivel.mensaje = "OK";
                    }
                    else
                    {
                        nivel.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                }
                catch (Exception ex)
                {
                    nivel.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }
            }

            return nivelResponse;
        }
        public AddNivelResponseDTO AddNivel(AddNivelRequestDTO nivelRequest)
        {
            AddNivelResponseDTO nivelResponse = new AddNivelResponseDTO();

            NivelDal nivelDal = new NivelDal();

            try
            {
                foreach (CatNivel nivel in nivelRequest.ListaNivel)
                {
                    nivelDal.AddNivel(nivel.nivel, nivel.descripcion, nivel.usuarioInsert);
                }

                nivelResponse.ListaNivel = new List<CatNivel>();
                nivelResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                nivelResponse.ListaNivel = new List<CatNivel>();
                nivelResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return nivelResponse;
        }

    }
}
