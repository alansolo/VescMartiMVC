using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.Framework.ExceptionVESC
{
    /// <summary>
    /// Se genera un tipo Excepcion de usuario, para poder identificar las excepciones del framework.NET y las excepciones del sistema!
    /// </summary>
    public class SeguridadException : Exception
    {
        public string Code { get; set; }
        public SeguridadException()
        {
        }
        public SeguridadException(string message)
        {

        }
        public SeguridadException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
