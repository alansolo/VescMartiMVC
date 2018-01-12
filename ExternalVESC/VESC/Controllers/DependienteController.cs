using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VESC.Controllers
{
    public class DependienteController : Controller
    {
        //
        // GET: /Dependiente/

        public ActionResult Dependiente()
        {
            return View();
        }
        public JsonResult GetDependiente()
        {
            bool boolSession = true;
            bool boolError = false;
            string strError = string.Empty;

            List<ServiceReference.EmpleadoDTO> listaDependientesActual = new List<ServiceReference.EmpleadoDTO>();

            if (Session["TokenSesion"] == null || Session["ip"] == null || Session["user"] == null)
            {
                boolSession = false;
                boolError = true;
                strError = "Debe iniciar sesion para poder ingresar a la pagina";

                return Json(new { Session = boolSession, Resul = listaDependientesActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            string user = Session["user"].ToString();
            int idEmpresa = (int)Session["idEmpresa"];
            int idRazonSocial = (int)Session["idRazonSocial"];
            //long idEmpleado = (long)Session["idEmpleado"];
            long idEmpleadoPadre = (long)Session["idEmpleadoPadre"];

            ServiceReference.VescServiceClient vescServicio = new ServiceReference.VescServiceClient();

            ServiceReference.GetRazonSocialRequestDTO getRazonSocialRequest = new ServiceReference.GetRazonSocialRequestDTO();

            getRazonSocialRequest.tokenSesion = (Guid)Session["TokenSesion"];
            getRazonSocialRequest.ip = Session["ip"].ToString();

            getRazonSocialRequest.IdRazonSocial = idRazonSocial;

            ServiceReference.GetRazonSocialResponseDTO getRazonSocialResponse = new ServiceReference.GetRazonSocialResponseDTO();

            getRazonSocialResponse = vescServicio.GetRazonSocial(getRazonSocialRequest);

            if (getRazonSocialResponse.Mensaje != "OK")
            {
                boolError = true;
                strError = getRazonSocialResponse.Mensaje;

                return Json(new { Session = boolSession, Resul = listaDependientesActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            ServiceReference.BuscarEmpleadoRequestDTO buscarEmpleadoRequest = new ServiceReference.BuscarEmpleadoRequestDTO();

            ServiceReference.FiltroBusquedaEmpleadoDTO filtroEmpleado = new ServiceReference.FiltroBusquedaEmpleadoDTO();

            filtroEmpleado.EmpresaId = idEmpresa;
            filtroEmpleado.RazonSocialId = idRazonSocial;
            filtroEmpleado.EmpleadoID = null;
            filtroEmpleado.EmpleadoPadreID = idEmpleadoPadre;
            filtroEmpleado.Estatus = null;

            buscarEmpleadoRequest.Filtro = filtroEmpleado;

            buscarEmpleadoRequest.tokenSesion = (Guid)Session["TokenSesion"];
            buscarEmpleadoRequest.ip = Session["ip"].ToString();

            ServiceReference.BuscarEmpleadoResponseDTO buscarEmpleadoResponse = new ServiceReference.BuscarEmpleadoResponseDTO();

            buscarEmpleadoResponse = vescServicio.BuscarEmpleado(buscarEmpleadoRequest);

            if (!buscarEmpleadoResponse.Success)
            {
                boolError = true;
                strError = buscarEmpleadoResponse.Mensaje;

                return Json(new { Session = boolSession, Resul = listaDependientesActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            List<ServiceReference.EmpleadoDTO> listaDependientes = new List<ServiceReference.EmpleadoDTO>();
            listaDependientes = buscarEmpleadoResponse.ListaEmpleado.ToList();

            List<ServiceReference.RazonSocialDTO> listaRazonSocial = new List<ServiceReference.RazonSocialDTO>();
            listaRazonSocial = getRazonSocialResponse.ListaRazonSocial.ToList();

            listaDependientesActual = (from dependiente in listaDependientes
                                    join razonSocial in listaRazonSocial on dependiente.idEmpresaInfFiscal equals razonSocial.idRazonSocial
                                    where dependiente.idEmpleadoPadre > 0
                                    select new ServiceReference.EmpleadoDTO
                                    {
                                        apellidoM = dependiente.apellidoM,
                                        apellidoP = dependiente.apellidoP,
                                        calle = dependiente.calle,
                                        colonia = dependiente.colonia,
                                        cp = dependiente.cp,
                                        curp = dependiente.curp,
                                        cusId = dependiente.cusId,
                                        email = dependiente.email,
                                        empresa = dependiente.empresa,
                                        estado = dependiente.estado,
                                        fechaNacimiento = dependiente.fechaNacimiento,
                                        genero = dependiente.genero,
                                        idClub = dependiente.idClub,
                                        idEmpleado = dependiente.idEmpleado,
                                        idEmpleadoPadre = dependiente.idEmpleadoPadre,
                                        idEmpresa = dependiente.idEmpresa,
                                        idEmpresaInfFiscal = dependiente.idEmpresaInfFiscal,
                                        idPlan = dependiente.idPlan,
                                        idTipoPago = dependiente.idTipoPago,
                                        municipioDelegacion = dependiente.municipioDelegacion,
                                        nombre = dependiente.nombre,
                                        numEmpleado = dependiente.numEmpleado,
                                        numExterior = dependiente.numExterior,
                                        numInterior = dependiente.numInterior,
                                        razonSocial = razonSocial.razonSocial,
                                        rfc = dependiente.rfc,
                                        telefono = dependiente.telefono,
                                        telefono2 = dependiente.telefono2,
                                        estatus = dependiente.estatus,
                                        fechaInsert = dependiente.fechaInsert,
                                        usuarioInsert = dependiente.usuarioInsert,
                                        fechaUpdate = dependiente.fechaUpdate,
                                        usuarioUpdate = dependiente.usuarioUpdate
                                    }).ToList();



            return Json(new { Session = boolSession, Resul = listaDependientesActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddDependiente(ServiceReference.EmpleadoDTO dependiente, List<ServiceReference.EmpleadoDTO> listaDependiente)
        {
            bool boolSession = true;
            bool boolError = false;
            string strError = string.Empty;

            const int idPlan = 1;
            const int idClub = 1;
            const int idTipoPago = 1;

            const string usuarioInsert = "alan200531";

            if (Session["TokenSesion"] == null || Session["ip"] == null || Session["user"] == null)
            {
                boolSession = false;
                boolError = true;
                strError = "Debe iniciar sesion para poder ingresar a la pagina";

                return Json(new { Session = boolSession, Resul = listaDependiente, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            int idEmpresa = (int)Session["idEmpresa"];
            int idRazonSocial = (int)Session["idRazonSocial"];
            long idEmpleadoPadre = (long)Session["idEmpleadoPadre"];

            ServiceReference.VescServiceClient vescServicio = new ServiceReference.VescServiceClient();

            ServiceReference.AltaEmpleadoRequestDTO altaDependienteRequest = new ServiceReference.AltaEmpleadoRequestDTO();

            List<ServiceReference.EmpleadoDTO> listaDependienteAlta = new List<ServiceReference.EmpleadoDTO>();

            dependiente.idEmpresa = idEmpresa;
            dependiente.idEmpresaInfFiscal = idRazonSocial;
            dependiente.idEmpleadoPadre = idEmpleadoPadre;
            dependiente.idPlan = idPlan;
            dependiente.idClub = idClub;
            dependiente.idTipoPago = idTipoPago;
            dependiente.usuarioInsert = usuarioInsert;

            listaDependienteAlta.Add(dependiente);

            altaDependienteRequest.ListaEmpleado = listaDependienteAlta.ToArray();

            altaDependienteRequest.tokenSesion = (Guid)Session["TokenSesion"];
            altaDependienteRequest.ip = Session["ip"].ToString();

            ServiceReference.AltaEmpleadoResponseDTO altaDependienteResponse = new ServiceReference.AltaEmpleadoResponseDTO();

            altaDependienteResponse = vescServicio.AltaEmpleado(altaDependienteRequest);

            if (altaDependienteResponse.Success)
            {
                listaDependiente.Add(dependiente);
            }
            else
            {
                boolError = true;
                strError = altaDependienteResponse.Mensaje;
            }

            return Json(new { Session = boolSession, Resul = listaDependiente, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditDependiente(ServiceReference.EmpleadoDTO dependiente, List<ServiceReference.EmpleadoDTO> listaDependiente)
        {
            bool boolSession = true;
            bool boolError = false;
            string strError = string.Empty;

            const string usuarioUpdate = "alan200531";

            if (Session["TokenSesion"] == null || Session["ip"] == null || Session["user"] == null)
            {
                boolSession = false;
                boolError = true;
                strError = "Debe iniciar sesion para poder ingresar a la pagina";

                return Json(new { Session = boolSession, Resul = listaDependiente, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            ServiceReference.VescServiceClient vescServicio = new ServiceReference.VescServiceClient();
            ServiceReference.EditEmpleadoRequestDTO editDependienteRequest = new ServiceReference.EditEmpleadoRequestDTO();

            List<ServiceReference.EmpleadoDTO> listaDependienteEdit = new List<ServiceReference.EmpleadoDTO>();

            dependiente.usuarioUpdate = usuarioUpdate;

            listaDependienteEdit.Add(dependiente);

            editDependienteRequest.ListaEmpleado = listaDependienteEdit.ToArray();

            editDependienteRequest.tokenSesion = (Guid)Session["TokenSesion"];
            editDependienteRequest.ip = Session["ip"].ToString();

            ServiceReference.EditEmpleadoResponseDTO editDependienteResponse = new ServiceReference.EditEmpleadoResponseDTO();

            editDependienteResponse = vescServicio.EditEmpleado(editDependienteRequest);

            if (!editDependienteResponse.Success)
            {
                boolError = true;
                strError = editDependienteResponse.Mensaje;
            }

            return Json(new { Session = boolSession, Resul = listaDependiente, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);

        }

    }
}
