using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VescBL;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;

namespace VESC.Controllers
{
    public class ModalidadPagoController : Controller
    {
        //
        // GET: /ModalidadPago/

        public ActionResult ModalidadPago()
        {
            return View();
        }

        public JsonResult GetModalidadPago()
        {
            ModalidadPagoBL modalidadPagoBL = new ModalidadPagoBL();

            GetModalidadPagoResponseDTO modalidadPagoResponse = new GetModalidadPagoResponseDTO();

            GetModalidadPagoRequestDTO modalidadPagoRequest = new GetModalidadPagoRequestDTO();

            List<CatModalidadPago> listaModalidadPago = new List<CatModalidadPago>();

            modalidadPagoResponse = modalidadPagoBL.GetModalidadPago(modalidadPagoRequest);

            if (modalidadPagoResponse.Mensaje == "OK")
            {
                listaModalidadPago = modalidadPagoResponse.ListaModalidadPago;
            }


            return Json(listaModalidadPago, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditModalidadPago(CatModalidadPago modalidadPago, List<CatModalidadPago> listaModalidadPago)
        {
            ModalidadPagoBL modalidadPagoBL = new ModalidadPagoBL();
            EditModalidadPagoRequestDTO editModalidadPagoRequest = new EditModalidadPagoRequestDTO();

            editModalidadPagoRequest.ListaModalidadPago = new List<CatModalidadPago>();
            editModalidadPagoRequest.ListaModalidadPago.Add(modalidadPago);

            EditModalidadPagoResponseDTO editModalidadPagoResponse = new EditModalidadPagoResponseDTO();

            editModalidadPagoResponse = modalidadPagoBL.EditModalidadPago(editModalidadPagoRequest);

            if (editModalidadPagoResponse.ListaModalidadPago.Count > 0)
            {
                modalidadPago.mensaje = editModalidadPagoResponse.ListaModalidadPago[0].mensaje;
            }
            else
            {
                modalidadPago.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaModalidadPago, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddModalidadPago(CatModalidadPago modalidadPago, List<CatModalidadPago> listaModalidadPago)
        {
            modalidadPago.usuarioInsert = "alan200531";

            ModalidadPagoBL modalidadPagoBL = new ModalidadPagoBL();

            AddModalidadPagoRequestDTO addModalidadPagoRequest = new AddModalidadPagoRequestDTO();

            addModalidadPagoRequest.ListaModalidadPago = new List<CatModalidadPago>();
            addModalidadPagoRequest.ListaModalidadPago.Add(modalidadPago);

            AddModalidadPagoResponseDTO addModalidadPagoResponse = new AddModalidadPagoResponseDTO();

            addModalidadPagoResponse = modalidadPagoBL.AddModalidadPago(addModalidadPagoRequest);

            if (addModalidadPagoResponse.ListaModalidadPago.Count > 0)
            {
                modalidadPago.mensaje = addModalidadPagoResponse.ListaModalidadPago[0].mensaje;

                listaModalidadPago.Add(modalidadPago);
            }
            else
            {
                modalidadPago.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaModalidadPago, JsonRequestBehavior.AllowGet);
        }

    }
}
