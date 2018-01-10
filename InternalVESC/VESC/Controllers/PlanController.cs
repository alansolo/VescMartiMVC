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
    public class PlanController : Controller
    {
        //
        // GET: /Plan/

        public ActionResult Plan()
        {
            return View();
        }

        public JsonResult GetPlan()
        {
            ModalidadPagoBL modalidadPagoBL = new ModalidadPagoBL();
            GetModalidadPagoRequestDTO modalidadPagoRequest = new GetModalidadPagoRequestDTO();

            GetModalidadPagoResponseDTO modalidadPagoResponse = new GetModalidadPagoResponseDTO();

            modalidadPagoResponse = modalidadPagoBL.GetModalidadPago(modalidadPagoRequest);

            List<CatModalidadPago> listaModalidadPago = new List<CatModalidadPago>();

            if (modalidadPagoResponse.Mensaje == "OK")
            {
                listaModalidadPago = modalidadPagoResponse.ListaModalidadPago;
            }

            PlanBL planBL = new PlanBL();
            GetPlanRequestDTO planRequest = new GetPlanRequestDTO();

            GetPlanResponseDTO planResponse = new GetPlanResponseDTO();

            planResponse = planBL.GetPlan(planRequest);

            List<CatPlan> listaPlan = new List<CatPlan>();

            if (planResponse.Mensaje == "OK")
            {
                listaPlan = planResponse.ListaEmpresa;
            }

            List<CatPlan> listaPlanActual = new List<CatPlan>();

            listaPlanActual = (from plan in listaPlan
                               join modalidadPago in listaModalidadPago on plan.idModalidadPago equals modalidadPago.idModalidadPago
                               select new CatPlan
                               {
                                   idPlan = plan.idPlan,
                                   plan = plan.plan,
                                   descripcion = plan.descripcion,
                                   idModalidadPago = plan.idModalidadPago,
                                   modalidadPago = modalidadPago.modalidadPago,
                                   fechaInsert = plan.fechaInsert,
                                   usuarioInsert = plan.usuarioInsert,
                                   fechaUpdate = plan.fechaUpdate,
                                   usuarioUpdate = plan.usuarioUpdate
                               }).ToList();

            PlanModalidadPago planModalidadPago = new PlanModalidadPago();

            planModalidadPago.ListaPlan = listaPlanActual;
            planModalidadPago.ListaModalidadPago = listaModalidadPago;

            return Json(planModalidadPago, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditPlan(CatPlan plan, List<CatPlan> listaPlan)
        {
            PlanBL planBL = new PlanBL();
            EditPlanRequestDTO editPlanRequest = new EditPlanRequestDTO();

            editPlanRequest.ListaPlan = new List<CatPlan>();
            editPlanRequest.ListaPlan.Add(plan);

            EditPlanResponseDTO editPlanResponse = new EditPlanResponseDTO();

            editPlanResponse = planBL.EditPlan(editPlanRequest);

            if (editPlanResponse.ListaPlan.Count > 0)
            {
                plan.mensaje = editPlanResponse.ListaPlan[0].mensaje;
            }
            else
            {
                plan.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }


            return Json(listaPlan, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlan(CatPlan plan, List<CatPlan> listaPlan, List<CatModalidadPago> listaModalidadPago)
        {
            plan.usuarioInsert = "alan200531";

            PlanBL planBL = new PlanBL();

            AddPlanRequestDTO addPlanRequest = new AddPlanRequestDTO();

            addPlanRequest.ListaPlan = new List<CatPlan>();

            addPlanRequest.ListaPlan.Add(plan);

            AddPlanResponseDTO addPlanResponse = new AddPlanResponseDTO();

            addPlanResponse = planBL.AddPlan(addPlanRequest);

            if (addPlanResponse.ListaPlan.Count > 0)
            {
                plan.mensaje = addPlanResponse.ListaPlan[0].mensaje;

                CatModalidadPago modalidadPago = listaModalidadPago.Where(n => n.idModalidadPago == plan.idModalidadPago).FirstOrDefault();

                if(modalidadPago != null)
                {
                    plan.modalidadPago = modalidadPago.modalidadPago;
                }

                listaPlan.Add(plan);
            }
            else
            {
                plan.mensaje = "Error: Ocurrio un problema inesperado, no se actualizo correctamente el Plan Empresarial, intenta de nuevo.";
            }

            return Json(listaPlan, JsonRequestBehavior.AllowGet);
        }

    }

}
