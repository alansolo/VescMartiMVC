using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VescENT.Common
{
    /// <summary>
    /// Almacena la información de un error ocurrido para ser devuelto dentro de los response
    /// </summary>
    [DataContract]
    public class ErrorDTO
    {
        /// <summary>
        /// Código del error
        /// </summary>
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// Descripción del error
        /// </summary>
        [DataMember]
        public string Descripction { get; set; }
    }
}
