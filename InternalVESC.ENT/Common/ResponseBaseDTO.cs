using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VescENT.Common
{
    /// <summary>
    /// Contiene atributos en común en todos los Response,
    /// todos los response deben heredar de ResponseBaseDTO
    /// </summary>
    [DataContract]
    public class ResponseBaseDTO
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// Si Success = true, ErrorList null o vacio
        /// Si Success = false, ErrorList distinto de null y con un elemento como mínimo
        /// </summary>
        [DataMember]
        public string Success { get; set; }
        /// <summary>
        /// Lista de errores
        /// </summary>
        [DataMember]
        public List<ErrorDTO> ErrorList { get; set; }
    }
}
