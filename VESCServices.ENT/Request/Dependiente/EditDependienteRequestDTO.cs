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
    public class EditDependienteRequestDTO : RequestBaseDTO
    {
        [DataMember]
        public List<EmpleadoDTO> ListaDependiente { get; set; }
    }
}
