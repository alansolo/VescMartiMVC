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
    public class NivelController : Controller
    {
        //
        // GET: /Nivel/

        public ActionResult Nivel()
        {
            return View();
        }

        public JsonResult GetNivel()
        {
            NivelBL nivelBL = new NivelBL();

            GetNivelResponseDTO nivelResponse = new GetNivelResponseDTO();

            GetNivelRequestDTO nivelRequest = new GetNivelRequestDTO();

            List<CatNivel> listaNivel = new List<CatNivel>();

            nivelResponse = nivelBL.GetNivel(nivelRequest);

            if (nivelResponse.Mensaje == "OK")
            {
                listaNivel = nivelResponse.ListaNivel;
            }


            return Json(listaNivel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditNivel(CatNivel nivel, List<CatNivel> listaNivel)
        {
            NivelBL nivelBL = new NivelBL();
            EditNivelRequestDTO editNivelRequest = new EditNivelRequestDTO();

            editNivelRequest.ListaNivel = new List<CatNivel>();
            editNivelRequest.ListaNivel.Add(nivel);

            EditNivelResponseDTO editNivelResponse = new EditNivelResponseDTO();

            editNivelResponse = nivelBL.EditNivel(editNivelRequest);

            if (editNivelResponse.ListaNivel.Count > 0)
            {
                nivel.mensaje = editNivelResponse.ListaNivel[0].mensaje;
            }
            else
            {
                nivel.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }


            return Json(listaNivel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddNivel(CatNivel nivel, List<CatNivel> listaNivel)
        {
            nivel.usuarioInsert = "alan200531";

            NivelBL nivelBL = new NivelBL();

            AddNivelRequestDTO addNivelRequest = new AddNivelRequestDTO();

            addNivelRequest.ListaNivel = new List<CatNivel>();
            addNivelRequest.ListaNivel.Add(nivel);

            AddNivelResponseDTO addNivelResponse = new AddNivelResponseDTO();

            addNivelResponse = nivelBL.AddNivel(addNivelRequest);

            if (addNivelResponse.ListaNivel.Count > 0)
            {
                nivel.mensaje = addNivelResponse.ListaNivel[0].mensaje;

                listaNivel.Add(nivel);
            }
            else
            {
                nivel.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaNivel, JsonRequestBehavior.AllowGet);
        }

    }
}
