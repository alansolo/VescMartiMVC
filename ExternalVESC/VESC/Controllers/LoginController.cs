using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace VESC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult ValidarLogin(string usuario, string contrasena)
        {
            ServiceReference.LoginResponseDTO loginResponse = new ServiceReference.LoginResponseDTO();
            ServiceReference.LoginRequestDTO loginRequest = new ServiceReference.LoginRequestDTO();

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            loginRequest.usuario = usuario;
            loginRequest.contrasena = contrasena;
            loginRequest.ip = host.AddressList.Where(n => n.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();

            ServiceReference.VescServiceClient vescService = new ServiceReference.VescServiceClient();
            loginResponse = vescService.Login(loginRequest);
            
            if (loginResponse.Success)
            {
                Session["TokenSesion"] = loginResponse.TokenSesion;
                Session["user"] = usuario;
                Session["ip"] = loginRequest.ip;

                Session["idEmpresa"] = 1;
                Session["IdRazonSocial"] = 2;
            }

            return Json(loginResponse, JsonRequestBehavior.AllowGet);
        }

    }
}
