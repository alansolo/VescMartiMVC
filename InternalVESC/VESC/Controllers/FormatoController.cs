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
    public class FormatoController : Controller
    {
        //
        // GET: /Formato/

        public ActionResult Formato()
        {
            return View();
        }
        public JsonResult GetFormato()
        {
            FormatoBL formatoBL = new FormatoBL();

            GetFormatoResponseDTO formatoResponse = new GetFormatoResponseDTO();

            GetFormatoRequestDTO formatoRequest = new GetFormatoRequestDTO();

            List<CatFormato> listaFormato = new List<CatFormato>();

            formatoResponse = formatoBL.GetFormato(formatoRequest);

            if (formatoResponse.Mensaje == "OK")
            {
                listaFormato = formatoResponse.ListaFormato;
            }


            return Json(listaFormato, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditFormato(CatFormato formato, List<CatFormato> listaFormato)
        {
            FormatoBL formatoBL = new FormatoBL();
            EditFormatoRequestDTO editFormatoRequest = new EditFormatoRequestDTO();

            editFormatoRequest.ListaFormato = new List<CatFormato>();
            editFormatoRequest.ListaFormato.Add(formato);

            EditFormatoResponseDTO editFormatoResponse = new EditFormatoResponseDTO();

            editFormatoResponse = formatoBL.EditFormato(editFormatoRequest);


            if (editFormatoResponse.ListaFormato.Count > 0)
            {
                formato.mensaje = editFormatoResponse.ListaFormato[0].mensaje;
            }
            else
            {
                formato.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }


            return Json(listaFormato, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddFormato(CatFormato formato, List<CatFormato> listaFormato)
        {
            formato.usuarioInsert = "alan200531";

            FormatoBL formatoBL = new FormatoBL();

            AddFormatoRequestDTO addFormatoRequest = new AddFormatoRequestDTO();

            addFormatoRequest.ListaFormato = new List<CatFormato>();
            addFormatoRequest.ListaFormato.Add(formato);

            AddFormatoResponseDTO addFormatoResponse = new AddFormatoResponseDTO();

            addFormatoResponse = formatoBL.AddFormato(addFormatoRequest);

            if (addFormatoResponse.ListaFormato.Count > 0)
            {
                formato.mensaje = addFormatoResponse.ListaFormato[0].mensaje;

                listaFormato.Add(formato);
            }
            else
            {
                formato.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaFormato, JsonRequestBehavior.AllowGet);
        }

    }
}
