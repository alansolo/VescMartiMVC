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
    public class RazonSocialController : Controller
    {
        //
        // GET: /RazonSocial/

        public ActionResult RazonSocial()
        {
            return View();
        }

        public JsonResult GetRazonSocial()
        {
            RazonSocialBL razonSocialBL = new RazonSocialBL();

            GetRazonSocialResponseDTO razonSocialResponse = new GetRazonSocialResponseDTO();

            GetRazonSocialRequestDTO razonSocialRequest = new GetRazonSocialRequestDTO();

            razonSocialResponse = razonSocialBL.GetRazonSocial(razonSocialRequest);

            List<RazonSocial> listaRazonSocial = new List<RazonSocial>();

            if (razonSocialResponse.Mensaje == "OK")
            {
                listaRazonSocial = razonSocialResponse.ListaRazonSocial;
            }

            return Json(listaRazonSocial, JsonRequestBehavior.AllowGet);
        }
    }
}
