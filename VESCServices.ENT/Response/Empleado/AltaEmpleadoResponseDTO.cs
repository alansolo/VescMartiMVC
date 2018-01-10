using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VESCServices.ENT.Common;
using VESCServices.ENT.Entities;

namespace VESCServices.ENT.Response.Empleado
{
    [DataContract]
    public class AltaEmpleadoResponseDTO : ResponseBaseDTO
    {
        [DataMember]
        public List<EmpleadoDTO> ListaEmpleado { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
