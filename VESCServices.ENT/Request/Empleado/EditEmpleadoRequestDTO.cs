using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VESCServices.ENT.Common;
using VESCServices.ENT.Entities;

namespace VESCServices.ENT.Request.Empleado
{
    [DataContract]
    public class EditEmpleadoRequestDTO : RequestBaseDTO
    {
        [DataMember]
        public List<EmpleadoDTO> ListaEmpleado { get; set; }
    }
}
