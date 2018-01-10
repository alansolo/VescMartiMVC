using System;

namespace VESCServices.Framework.ExceptionVESC
{
        /// <summary>
    /// Se genera un tipo Excepcion de usuario, para poder identificar las excepciones del framework.NET y las excepciones del sistema!
    /// </summary>
    public class LoginException : Exception
    {
        public string Code { get; set; }
        public LoginException()
        { 
        }
        public LoginException(string message)
        {
            
        }
        public LoginException(string message, Exception inner)
            : base(message, inner)
        { 
        }

    }
}
