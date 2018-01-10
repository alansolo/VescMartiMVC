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

            List<ServiceReference.EmpleadoDTO> listaEmpleadosActual = new List<ServiceReference.EmpleadoDTO>();

            if (Session["TokenSesion"] == null || Session["ip"] == null || Session["user"] == null)
            {
                boolSession = false;
                boolError = true;
                strError = "Debe iniciar sesion para poder ingresar a la pagina";

                return Json(new { Session = boolSession, Resul = listaEmpleadosActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
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

                return Json(new { Session = boolSession, Resul = listaEmpleadosActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
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

                return Json(new { Session = boolSession, Resul = listaEmpleadosActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            List<ServiceReference.EmpleadoDTO> listaEmpleados = new List<ServiceReference.EmpleadoDTO>();
            listaEmpleados = buscarEmpleadoResponse.ListaEmpleado.ToList();

            List<ServiceReference.RazonSocialDTO> listaRazonSocial = new List<ServiceReference.RazonSocialDTO>();
            listaRazonSocial = getRazonSocialResponse.ListaRazonSocial.ToList();

            listaEmpleadosActual = (from empleado in listaEmpleados
                                    join razonSocial in listaRazonSocial on empleado.idEmpresaInfFiscal equals razonSocial.idRazonSocial
                                    where empleado.idEmpleadoPadre > 0
                                    select new ServiceReference.EmpleadoDTO
                                    {
                                        apellidoM = empleado.apellidoM,
                                        apellidoP = empleado.apellidoP,
                                        calle = empleado.calle,
                                        colonia = empleado.colonia,
                                        cp = empleado.cp,
                                        curp = empleado.curp,
                                        cusId = empleado.cusId,
                                        email = empleado.email,
                                        empresa = empleado.empresa,
                                        estado = empleado.estado,
                                        fechaNacimiento = empleado.fechaNacimiento,
                                        genero = empleado.genero,
                                        idClub = empleado.idClub,
                                        idEmpleado = empleado.idEmpleado,
                                        idEmpleadoPadre = empleado.idEmpleadoPadre,
                                        idEmpresa = empleado.idEmpresa,
                                        idEmpresaInfFiscal = empleado.idEmpresaInfFiscal,
                                        idPlan = empleado.idPlan,
                                        idTipoPago = empleado.idTipoPago,
                                        municipioDelegacion = empleado.municipioDelegacion,
                                        nombre = empleado.nombre,
                                        numEmpleado = empleado.numEmpleado,
                                        numExterior = empleado.numExterior,
                                        numInterior = empleado.numInterior,
                                        razonSocial = razonSocial.razonSocial,
                                        rfc = empleado.rfc,
                                        telefono = empleado.telefono,
                                        telefono2 = empleado.telefono2,
                                        estatus = empleado.estatus,
                                        fechaInsert = empleado.fechaInsert,
                                        usuarioInsert = empleado.usuarioInsert,
                                        fechaUpdate = empleado.fechaUpdate,
                                        usuarioUpdate = empleado.usuarioUpdate
                                    }).ToList();



            return Json(new { Session = boolSession, Resul = listaEmpleadosActual, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddDependiente(ServiceReference.EmpleadoDTO empleado, List<ServiceReference.EmpleadoDTO> listaEmpleado)
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

                return Json(new { Session = boolSession, Resul = listaEmpleado, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            int idEmpresa = (int)Session["idEmpresa"];
            int idRazonSocial = (int)Session["idRazonSocial"];
            long idEmpleadoPadre = (long)Session["idEmpleadoPadre"];

            ServiceReference.VescServiceClient vescServicio = new ServiceReference.VescServiceClient();

            ServiceReference.AltaEmpleadoRequestDTO altaEmpleadoRequest = new ServiceReference.AltaEmpleadoRequestDTO();

            List<ServiceReference.EmpleadoDTO> listaEmpleadoAlta = new List<ServiceReference.EmpleadoDTO>();

            empleado.idEmpresa = idEmpresa;
            empleado.idEmpresaInfFiscal = idRazonSocial;
            empleado.idEmpleadoPadre = idEmpleadoPadre;
            empleado.idPlan = idPlan;
            empleado.idClub = idClub;
            empleado.idTipoPago = idTipoPago;
            empleado.usuarioInsert = usuarioInsert;

            listaEmpleadoAlta.Add(empleado);

            altaEmpleadoRequest.ListaEmpleado = listaEmpleadoAlta.ToArray();

            altaEmpleadoRequest.tokenSesion = (Guid)Session["TokenSesion"];
            altaEmpleadoRequest.ip = Session["ip"].ToString();

            ServiceReference.AltaEmpleadoResponseDTO altaEmpleadoResponse = new ServiceReference.AltaEmpleadoResponseDTO();

            altaEmpleadoResponse = vescServicio.AltaEmpleado(altaEmpleadoRequest);

            if (altaEmpleadoResponse.Success)
            {
                listaEmpleado.Add(empleado);
            }
            else
            {
                boolError = true;
                strError = altaEmpleadoResponse.Mensaje;
            }

            return Json(new { Session = boolSession, Resul = listaEmpleado, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditDependiente(ServiceReference.EmpleadoDTO empleado, List<ServiceReference.EmpleadoDTO> listaEmpleado)
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

                return Json(new { Session = boolSession, Resul = listaEmpleado, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);
            }

            ServiceReference.VescServiceClient vescServicio = new ServiceReference.VescServiceClient();
            ServiceReference.EditEmpleadoRequestDTO editEmpleadoRequest = new ServiceReference.EditEmpleadoRequestDTO();

            List<ServiceReference.EmpleadoDTO> listaEmpleadoEdit = new List<ServiceReference.EmpleadoDTO>();

            empleado.usuarioUpdate = usuarioUpdate;

            listaEmpleadoEdit.Add(empleado);

            editEmpleadoRequest.ListaEmpleado = listaEmpleadoEdit.ToArray();

            editEmpleadoRequest.tokenSesion = (Guid)Session["TokenSesion"];
            editEmpleadoRequest.ip = Session["ip"].ToString();

            ServiceReference.EditEmpleadoResponseDTO editEmpleadoResponse = new ServiceReference.EditEmpleadoResponseDTO();

            editEmpleadoRequest.tokenSesion = (Guid)Session["TokenSesion"];
            editEmpleadoRequest.ip = Session["ip"].ToString();

            editEmpleadoResponse = vescServicio.EditEmpleado(editEmpleadoRequest);

            if (!editEmpleadoResponse.Success)
            {
                boolError = true;
                strError = editEmpleadoResponse.Mensaje;
            }

            return Json(new { Session = boolSession, Resul = listaEmpleado, Error = boolError, MensajeError = strError }, JsonRequestBehavior.AllowGet);

        }

    }
}
