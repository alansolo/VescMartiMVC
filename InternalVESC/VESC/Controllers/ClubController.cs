using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VescBL;
using VescENT.Response;
using VescENT.Request;
using VescENT.Entities;

namespace VESC.Controllers
{
    public class ClubController : Controller
    {
        //
        // GET: /Club/

        public ActionResult Club()
        {
            return View();
        }

        public JsonResult GetClub()
        {
            ClubBL clubBL = new ClubBL();

            GetClubResponseDTO clubResponse = new GetClubResponseDTO();

            GetClubRequestDTO clubRequest = new GetClubRequestDTO();

            List<CatClub> listaClub = new List<CatClub>();

            clubResponse = clubBL.GetClub(clubRequest);

            if(clubResponse.Mensaje == "OK")
            {
                listaClub = clubResponse.ListaClub;
            }

              
            return Json(listaClub, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditClub(CatClub club, List<CatClub> listaClub)
        {
            ClubBL clubBL = new ClubBL();
            EditClubRequestDTO editClubRequest = new EditClubRequestDTO();

            editClubRequest.ListaClub = new List<CatClub>();
            editClubRequest.ListaClub.Add(club);

            EditClubResponseDTO editClubResponse = new EditClubResponseDTO();

            editClubResponse = clubBL.EditClub(editClubRequest);

            if (editClubResponse.ListaClub.Count > 0)
            {
                club.mensaje = editClubResponse.ListaClub[0].mensaje;
            }
            else
            {
                club.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaClub, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddClub(CatClub club, List<CatClub> listaClub)
        {
            club.usuarioInsert = "alan200531";

            ClubBL clubBL = new ClubBL();

            AddClubRequestDTO addClubRequest = new AddClubRequestDTO();

            addClubRequest.ListaClub = new List<CatClub>();
            addClubRequest.ListaClub.Add(club);

            AddClubResponseDTO addClubResponse = new AddClubResponseDTO();

            addClubResponse = clubBL.AddClub(addClubRequest);

            if (addClubResponse.ListaClub.Count > 0)
            {
                club.mensaje = addClubResponse.ListaClub[0].mensaje;

                listaClub.Add(club);
            }
            else
            {
                club.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaClub, JsonRequestBehavior.AllowGet);
        }

    }
}
