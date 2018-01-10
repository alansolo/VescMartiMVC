using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using VescENT.Entities;

namespace VescFramework
{
    public class EnvioCorreo
    {
        public static CorreoElectronico Enviar(CorreoElectronico correoElectronico)
        {
            using (SmtpClient cliente = new SmtpClient(correoElectronico.Host, correoElectronico.Puerto))
            {
                try
                {
                    cliente.EnableSsl = correoElectronico.HabilitarSSL;
                    cliente.Credentials = new NetworkCredential(correoElectronico.UsuarioCorreo, correoElectronico.PasswordCorreo);
                    MailMessage mensaje = new MailMessage(correoElectronico.Remitente, correoElectronico.Destinatario, correoElectronico.Titulo, correoElectronico.Mensaje);
                    cliente.Send(mensaje);
                    correoElectronico.EstatusEnvio = true;
                    correoElectronico.RespuestaEnvio = "El correo se envío con exito.";
                }
                catch (Exception ex)
                {
                    correoElectronico.EstatusEnvio = false;
                    correoElectronico.RespuestaEnvio = "Ocurrio un error, el correo no se envío. Error: " + ex.Message;
                }
            }

            return correoElectronico;
        }
    }
}