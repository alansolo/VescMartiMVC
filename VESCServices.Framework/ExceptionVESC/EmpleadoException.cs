using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.Framework.ExceptionVESC
{
    /// <summary>
    /// Se genera un tipo Excepcion de usuario, para poder identificar las excepciones del framework.NET y las excepciones del sistema!
    /// </summary>
    public class EmpleadoException : Exception
    {
        public string Code { get; set; }
        public EmpleadoException()
        {
        }
        public EmpleadoException(string message)
        {

        }
        public EmpleadoException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
