using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VescENT.Entities
{
    public class CorreoElectronico
    {
        public string Host { get; set; }
        public int Puerto { get; set; }
        public bool HabilitarSSL { get; set; }
        public string UsuarioCorreo { get; set; }
        public string PasswordCorreo { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public bool EstatusEnvio { get; set; }
        public string RespuestaEnvio { get; set; }
    }
}