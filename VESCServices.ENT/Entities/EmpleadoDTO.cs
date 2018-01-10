using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VESCServices.ENT.Common;

namespace VESCServices.ENT.Entities
{
    [DataContract]
    public class EmpleadoDTO:ResponseBaseDTO
    {
        [DataMember]
        public int idEmpresa { get; set; }
        [DataMember]
        public string empresa { get; set; }
        [DataMember]
        public int idEmpresaInfFiscal { get; set; }
        [DataMember]
        public string razonSocial { get; set; }
        [DataMember]
        public long idEmpleado { get; set; }
        [DataMember]
        public Nullable<long> idEmpleadoPadre { get; set; }
        [DataMember]
        public string cusId { get; set; }
        [DataMember]
        public string numEmpleado { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellidoP { get; set; }
        [DataMember]
        public string apellidoM { get; set; }
        [DataMember]
        public System.DateTime fechaNacimiento { get; set; }
        [DataMember]
        public string rfc { get; set; }
        [DataMember]
        public string curp { get; set; }
        [DataMember]
        public string genero { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string calle { get; set; }
        [DataMember]
        public int numExterior { get; set; }
        [DataMember]
        public Nullable<int> numInterior { get; set; }
        [DataMember]
        public string colonia { get; set; }
        [DataMember]
        public string municipioDelegacion { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public int cp { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string telefono2 { get; set; }
        [DataMember]
        public int idPlan { get; set; }
        [DataMember]
        public int idClub { get; set; }
        [DataMember]
        public int idTipoPago { get; set; }
        [DataMember]
        public bool estatus { get; set; }
        [DataMember]
        public System.DateTime fechaInsert { get; set; }
        [DataMember]
        public string usuarioInsert { get; set; }
        [DataMember]
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        [DataMember]
        public string usuarioUpdate { get; set; }

    }
}
