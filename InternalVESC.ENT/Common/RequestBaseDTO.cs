using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VescENT.Common
{
    /// <summary>
    /// Request Base, contiene atributos en común en todos los request. 
    /// Todos los request deben heredar de RequestBaseDTO
    /// </summary>
    [DataContract]
    public class RequestBaseDTO
    {
        [DataMember]
        public string tokenSession { get; set; }

    }
}
