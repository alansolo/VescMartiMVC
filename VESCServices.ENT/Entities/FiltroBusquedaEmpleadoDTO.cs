using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VESCServices.ENT.Entities
{
    [DataContract]
    public class FiltroBusquedaEmpleadoDTO
    {
        [DataMember]
        public Nullable<int> EmpresaId { get; set; }
        [DataMember]
        public Nullable<int> RazonSocialId { get; set; }
        [DataMember]
        public Nullable<long> EmpleadoID { get; set; }
        [DataMember]
        public Nullable<long> EmpleadoPadreID { get; set; }
        [DataMember]
        public Nullable<bool> Estatus { get; set; }

    }
}
