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
    public class ClubBL:IClubBL
    {
        public GetClubResponseDTO GetClub(GetClubRequestDTO clubRequest)
        {
            GetClubResponseDTO clubResponse = new GetClubResponseDTO();
            List<CatClub> listaClub = new List<CatClub>();

            ClubDal clubDal = new ClubDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = clubDal.GetClub(clubRequest.idClub, clubRequest.club);

                listaClub = dtDatos.AsEnumerable()
                               .Select(row => new CatClub
                               {
                                   idClub = row.Field<int?>("idClub").GetValueOrDefault(),
                                   club = string.IsNullOrEmpty(row.Field<string>("club")) ? "" : row.Field<string>("club"),
                                   descripcion = string.IsNullOrEmpty(row.Field<string>("descripcion")) ? "" : row.Field<string>("descripcion"),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                clubResponse.ListaClub = listaClub;
                clubResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {

                clubResponse.ListaClub = new List<CatClub>();
                clubResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return clubResponse;
        }
        public EditClubResponseDTO EditClub(EditClubRequestDTO clubRequest)
        {
            EditClubResponseDTO clubResponse = new EditClubResponseDTO();

            ClubDal clubDal = new ClubDal();

            int resultado = 0;

            foreach (CatClub club in clubRequest.ListaClub)
            {
                try
                {
                    resultado = clubDal.EditClub(club.idClub, club.club, club.descripcion, club.usuarioInsert);

                    if (resultado == 1)
                    {
                        club.mensaje = "OK";
                    }
                    else
                    {
                        club.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                }
                catch (Exception ex)
                {
                    club.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }
            }

            return clubResponse;
        }
        public AddClubResponseDTO AddClub(AddClubRequestDTO clubRequest)
        {
            AddClubResponseDTO clubResponse = new AddClubResponseDTO();

            ClubDal clubDal = new ClubDal();

            try
            {
                foreach (CatClub club in clubRequest.ListaClub)
                {
                    clubDal.AddClub(club.club, club.descripcion, club.usuarioInsert);
                }

                clubResponse.ListaClub = new List<CatClub>();
                clubResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                clubResponse.ListaClub = new List<CatClub>();
                clubResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return clubResponse;
        }

    }
}
