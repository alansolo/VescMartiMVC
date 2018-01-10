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
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/

        public ActionResult Empresa()
        {

            return View();
        }

        public JsonResult GetEmpresa()
        {
            const int idLogin = 6;

            /*Obtener inforamcion del login y las empresas que tiene asociadas*/

            LoginEmpresaBL loginEmpresaBL = new LoginEmpresaBL();
            GetLoginEmpresaRequestDTO loginEmpresaRequest = new GetLoginEmpresaRequestDTO();
            loginEmpresaRequest.IdLogin = idLogin;

            GetLoginEmpresaResponseDTO loginEmpresaResponse = new GetLoginEmpresaResponseDTO();

            loginEmpresaResponse = loginEmpresaBL.GetLoginEmpresa(loginEmpresaRequest);

            List<LoginEmpresa> listaLoginEmpresa = new List<LoginEmpresa>();

            if (loginEmpresaResponse.Mensaje == "OK")
            {
                listaLoginEmpresa = loginEmpresaResponse.ListaLoginEmpresa;
            }

            /*Obtiene todas las empresas*/
            EmpresaBL empresaBL = new EmpresaBL();

            GetEmpresaRequestDTO empresaRequest = new GetEmpresaRequestDTO();

            GetEmpresaResponseDTO empresaResponse = new GetEmpresaResponseDTO();
            empresaResponse = empresaBL.GetEmpresa(empresaRequest);

            List<Empresa> listaEmpresa = new List<Empresa>();

            if (empresaResponse.Mensaje == "OK")
            {
                listaEmpresa = empresaResponse.ListaEmpresa;
            }

            listaEmpresa = empresaResponse.ListaEmpresa;

            /*Realiza un cruce para obtenre las empresas con el login asociado*/

            List<Empresa> ListaEmpresaActual = new List<Empresa>();

            ListaEmpresaActual = (from loginEmpresa in listaLoginEmpresa
                                  join empresa in listaEmpresa on loginEmpresa.idEmpresa equals empresa.idEmpresa
                                  select empresa).ToList();

            ViewBag.ListaEmpresaActual = ListaEmpresaActual;

            return Json(ListaEmpresaActual, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditEmpresa(Empresa empresa)
        {
            EmpresaBL empresaBL = new EmpresaBL();

            EditEmpresaRequestDTO editEmpresaRequest = new EditEmpresaRequestDTO();
            List<Empresa> listaEmpresa = new List<Empresa>();
            empresa.usuarioUpdate = "alan200531";
            listaEmpresa.Add(empresa);

            editEmpresaRequest.ListaEmpresa = listaEmpresa;

            EditEmpresaResponseDTO editEmpresaResponse = new EditEmpresaResponseDTO();

            editEmpresaResponse = empresaBL.EditEmpresa(editEmpresaRequest);

            return Json(empresa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmpresa(Empresa empresa)
        {
            EmpresaBL empresaBL = new EmpresaBL();

            AddEmpresaRequestDTO addEmpresaRequest = new AddEmpresaRequestDTO();
            List<Empresa> listaEmpresa = new List<VescENT.Entities.Empresa>();
            empresa.usuarioInsert = "alan200531";
            listaEmpresa.Add(empresa);

            addEmpresaRequest.ListaEmpresa = listaEmpresa;

            AddEmpresaResponseDTO addEmpresaResponse = new AddEmpresaResponseDTO();

            addEmpresaResponse = empresaBL.AddEmpresa(addEmpresaRequest);

            return Json(empresa, JsonRequestBehavior.AllowGet);
        }
    }
}
