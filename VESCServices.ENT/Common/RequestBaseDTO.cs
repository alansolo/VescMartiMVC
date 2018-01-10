using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VESCServices.ENT.Common
{
    /// <summary>
    /// Request Base, contiene atributos en común en todos los request. 
    /// Todos los request deben heredar de RequestBaseDTO
    /// </summary>
    [DataContract]
    public class RequestBaseDTO
    {
        /// <summary>
        /// Sesion de usuario
        /// </summary>
        [DataMember]
        public Guid tokenSesion { get; set; }
        /// <summary>
        /// Ip del usuario
        /// </summary>
        [DataMember]
        public string ip { get; set; }

    }

}
