using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;
using VescBL.Interfaces;
using System.Data;
using VescDAL;

namespace VescBL
{
    public class PlanBL:IPlanBL
    {
        public GetPlanResponseDTO GetPlan(GetPlanRequestDTO planRequest)
        {
            GetPlanResponseDTO empresaResponse = new GetPlanResponseDTO();
            List<CatPlan> listaEmpresa = new List<CatPlan>();

            PlanDal planDal = new PlanDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = planDal.GetPlan(planRequest.IdPlan, planRequest.Plan);

                listaEmpresa = dtDatos.AsEnumerable()
                               .Select(row => new CatPlan
                               {
                                   idPlan = row.Field<int?>("idPlan").GetValueOrDefault(),
                                   plan = string.IsNullOrEmpty(row.Field<string>("plan")) ? "" : row.Field<string>("plan"),
                                   descripcion = string.IsNullOrEmpty(row.Field<string>("descripcion")) ? "" : row.Field<string>("descripcion"),
                                   idModalidadPago = row.Field<int?>("idModalidadPago").GetValueOrDefault(),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                empresaResponse.ListaEmpresa = listaEmpresa;
                empresaResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                empresaResponse.ListaEmpresa = new List<CatPlan>();
                empresaResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return empresaResponse;
        }
        public EditPlanResponseDTO EditPlan(EditPlanRequestDTO planRequest)
        {
            EditPlanResponseDTO planResponse = new EditPlanResponseDTO();
            planResponse.ListaPlan = new List<CatPlan>();

            PlanDal planDal = new PlanDal();

            int resultado = 0;

            foreach (CatPlan plan in planRequest.ListaPlan)
            {
                try
                {
                    resultado = planDal.EditPlan(plan.idPlan, plan.plan, plan.descripcion, plan.idModalidadPago,
                                                    plan.usuarioUpdate);

                    if (resultado == -1)
                    {
                        plan.mensaje = "OK";
                    }
                    else
                    {
                        plan.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }
                }
                catch (Exception ex)
                {
                    plan.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }

                planResponse.ListaPlan.Add(plan);
            }

            return planResponse;
        }
        public AddPlanResponseDTO AddPlan(AddPlanRequestDTO planRequest)
        {
            AddPlanResponseDTO planResponse = new AddPlanResponseDTO();
            planResponse.ListaPlan = new List<CatPlan>();

            PlanDal planDal = new PlanDal();

            int resultado = 0;

            foreach (CatPlan plan in planRequest.ListaPlan)
            {
                try
                {
                    resultado = planDal.AddPlan(plan.plan, plan.descripcion, plan.idModalidadPago, plan.usuarioInsert);

                    if (resultado == -1)
                    {
                        plan.mensaje = "OK";
                    }
                    else
                    {
                        plan.mensaje = "Error: Ocurrio un problema y no se edito la informacion de forma adecuada.";
                    }

                    planResponse.ListaPlan.Add(plan);
                }
                catch (Exception ex)
                {
                    plan.mensaje = "Error: " + ex.Message + ": Ocurrio un problema y no se edito la informacion de forma adecuada.";
                }
            }

            return planResponse;
        }

    }
}
